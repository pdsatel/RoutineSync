using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.IO.Pipelines;

namespace Tcc
{
    public partial class RelatorioUserControl : UserControl
    {
        private Panel legendPanel;
        private Panel resumoPanel;
        private Label lblTotal;
        private Label lblConcluidas;
        private Label lblPendentes;
        private ListView listProximasTarefas;
        private PlotView plotViewBarras;
        private Button btnExportarPDF;
        private int usuarioID;
        // Labels de títulos longos
        private Label lblTituloPrioridade;
        private Label lblTituloStatus;
        private Label lblTituloBarras;

        public RelatorioUserControl(int usuarioID)
        {

            this.usuarioID = usuarioID;
            InitializeComponent();
            InicializarTítulos();
            InicializarResumo();
            InicializarProximasTarefas();
            InicializarGraficoBarras();

            



            legendPanel = new Panel
            {
                Location = new System.Drawing.Point(20, 330),
                Size = new System.Drawing.Size(400, 100),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(legendPanel);


            btnExportarPDF = new Button
            {
                Text = "Salvar em PDF",
                Location = new System.Drawing.Point(20, 580), // ajuste a posição se necessário
                Size = new System.Drawing.Size(180, 70)
            };
            btnExportarPDF.Click += BtnExportarPDF_Click;
            this.Controls.Add(btnExportarPDF);
        }

        private void BtnExportarPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "RelatorioTarefas.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Gere os dados do relatório (pegue do seu método de busca)
                    int usuarioId = usuarioID;
                    var tarefas = BuscarTarefasUsuario(this.usuarioID);
                    

                    Document doc = new Document(iTextSharp.text.PageSize.A4);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.png");
                    // Após adicionar a logo e o espaço
                    string nomeUsuario = BuscarNomeDoUsuario(usuarioID); // Você precisa implementar esse método de acordo com seu banco
                    string nomeProjeto = "RoutineSync";
                    string dataGeracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                    iTextSharp.text.Font fontCabecalho = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);

                    Paragraph cabecalho = new Paragraph($"{nomeProjeto} - Usuário: {nomeUsuario} - Gerado em: {dataGeracao}", fontCabecalho);
                    cabecalho.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    doc.Add(cabecalho);

                    doc.Add(new Paragraph(" ")); // Espaço após o cabeçalho
                    if (File.Exists(logoPath))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                        logo.ScaleAbsolute(120f, 120f);
                        // Use o namespace completo:
                        logo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        doc.Add(logo);

                        // Espaço após a logo
                        doc.Add(new Paragraph(" "));
                    }

                    // Título do relatório
                    doc.Add(new Paragraph("Relatório de Tarefas"));
                    doc.Add(new Paragraph(" "));

