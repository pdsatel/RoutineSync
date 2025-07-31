// Importa as bibliotecas necessárias.
using System;
using System.Drawing;
using System.Text.RegularExpressions; // Para validação de formato com expressões regulares.
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Para interagir com o banco de dados MySQL.
using System.Security.Cryptography; // Para usar funções de hash de senha seguras.

namespace Tcc
{
    // Define a classe para o formulário de redefinição de senha.
    public partial class RedefinirSenhaFrm : Form
    {
        // Construtor do formulário.
        public RedefinirSenhaFrm()
        {
            InitializeComponent(); // Inicializa os componentes visuais criados no designer.

            // Associa o evento KeyDown dos campos de texto a um método de tratamento.
            // Isso permite que o usuário pressione Enter para navegar entre os campos.
            textBoxEmail.KeyDown += Controle_KeyDown;
            textBoxSenha.KeyDown += Controle_KeyDown;
            textBoxConfirmar.KeyDown += Controle_KeyDown;
        }

        // Evento de clique para o botão "Redefinir".
        private void btnRedefinir_Click(object sender, EventArgs e)
        {
            // Coleta os dados dos campos, removendo espaços em branco do e-mail.
            string email = textBoxEmail.Text.Trim();
            string senha = textBoxSenha.Text;
            string confirma = textBoxConfirmar.Text;

            // Realiza uma série de validações nos dados de entrada.
            if (!EmailValido(email))
            {
                MessageBox.Show("E-mail inválido.");
                return; // Interrompe a execução se a validação falhar.
            }
            if (!SenhaForte(senha))
            {
                MessageBox.Show("A senha deve ter pelo menos 8 caracteres, incluindo letra maiúscula, minúscula, número e caractere especial.");
                return;
            }
            if (senha != confirma)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }

            // Tenta atualizar a senha no banco de dados.
            try
            {
                using (var conn = Conexao.ObterConexao())
                {
                    // Comando SQL para atualizar a senha do usuário com base no e-mail.
                    string sql = "UPDATE usuarios SET senha = @senha WHERE email = @email";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // Adiciona os parâmetros de forma segura para evitar SQL Injection.
                        // A nova senha é HASHED antes de ser enviada para o banco.
                        cmd.Parameters.AddWithValue("@senha", GerarHashSenha(senha));
                        cmd.Parameters.AddWithValue("@email", email);

                        // Executa o comando e obtém o número de linhas afetadas.
                        int linhas = cmd.ExecuteNonQuery();

                        if (linhas > 0)
                        {
                            // Se uma ou mais linhas foram afetadas, a senha foi redefinida com sucesso.
                            MessageBox.Show("Senha redefinida com sucesso!");
                            this.DialogResult = DialogResult.OK; // Define o resultado do diálogo como OK.
                            this.Close(); // Fecha o formulário.
                        }
                        else
                        {
                            // Se nenhuma linha foi afetada, o e-mail não foi encontrado no banco.
                            MessageBox.Show("Usuário não encontrado.");
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao redefinir senha: " + ex.Message);
            }
        }

        // Evento de clique para o botão "Cancelar".
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Simplesmente fecha o formulário.
        }

        // --- Métodos auxiliares de validação e hash ---

        // Valida o formato do e-mail usando uma expressão regular.
        private bool EmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Valida a força da senha usando uma expressão regular.
        private bool SenhaForte(string senha)
        {
            // Exige no mínimo 8 caracteres, 1 minúscula, 1 maiúscula, 1 número e 1 caractere especial.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            return Regex.IsMatch(senha, pattern);
        }

        // Gera um hash seguro de senha usando PBKDF2 com um salt aleatório.
        // É essencial que este método seja idêntico ao usado no momento do cadastro.
        public static string GerarHashSenha(string senha)
        {
            // Cria um salt aleatório de 16 bytes.
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            // Gera o hash usando 10.000 iterações.
            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combina o salt e o hash em um único array de bytes.
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Converte o resultado para uma string Base64 para armazenamento.
            return Convert.ToBase64String(hashBytes);
        }

        // Método de tratamento de evento para permitir a navegação com a tecla Enter.
        private void Controle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Impede o som de "bip" do sistema.

                // Move o foco para o próximo controle na ordem de tabulação.
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}