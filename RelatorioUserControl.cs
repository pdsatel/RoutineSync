using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

using OxyPlot.Axes;

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



        public RelatorioUserControl()
        {
            InitializeComponent();
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
            var index = legendPanel.Controls.Count / 2; // Cada item tem 2 controles (box + label)
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
            }
            return tarefas;
        }

        // Pie chart de prioridade (NÃO mostra nenhum texto nas fatias)
        private void AtualizarGraficoPrioridade(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            int baixa = tarefas.Count(t => t.Prioridade.Equals("Baixa", StringComparison.OrdinalIgnoreCase));
            int media = tarefas.Count(t => t.Prioridade.Equals("Média", StringComparison.OrdinalIgnoreCase) || t.Prioridade.Equals("Media", StringComparison.OrdinalIgnoreCase));
            int alta = tarefas.Count(t => t.Prioridade.Equals("Alta", StringComparison.OrdinalIgnoreCase));

            var model = new PlotModel { Title = "Distribuição de Tarefas por Prioridade" };
            var pie = new PieSeries
            {
                StrokeThickness = 2.0,
                AngleSpan = 360,
                StartAngle = 0,
                InsideLabelFormat = "",   // <- Remove texto dentro
                OutsideLabelFormat = "",  // <- Remove texto fora
                TickHorizontalLength = 0,
                TickRadialLength = 0
            };

            pie.Slices.Add(new PieSlice("Baixa", baixa) { Fill = OxyColors.LightGreen });
            pie.Slices.Add(new PieSlice("Média", media) { Fill = OxyColors.Orange });
            pie.Slices.Add(new PieSlice("Alta", alta) { Fill = OxyColors.Red });

            model.Series.Add(pie);
            plotViewPrioridade.Model = model;

            // Chama a legenda com os valores
            AtualizarLegendaPrioridade(baixa, media, alta);
        }

        // Pie chart de status (também sem texto nas fatias)
        private void AtualizarGraficoStatus(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));

            var model = new PlotModel { Title = "Tarefas Concluídas x Pendentes" };
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
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
                Text = "Total: 0"
            };
            lblConcluidas = new Label
            {
                Location = new System.Drawing.Point(130, 10),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
                Text = "Concluídas: 0 (0%)"
            };
            lblPendentes = new Label
            {
                Location = new System.Drawing.Point(280, 10),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
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
                Size = new System.Drawing.Size(400, 200)
            };
            this.Controls.Add(plotViewBarras);
        }

        private void AtualizarGraficoBarras(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            // Agrupa por mês/ano e conta concluídas
            var dados = tarefas
                .Where(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase))
                .GroupBy(t => new { t.DataEntrega.Year, t.DataEntrega.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .Select(g => new { MesAno = $"{g.Key.Month:D2}/{g.Key.Year}", Qtde = g.Count() })
                .ToList();

            var model = new PlotModel { Title = "Tarefas concluídas por mês" };

            var barSeries = new ColumnSeries();

            foreach (var d in dados)
            {
                barSeries.Items.Add(new ColumnItem(d.Qtde));
            }

            // Adiciona apenas UM eixo de categoria, com todas as labels
            var categoryAxis = new OxyPlot.Axes.CategoryAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom
            };
            categoryAxis.Labels.AddRange(dados.Select(d => d.MesAno)); // <--- CORRETO AGORA!

            model.Axes.Add(categoryAxis);
            model.Series.Add(barSeries);
            plotViewBarras.Model = model;
        }


    }
}