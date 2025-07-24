// PerfilUserControl.cs
using System;
using System.Windows.Forms;

namespace Tcc.Dashboard
{
    public partial class PerfilUserControl : UserControl
    {
        private int usuarioId;

        public PerfilUserControl(int usuarioId)
        {
            this.usuarioId = usuarioId;
            InitializeComponent();
            CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            using (var conn = Conexao.ObterConexao())
            {
                // Buscar dados do usuário
                string sqlUsuario = "SELECT nome, email, data_cadastro FROM usuarios WHERE id = @id";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUsuario, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblNome.Text = $"Nome: {reader["nome"]}";
                            lblEmail.Text = $"Email: {reader["email"]}";
                            lblCadastro.Text = $"Data de Cadastro: {Convert.ToDateTime(reader["data_cadastro"]).ToString("dd/MM/yyyy")}";
                        }
                    }
                }

                // Buscar tarefas
                string sqlTarefas = "SELECT status, prioridade, data_entrega FROM tarefas WHERE usuario_id = @usuarioId";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlTarefas, conn))
                {
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        int total = 0, concluidas = 0, pendentes = 0;
                        var prioridades = new System.Collections.Generic.Dictionary<string, int>();

                        while (reader.Read())
                        {
                            total++;
                            string status = reader["status"].ToString().ToLower();
                            string prioridade = reader["prioridade"].ToString();

                            if (status.Contains("concluida")) concluidas++;
                            else if (status.Contains("pendente") || status.Contains("andamento")) pendentes++;

                            if (!prioridades.ContainsKey(prioridade)) prioridades[prioridade] = 0;
                            prioridades[prioridade]++;
                        }

                        string prioridadeMaisUsada = prioridades.Count > 0
                            ? System.Linq.Enumerable.FirstOrDefault(System.Linq.Enumerable.OrderByDescending(prioridades, p => p.Value)).Key
                            : "N/A";

                        lblTarefasTotal.Text = $"Total de Tarefas: {total}";
                        lblTarefasConcluidas.Text = $"Concluídas: {concluidas}";
                        lblTarefasPendentes.Text = $"Pendentes: {pendentes}";
                        lblPrioridadeMaisUsada.Text = $"Prioridade Mais Usada: {prioridadeMaisUsada}";
                    }
                }
            }
        }
    }
}