                    // Adicione estatísticas
                    int total = tarefas.Count;
                    int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
                    int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));
                    doc.Add(new Paragraph($"Total: {total}   Concluídas: {concluidas}   Pendentes: {pendentes}"));
                    doc.Add(new Paragraph(" "));

                    // Tabela de tarefas
                    PdfPTable tabela = new PdfPTable(5); // 5 colunas
                    tabela.AddCell("Título");
                    tabela.AddCell("Data Entrega");
                    tabela.AddCell("Status");
                    tabela.AddCell("Prioridade");
                    tabela.AddCell("Descrição");

                    foreach (var tarefa in tarefas)
                    {
                        tabela.AddCell(tarefa.Titulo);
                        tabela.AddCell(tarefa.DataEntrega.ToString("dd/MM/yyyy HH:mm"));
                        tabela.AddCell(tarefa.Status);
                        tabela.AddCell(tarefa.Prioridade);
                        tabela.AddCell(tarefa.Descricao);
                    }
                    doc.Add(tabela);

                    string graficoPrioridadePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_prioridade.png");
                    string graficoStatusPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_status.png");
                    string graficoBarrasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_barras.png");

                    if (File.Exists(graficoPrioridadePath))
                    {
                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph("Gráfico: Prioridade das Tarefas"));
                        iTextSharp.text.Image imgPrioridade = iTextSharp.text.Image.GetInstance(graficoPrioridadePath);
                        imgPrioridade.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        imgPrioridade.ScaleToFit(300f, 200f);
                        doc.Add(imgPrioridade);


                        doc.Add(new Paragraph("Legenda:"));
                        doc.Add(new Paragraph("• Baixa - Verde claro"));
                        doc.Add(new Paragraph("• Média - Laranja"));
                        doc.Add(new Paragraph("• Alta - Vermelho"));
                    }

                    if (File.Exists(graficoStatusPath))
                    {
                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph("Gráfico: Status das Tarefas"));
                        iTextSharp.text.Image imgStatus = iTextSharp.text.Image.GetInstance(graficoStatusPath);
                        imgStatus.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        imgStatus.ScaleToFit(300f, 200f);
                        doc.Add(imgStatus);


                        doc.Add(new Paragraph("Legenda:"));
                        doc.Add(new Paragraph("• Concluídas - Azul claro"));
                        doc.Add(new Paragraph("• Pendentes - Rosa claro"));
                    }

                    if (File.Exists(graficoBarrasPath))
                    {
                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph("Gráfico: Tarefas concluídas por mês"));
                        iTextSharp.text.Image imgPorMes = iTextSharp.text.Image.GetInstance(graficoBarrasPath);
                        imgPorMes.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        imgPorMes.ScaleToFit(400f, 250f);
                        doc.Add(imgPorMes);
                    }
                    doc.Close();

                    MessageBox.Show("PDF gerado com sucesso!", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar PDF: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Adiciona labels de títulos longos acima dos gráficos
        private void InicializarTítulos()
        {
            lblTituloPrioridade = new Label
            {
                Text = "Distribuição de Tarefas por Prioridade",
                Location = new System.Drawing.Point(20, 10),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold)
            };
            this.Controls.Add(lblTituloPrioridade);

            lblTituloStatus = new Label
            {
                Text = "Tarefas Concluídas x Pendentes",
                Location = new System.Drawing.Point(420, 10),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold)
            };
            this.Controls.Add(lblTituloStatus);

            lblTituloBarras = new Label
            {
                Text = "Tarefas concluídas por mês",
                Location = new System.Drawing.Point(450, 390),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold)
            };
            this.Controls.Add(lblTituloBarras);
        }

        // Atualiza a legenda de prioridade com valores e percentuais
        private void AtualizarLegendaPrioridade(int baixa, int media, int alta)
        {
            legendPanel.Controls.Clear();
            int total = baixa + media + alta;
            AddLegendaItem($"Baixa ({baixa} - {Percent(baixa, total)}%)", OxyColors.LightGreen);
            AddLegendaItem($"Média ({media} - {Percent(media, total)}%)", OxyColors.Orange);
            AddLegendaItem($"Alta ({alta} - {Percent(alta, total)}%)", OxyColors.Red);
        }

        private int Percent(int valor, int total)
        {
            if (total == 0) return 0;
            return (int)Math.Round((double)valor * 100 / total);
        }

        private void AddLegendaItem(string texto, OxyColor cor)
        {
            var index = legendPanel.Controls.Count / 2;
            var colorBox = new Panel
            {
                BackColor = System.Drawing.Color.FromArgb(cor.A, cor.R, cor.G, cor.B),
                Size = new System.Drawing.Size(20, 20),
                Location = new System.Drawing.Point(10, 10 + index * 30)
            };
            var lbl = new Label
            {
                Text = texto,
                Location = new System.Drawing.Point(40, 10 + index * 30 + 2),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10)
            };
            legendPanel.Controls.Add(colorBox);
            legendPanel.Controls.Add(lbl);
        }

        public void AtualizarRelatorioDoBanco(int usuarioId)
        {
            var tarefas = BuscarTarefasUsuario(usuarioId);

            AtualizarGraficoPrioridade(tarefas);
            AtualizarGraficoStatus(tarefas);

            int total = tarefas.Count;
            int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));

            AtualizarResumo(total, concluidas, pendentes);
            AtualizarProximasTarefas(tarefas);
            AtualizarGraficoBarras(tarefas);
        }

        private void InicializarProximasTarefas()
        {
            listProximasTarefas = new ListView
            {
                Location = new System.Drawing.Point(20, 440),
                Size = new System.Drawing.Size(400, 120),
                View = View.Details,
                FullRowSelect = true,
                GridLines = false
            };
            listProximasTarefas.Columns.Add("Tarefa", 230);
            listProximasTarefas.Columns.Add("Entrega", 100);
            this.Controls.Add(listProximasTarefas);
        }

            private void AtualizarProximasTarefas(List<TarefasUserControl.TarefaInfo> tarefas)
            {
                var proximas = tarefas
                    .Where(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Em andamento", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(t => t.DataEntrega)
                    .Take(3)
                    .ToList();

                listProximasTarefas.Items.Clear();
                foreach (var t in proximas)
                {
                    var item = new ListViewItem(t.Titulo);
                    item.SubItems.Add(t.DataEntrega.ToString("dd/MM"));
                    listProximasTarefas.Items.Add(item);
                }
            }

            private List<TarefasUserControl.TarefaInfo> BuscarTarefasUsuario(int usuarioId)
            {
                var tarefas = new List<TarefasUserControl.TarefaInfo>();
                using (MySqlConnection conn = Conexao.ObterConexao())
                {
                    string sql = "SELECT id, titulo, descricao, data_entrega, status, prioridade FROM Tarefas WHERE usuario_id = @usuarioId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tarefas.Add(new TarefasUserControl.TarefaInfo
                            {
                                Id = reader.GetInt64("id"),
                                Titulo = reader.GetString("titulo"),
                                Descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? "" : reader.GetString("descricao"),
                                DataEntrega = reader.GetDateTime("data_entrega"),
                                Status = reader.GetString("status"),
                                Prioridade = reader.GetString("prioridade"),
                                UsuarioId = usuarioId
                            });
                        }
                    }

                    conn.Close();
                }
                return tarefas;
            }

        // Pie chart de prioridade (título curto)
        private void AtualizarGraficoPrioridade(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            int baixa = tarefas.Count(t => t.Prioridade.Equals("Baixa", StringComparison.OrdinalIgnoreCase));
            int media = tarefas.Count(t => t.Prioridade.Equals("Média", StringComparison.OrdinalIgnoreCase) || t.Prioridade.Equals("Media", StringComparison.OrdinalIgnoreCase));
            int alta = tarefas.Count(t => t.Prioridade.Equals("Alta", StringComparison.OrdinalIgnoreCase));

            var model = new PlotModel { Title = "Prioridade", TitleFontSize = 18 };
            var pie = new PieSeries
            {
                StrokeThickness = 2.0,
                AngleSpan = 360,
                StartAngle = 0,
                InsideLabelFormat = "",
                OutsideLabelFormat = "",
                TickHorizontalLength = 0,
                TickRadialLength = 0
            };

            pie.Slices.Add(new PieSlice("Baixa", baixa) { Fill = OxyColors.LightGreen });
            pie.Slices.Add(new PieSlice("Média", media) { Fill = OxyColors.Orange });
            pie.Slices.Add(new PieSlice("Alta", alta) { Fill = OxyColors.Red });

            model.Series.Add(pie);
            plotViewPrioridade.Model = model;

            var exporter = new OxyPlot.WindowsForms.PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_prioridade.png");
            exporter.ExportToFile(model, caminho);


            AtualizarLegendaPrioridade(baixa, media, alta);
        }

        // Pie chart de status (título curto)
        private void AtualizarGraficoStatus(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));

            var model = new PlotModel { Title = "Status", TitleFontSize = 18 };
            var pie = new PieSeries
            {
                StrokeThickness = 2.0,
                AngleSpan = 360,
                StartAngle = 0,
                InsideLabelFormat = "",
                OutsideLabelFormat = "",
                TickHorizontalLength = 0,
                TickRadialLength = 0
            };

            pie.Slices.Add(new PieSlice("Concluídas", concluidas) { Fill = OxyColors.SkyBlue });
            pie.Slices.Add(new PieSlice("Pendentes", pendentes) { Fill = OxyColors.LightPink });

            model.Series.Add(pie);
            plotViewStatus.Model = model;
            var exporter = new OxyPlot.WindowsForms.PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_status.png");
            exporter.ExportToFile(model, caminho);

        }

        private void InicializarResumo()
        {
            resumoPanel = new Panel
            {
                Location = new System.Drawing.Point(450, 330),
                Size = new System.Drawing.Size(380, 70),
                BorderStyle = BorderStyle.None
            };

            lblTotal = new Label
            {
                Location = new System.Drawing.Point(10, 10),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Text = "Total: 0"
            };
            lblConcluidas = new Label
            {
                Location = new System.Drawing.Point(130, 10),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Text = "Concluídas: 0 (0%)"
            };
            lblPendentes = new Label
            {
                Location = new System.Drawing.Point(280, 10),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Text = "Pendentes: 0"
            };

            resumoPanel.Controls.Add(lblTotal);
            resumoPanel.Controls.Add(lblConcluidas);
            resumoPanel.Controls.Add(lblPendentes);
            this.Controls.Add(resumoPanel);
        }

        private void AtualizarResumo(int total, int concluidas, int pendentes)
        {
            lblTotal.Text = $"Total: {total}";
            int perc = total > 0 ? (int)Math.Round(100.0 * concluidas / total) : 0;
            lblConcluidas.Text = $"Concluídas: {concluidas} ({perc}%)";
            lblPendentes.Text = $"Pendentes: {pendentes}";
        }

        private void InicializarGraficoBarras()
        {
            plotViewBarras = new PlotView
            {
                Location = new System.Drawing.Point(450, 420),
                Size = new System.Drawing.Size(600, 300)
            };
            this.Controls.Add(plotViewBarras);
        }

        private string BuscarNomeDoUsuario(int usuarioId)
        {
            using (MySqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "SELECT nome FROM usuarios WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return result.ToString();
                }
            }
            return "Desconhecido";
        }

        private void AtualizarGraficoBarras(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            var dados = tarefas
                .Where(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase))
                .GroupBy(t => new { t.DataEntrega.Year, t.DataEntrega.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .Select(g => new { MesAno = $"{g.Key.Month:D2}/{g.Key.Year}", Qtde = g.Count() })
                .ToList();

            var model = new PlotModel { Title = "Concluídas/mês", TitleFontSize = 18 };

            var barSeries = new ColumnSeries();

            foreach (var d in dados)
            {
                barSeries.Items.Add(new ColumnItem(d.Qtde));
            }

            var categoryAxis = new OxyPlot.Axes.CategoryAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom 
            };
            categoryAxis.Labels.AddRange(dados.Select(d => d.MesAno));

            model.Axes.Add(categoryAxis);
            model.Series.Add(barSeries);
            plotViewBarras.Model = model;
            var exporter = new OxyPlot.WindowsForms.PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_barras.png");
            exporter.ExportToFile(model, caminho);

        }
    }
}