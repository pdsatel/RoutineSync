// Importa as bibliotecas necessárias para a aplicação.
using System;
using System.Collections.Generic;
using System.Linq; // Essencial para manipulação de coleções de dados (ex: Count, Where, GroupBy).
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Para conexão com o banco de dados MySQL.
using OxyPlot; // Biblioteca principal para criação de gráficos.
using OxyPlot.Series; // Contém os tipos de gráficos (ex: PieSeries, ColumnSeries).
using OxyPlot.WindowsForms; // Adaptador para usar OxyPlot em Windows Forms.
using OxyPlot.Axes; // Para configurar os eixos dos gráficos.
using iTextSharp.text; // Biblioteca principal para criação de PDFs.
using iTextSharp.text.pdf; // Funcionalidades específicas para PDF.
using System.IO; // Para manipulação de arquivos e diretórios (ex: Path, FileStream).

namespace Tcc
{
    // Define um UserControl para exibir um relatório consolidado das tarefas do usuário.
    public partial class RelatorioUserControl : UserControl
    {
        // Campos privados para os componentes da interface, que são criados e configurados via código.
        private Panel legendPanel; // Painel para a legenda customizada dos gráficos.
        private Panel resumoPanel; // Painel para exibir estatísticas rápidas.
        private Label lblTotal; // Label para o total de tarefas.
        private Label lblConcluidas; // Label para tarefas concluídas.
        private Label lblPendentes; // Label para tarefas pendentes.
        private ListView listProximasTarefas; // Lista para as próximas tarefas a vencer.
        private PlotView plotViewBarras; // Componente para exibir o gráfico de barras.
        private Button btnExportarPDF; // Botão para exportar o relatório.
        private int usuarioID; // Armazena o ID do usuário logado.

        // Labels para os títulos dos gráficos.
        private Label lblTituloPrioridade;
        private Label lblTituloStatus;
        private Label lblTituloBarras;

        // Construtor do UserControl.
        public RelatorioUserControl(int usuarioID)
        {
            this.usuarioID = usuarioID; // Armazena o ID do usuário.
            InitializeComponent(); // Inicializa componentes do designer (se houver).

            // Chama métodos para criar e configurar a interface do relatório de forma programática.
            InicializarTítulos();
            InicializarResumo();
            InicializarProximasTarefas();
            InicializarGraficoBarras();

            // Inicializa o painel de legendas.
            legendPanel = new Panel
            {
                Location = new System.Drawing.Point(20, 330),
                Size = new System.Drawing.Size(400, 100),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(legendPanel);

            // Inicializa o botão de exportação para PDF.
            btnExportarPDF = new Button
            {
                Text = "Salvar em PDF",
                Location = new System.Drawing.Point(20, 580),
                Size = new System.Drawing.Size(180, 70)
            };
            btnExportarPDF.Click += BtnExportarPDF_Click; // Associa o evento de clique.
            this.Controls.Add(btnExportarPDF);
        }

        // Evento de clique para o botão de exportar para PDF.
        private void BtnExportarPDF_Click(object sender, EventArgs e)
        {
            // Abre uma caixa de diálogo para o usuário escolher onde salvar o arquivo PDF.
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "RelatorioTarefas.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Busca os dados mais recentes do banco.
                    var tarefas = BuscarTarefasUsuario(this.usuarioID);

                    // Cria um novo documento PDF no tamanho A4.
                    Document doc = new Document(iTextSharp.text.PageSize.A4);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    // Adiciona um cabeçalho com informações do projeto, usuário e data de geração.
                    string nomeUsuario = BuscarNomeDoUsuario(usuarioID);
                    string nomeProjeto = "RoutineSync";
                    string dataGeracao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    iTextSharp.text.Font fontCabecalho = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                    Paragraph cabecalho = new Paragraph($"{nomeProjeto} - Usuário: {nomeUsuario} - Gerado em: {dataGeracao}", fontCabecalho);
                    cabecalho.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    doc.Add(cabecalho);
                    doc.Add(new Paragraph(" "));

                    // Adiciona a logo do aplicativo, se o arquivo existir.
                    string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.png");
                    if (File.Exists(logoPath))
                    {
                        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                        logo.ScaleAbsolute(120f, 120f);
                        logo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        doc.Add(logo);
                        doc.Add(new Paragraph(" "));
                    }

                    // Adiciona o título e um resumo estatístico das tarefas.
                    doc.Add(new Paragraph("Relatório de Tarefas"));
                    doc.Add(new Paragraph(" "));
                    int total = tarefas.Count;
                    int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
                    int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));
                    doc.Add(new Paragraph($"Total: {total}   Concluídas: {concluidas}   Pendentes: {pendentes}"));
                    doc.Add(new Paragraph(" "));

