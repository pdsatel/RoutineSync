// Importa as bibliotecas necessárias.
using System;
using System.Windows.Forms;

namespace Tcc.Dashboard
{
    // Define um UserControl para exibir as informações de perfil e um resumo das atividades do usuário.
    public partial class PerfilUserControl : UserControl
    {
        // Campo privado para armazenar o ID do usuário logado.
        private int usuarioId;

        // Construtor do UserControl, que recebe o ID do usuário como parâmetro.
        public PerfilUserControl(int usuarioId)
        {
            this.usuarioId = usuarioId; // Armazena o ID do usuário.
            InitializeComponent(); // Inicializa os componentes visuais criados no designer.
            CarregarInformacoes(); // Chama o método para buscar e exibir os dados do usuário.
        }

        // Método principal que se conecta ao banco de dados para carregar as informações do perfil e as estatísticas de tarefas.
        private void CarregarInformacoes()
        {
            // O bloco 'using' garante que a conexão com o banco de dados será fechada automaticamente.
            using (var conn = Conexao.ObterConexao())
            {
                // Primeira query: Busca os dados cadastrais do usuário na tabela 'usuarios'.
                string sqlUsuario = @"SELECT nome, email, data_nascimento, nacionalidade, profissao, telefone, data_cadastro
                                      FROM usuarios WHERE id = @id";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlUsuario, conn))
                {
                    cmd.Parameters.AddWithValue("@id", usuarioId); // Adiciona o ID do usuário como parâmetro para segurança.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Se um registro for encontrado, preenche os labels com as informações do usuário.
                        if (reader.Read())
                        {
                            lblNome.Text = $"Nome: {reader["nome"]}";
                            lblEmail.Text = $"Email: {reader["email"]}";
                            // Formata a data de nascimento para o padrão brasileiro.
                            lblNascimento.Text = $"Nascimento: {Convert.ToDateTime(reader["data_nascimento"]).ToString("dd/MM/yyyy")}";
                            lblNacionalidade.Text = $"Nacionalidade: {reader["nacionalidade"]}";
                            lblProfissao.Text = $"Profissão: {reader["profissao"]}";
                            lblTelefone.Text = $"Telefone: {reader["telefone"]}";

                            // Verifica se o campo 'data_cadastro' não é nulo antes de tentar formatá-lo.
                            if (reader["data_cadastro"] != DBNull.Value)
                                lblCadastro.Text = $"Data de Cadastro: {Convert.ToDateTime(reader["data_cadastro"]).ToString("dd/MM/yyyy")}";
                        }
                    } // O 'reader' é fechado aqui, permitindo a execução de um novo comando na mesma conexão.
                }

                // Segunda query: Busca dados das tarefas do usuário para gerar estatísticas.
                string sqlTarefas = "SELECT status, prioridade, data_entrega FROM tarefas WHERE usuario_id = @usuarioId";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlTarefas, conn))
                {
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Variáveis para calcular as estatísticas.
                        int total = 0, concluidas = 0, pendentes = 0;
                        var prioridades = new System.Collections.Generic.Dictionary<string, int>();

                        // Itera sobre cada tarefa retornada pela query.
                        while (reader.Read())
                        {
                            total++;
                            string status = reader["status"].ToString().ToLower();
                            string prioridade = reader["prioridade"].ToString();

                            // Contabiliza o status da tarefa.
                            if (status.Contains("concluida")) concluidas++;
                            else if (status.Contains("pendente") || status.Contains("andamento")) pendentes++;

                            // Agrega a contagem de uso de cada prioridade em um dicionário.
                            if (!string.IsNullOrEmpty(prioridade))
                            {
                                if (!prioridades.ContainsKey(prioridade)) prioridades[prioridade] = 0;
                                prioridades[prioridade]++;
                            }
                        }

                        // Após ler todas as tarefas, determina a prioridade mais utilizada.
                        string prioridadeMaisUsada = "N/A"; // Valor padrão.
                        if (prioridades.Count > 0)
                        {
                            // Usa LINQ para ordenar o dicionário pelo valor (contagem) em ordem decrescente e pega a primeira chave (nome da prioridade).
                            prioridadeMaisUsada = System.Linq.Enumerable.OrderByDescending(prioridades, p => p.Value).First().Key;
                        }

                        // Atualiza os labels de estatísticas com os valores calculados.
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