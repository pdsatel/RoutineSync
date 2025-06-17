using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Tcc
{
    public partial class RedefinirSenhaFrm : Form
    {
        public RedefinirSenhaFrm()
        {
            InitializeComponent();
        }

        private void btnRedefinir_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string senha = textBoxSenha.Text;
            string confirma = textBoxConfirmar.Text;

            if (!EmailValido(email))
            {
                MessageBox.Show("E-mail inválido.");
                return;
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

            try
            {
                using (var conn = Conexao.ObterConexao())
                {
                    string sql = "UPDATE usuarios SET senha = @senha WHERE email = @email";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@senha", GerarHashSenha(senha));
                        cmd.Parameters.AddWithValue("@email", email);
                        int linhas = cmd.ExecuteNonQuery();
                        if (linhas > 0)
                        {
                            MessageBox.Show("Senha redefinida com sucesso!");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuário não encontrado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao redefinir senha: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Helpers de validação e hash ---
        private bool EmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool SenhaForte(string senha)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            return Regex.IsMatch(senha, pattern);
        }

        public static string GerarHashSenha(string senha)
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}