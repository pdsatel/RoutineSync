using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace Tcc
{
    public partial class RelatorioUserControl : UserControl
    {
        public RelatorioUserControl()
        {
            InitializeComponent();
            



        }

        // Chame este método para atualizar o relatório para um usuário específico
        public void AtualizarRelatorioDoBanco(int usuarioId)
        {
            // Opcional: debug
            // MessageBox.Show("Carregando relatório!"); 

            var tarefas = BuscarTarefasUsuario(usuarioId);
            AtualizarGraficoPrioridade(tarefas);
            AtualizarGraficoStatus(tarefas);
            MessageBox.Show(tarefas.Count.ToString());
        }

        // Busca as tarefas desse usuário diretamente do banco
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

        // Gráfico de tarefas por prioridade
        private void AtualizarGraficoPrioridade(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            chart1.Series.Clear();
            var series = new Series("Prioridade")
            {
                ChartType = SeriesChartType.Pie
            };

            int baixa = tarefas.Count(t => t.Prioridade == "Baixa");
            int media = tarefas.Count(t => t.Prioridade == "Média" || t.Prioridade == "Media");
            int alta = tarefas.Count(t => t.Prioridade == "Alta");

            series.Points.AddXY("Baixa", baixa);
            series.Points.AddXY("Média", media);
            series.Points.AddXY("Alta", alta);

           
            chart1.Legends[0].Enabled = true;
            chart1.Titles.Clear();
            chart1.Titles.Add("Distribuição de Tarefas por Prioridade");
            chart1.Series.Add(series);

        }

        // Gráfico de tarefas por status (concluída x pendente)
        private void AtualizarGraficoStatus(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            chart2.Series.Clear();
            var series = new Series("Status")
            {
                ChartType = SeriesChartType.Pie
            };

            int concluidas = tarefas.Count(t => t.Status.Equals("concluida", StringComparison.OrdinalIgnoreCase));
            int pendentes = tarefas.Count(t => t.Status.Equals("pendente", StringComparison.OrdinalIgnoreCase));

            series.Points.AddXY("Concluídas", concluidas);
            series.Points.AddXY("Pendentes", pendentes);

            
            chart2.Legends[0].Enabled = true;
            chart2.Titles.Clear();
            chart2.Titles.Add("Tarefas Concluídas x Pendentes");
            chart2.Series.Add(series);
        }
    }
}