                    // Cria e preenche uma tabela com os detalhes de todas as tarefas.
                    PdfPTable tabela = new PdfPTable(5); // 5 colunas.
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

                    // Localiza e adiciona as imagens dos gráficos que foram salvas previamente.
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
                        // Repete o processo para o gráfico de status.
                    }
                    if (File.Exists(graficoBarrasPath))
                    {
                        // Repete o processo para o gráfico de barras.
                    }

                    doc.Close(); // Fecha e salva o documento PDF.
                    MessageBox.Show("PDF gerado com sucesso!", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar PDF: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para criar e posicionar os títulos dos diferentes blocos do relatório.
        private void InicializarTítulos()
        {
            lblTituloPrioridade = new Label { Text = "Distribuição de Tarefas por Prioridade", Location = new System.Drawing.Point(20, 10), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold) };
            this.Controls.Add(lblTituloPrioridade);
            lblTituloStatus = new Label { Text = "Tarefas Concluídas x Pendentes", Location = new System.Drawing.Point(420, 10), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold) };
            this.Controls.Add(lblTituloStatus);
            lblTituloBarras = new Label { Text = "Tarefas concluídas por mês", Location = new System.Drawing.Point(450, 390), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold) };
            this.Controls.Add(lblTituloBarras);
        }

        // Atualiza a legenda do gráfico de prioridades com valores e percentuais.
        private void AtualizarLegendaPrioridade(int baixa, int media, int alta)
        {
            legendPanel.Controls.Clear();
            int total = baixa + media + alta;
            AddLegendaItem($"Baixa ({baixa} - {Percent(baixa, total)}%)", OxyColors.LightGreen);
            AddLegendaItem($"Média ({media} - {Percent(media, total)}%)", OxyColors.Orange);
            AddLegendaItem($"Alta ({alta} - {Percent(alta, total)}%)", OxyColors.Red);
        }

        // Função auxiliar para calcular porcentagens.
        private int Percent(int valor, int total)
        {
            if (total == 0) return 0;
            return (int)Math.Round((double)valor * 100 / total);
        }

        // Adiciona um item (caixa de cor e texto) à legenda customizada.
        private void AddLegendaItem(string texto, OxyColor cor)
        {
            var index = legendPanel.Controls.Count / 2;
            var colorBox = new Panel { BackColor = System.Drawing.Color.FromArgb(cor.A, cor.R, cor.G, cor.B), Size = new System.Drawing.Size(20, 20), Location = new System.Drawing.Point(10, 10 + index * 30) };
            var lbl = new Label { Text = texto, Location = new System.Drawing.Point(40, 10 + index * 30 + 2), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10) };
            legendPanel.Controls.Add(colorBox);
            legendPanel.Controls.Add(lbl);
        }

        // Método público para atualizar todos os dados e gráficos do relatório.
        public void AtualizarRelatorioDoBanco(int usuarioId)
        {
            var tarefas = BuscarTarefasUsuario(usuarioId);

            // Atualiza os gráficos de pizza.
            AtualizarGraficoPrioridade(tarefas);
            AtualizarGraficoStatus(tarefas);

            // Calcula as estatísticas.
            int total = tarefas.Count;
            int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));

            // Atualiza os componentes da UI com os novos dados.
            AtualizarResumo(total, concluidas, pendentes);
            AtualizarProximasTarefas(tarefas);
            AtualizarGraficoBarras(tarefas);
        }

        // Inicializa o ListView que mostra as próximas tarefas.
        private void InicializarProximasTarefas()
        {
            listProximasTarefas = new ListView { Location = new System.Drawing.Point(20, 440), Size = new System.Drawing.Size(400, 120), View = View.Details, FullRowSelect = true, GridLines = false };
            listProximasTarefas.Columns.Add("Tarefa", 230);
            listProximasTarefas.Columns.Add("Entrega", 100);
            this.Controls.Add(listProximasTarefas);
        }

        // Atualiza a lista de próximas tarefas.
        private void AtualizarProximasTarefas(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            // Filtra as 3 tarefas pendentes ou em andamento com a data de entrega mais próxima.
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

        // Busca todas as tarefas do usuário no banco de dados.
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

        // Atualiza o gráfico de pizza de prioridades.
        private void AtualizarGraficoPrioridade(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            // Conta as tarefas por prioridade.
            int baixa = tarefas.Count(t => t.Prioridade.Equals("Baixa", StringComparison.OrdinalIgnoreCase));
            int media = tarefas.Count(t => t.Prioridade.Equals("Média", StringComparison.OrdinalIgnoreCase) || t.Prioridade.Equals("Media", StringComparison.OrdinalIgnoreCase));
            int alta = tarefas.Count(t => t.Prioridade.Equals("Alta", StringComparison.OrdinalIgnoreCase));

            // Configura o modelo do gráfico.
            var model = new PlotModel { Title = "Prioridade", TitleFontSize = 18 };
            var pie = new PieSeries { StrokeThickness = 2.0, InsideLabelFormat = "", OutsideLabelFormat = "" };

            // Adiciona as fatias ao gráfico com suas respectivas cores.
            pie.Slices.Add(new PieSlice("Baixa", baixa) { Fill = OxyColors.LightGreen });
            pie.Slices.Add(new PieSlice("Média", media) { Fill = OxyColors.Orange });
            pie.Slices.Add(new PieSlice("Alta", alta) { Fill = OxyColors.Red });

            model.Series.Add(pie);
            plotViewPrioridade.Model = model;

            // Exporta o gráfico como uma imagem PNG para ser usada no PDF.
            var exporter = new OxyPlot.WindowsForms.PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_prioridade.png");
            exporter.ExportToFile(model, caminho);

            // Atualiza a legenda customizada.
            AtualizarLegendaPrioridade(baixa, media, alta);
        }

        // Atualiza o gráfico de pizza de status.
        private void AtualizarGraficoStatus(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));

            var model = new PlotModel { Title = "Status", TitleFontSize = 18 };
            var pie = new PieSeries { StrokeThickness = 2.0, InsideLabelFormat = "", OutsideLabelFormat = "" };

            pie.Slices.Add(new PieSlice("Concluídas", concluidas) { Fill = OxyColors.SkyBlue });
            pie.Slices.Add(new PieSlice("Pendentes", pendentes) { Fill = OxyColors.LightPink });

            model.Series.Add(pie);
            plotViewStatus.Model = model;

            // Exporta o gráfico como imagem.
            var exporter = new OxyPlot.WindowsForms.PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_status.png");
            exporter.ExportToFile(model, caminho);
        }

        // Inicializa o painel de resumo com seus labels.
        private void InicializarResumo()
        {
            resumoPanel = new Panel { Location = new System.Drawing.Point(450, 330), Size = new System.Drawing.Size(380, 70), BorderStyle = BorderStyle.None };
            lblTotal = new Label { Location = new System.Drawing.Point(10, 10), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold), Text = "Total: 0" };
            lblConcluidas = new Label { Location = new System.Drawing.Point(130, 10), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold), Text = "Concluídas: 0 (0%)" };
            lblPendentes = new Label { Location = new System.Drawing.Point(280, 10), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold), Text = "Pendentes: 0" };
            resumoPanel.Controls.Add(lblTotal);
            resumoPanel.Controls.Add(lblConcluidas);
            resumoPanel.Controls.Add(lblPendentes);
            this.Controls.Add(resumoPanel);
        }

        // Atualiza os textos dos labels no painel de resumo.
        private void AtualizarResumo(int total, int concluidas, int pendentes)
        {
            lblTotal.Text = $"Total: {total}";
            int perc = total > 0 ? (int)Math.Round(100.0 * concluidas / total) : 0;
            lblConcluidas.Text = $"Concluídas: {concluidas} ({perc}%)";
            lblPendentes.Text = $"Pendentes: {pendentes}";
        }

        // Inicializa o componente PlotView para o gráfico de barras.
        private void InicializarGraficoBarras()
        {
            plotViewBarras = new PlotView { Location = new System.Drawing.Point(450, 420), Size = new System.Drawing.Size(600, 300) };
            this.Controls.Add(plotViewBarras);
        }

        // Busca o nome do usuário no banco de dados.
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

        // Atualiza o gráfico de barras com a quantidade de tarefas concluídas por mês.
        private void AtualizarGraficoBarras(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            // Agrupa as tarefas concluídas por ano e mês e conta a quantidade.
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

            // Configura o eixo X (categorias) com os rótulos de "Mês/Ano".
            var categoryAxis = new OxyPlot.Axes.CategoryAxis { Position = OxyPlot.Axes.AxisPosition.Bottom };
            categoryAxis.Labels.AddRange(dados.Select(d => d.MesAno));

            model.Axes.Add(categoryAxis);
            model.Series.Add(barSeries);
            plotViewBarras.Model = model;

            // Exporta o gráfico como imagem para o PDF.
            var exporter = new OxyPlot.WindowsForms.PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "grafico_barras.png");
            exporter.ExportToFile(model, caminho);
        }
    }
}