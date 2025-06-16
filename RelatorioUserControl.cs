using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Tcc
{
    public partial class RelatorioUserControl : UserControl
    {
        

        public RelatorioUserControl()
        {
            InitializeComponent();

            // Inicializa e posiciona os gráficos
            plotViewPrioridade = new PlotView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(400, 300)
            };
            plotViewStatus = new PlotView
            {
                Location = new System.Drawing.Point(450, 20),
                Size = new System.Drawing.Size(400, 300)
            };

            this.Controls.Add(plotViewPrioridade);
            this.Controls.Add(plotViewStatus);
        }

        public void AtualizarRelatorioDoBanco(int usuarioId)
        {
            var tarefas = BuscarTarefasUsuario(usuarioId);
            AtualizarGraficoPrioridade(tarefas);
            AtualizarGraficoStatus(tarefas);
            MessageBox.Show(tarefas.Count.ToString());
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

        // Pie chart de prioridade
        private void AtualizarGraficoPrioridade(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            int baixa = tarefas.Count(t => t.Prioridade.Equals("Baixa", StringComparison.OrdinalIgnoreCase));
            int media = tarefas.Count(t => t.Prioridade.Equals("Média", StringComparison.OrdinalIgnoreCase) || t.Prioridade.Equals("Media", StringComparison.OrdinalIgnoreCase));
            int alta = tarefas.Count(t => t.Prioridade.Equals("Alta", StringComparison.OrdinalIgnoreCase));

            var model = new PlotModel { Title = "Distribuição de Tarefas por Prioridade" };
            var pie = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            pie.Slices.Add(new PieSlice("Baixa", baixa) { Fill = OxyColors.LightGreen });
            pie.Slices.Add(new PieSlice("Média", media) { Fill = OxyColors.Orange });
            pie.Slices.Add(new PieSlice("Alta", alta) { Fill = OxyColors.Red });

            model.Series.Add(pie);
            plotViewPrioridade.Model = model;
        }

        // Pie chart de status
        private void AtualizarGraficoStatus(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            int concluidas = tarefas.Count(t => t.Status.Equals("Concluída", StringComparison.OrdinalIgnoreCase) || t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            int pendentes = tarefas.Count(t => t.Status.Equals("Pendente", StringComparison.OrdinalIgnoreCase));

            var model = new PlotModel { Title = "Tarefas Concluídas x Pendentes" };
            var pie = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            pie.Slices.Add(new PieSlice("Concluídas", concluidas) { Fill = OxyColors.SkyBlue });
            pie.Slices.Add(new PieSlice("Pendentes", pendentes) { Fill = OxyColors.LightPink });

            model.Series.Add(pie);
            plotViewStatus.Model = model;
        }
    }
}