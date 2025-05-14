using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tcc
{
    public partial class CadastroFrm : Form
    {

        Color corPrimaria = ColorTranslator.FromHtml("#202E39");
        Color corSecundaria = ColorTranslator.FromHtml("#FFFCF6");
        Color corTexto = ColorTranslator.FromHtml("#333333");
        Color corApoio = ColorTranslator.FromHtml("#4A90E2");
        Color corSuporte = ColorTranslator.FromHtml("#7ED321");
        public CadastroFrm()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNome.Text;
            string email = textBoxEmail.Text;
            string senha = textBoxSenha.Text;
            string confirmarsenha = textBoxConfirmarsenha.Text;
            string altura = textBoxAltura.Text;
            string peso = textBoxPeso.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmarsenha))
            {
                MessageBox.Show("Por favor, preencha todos os campos");
                return;
            }

            if (senha != confirmarsenha)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }

            if (!decimal.TryParse(altura, out decimal alturaDecimal) || !decimal.TryParse(peso, out decimal pesoDecimal))
            {
                MessageBox.Show("Altura e peso devem ser números válidos.");
                return;
            }

            TimeSpan horaDormir = dateTimeHoraDormir.Value.TimeOfDay;
            TimeSpan horaAcordar = dateTimeHoraAcordar.Value.TimeOfDay;

            try
            {
                using (var conn = Conexao.ObterConexao())
                {
                    string query = "INSERT INTO Usuarios (nome, email, senha, altura, peso, hora_dormir, hora_acordar) " +
                                   "VALUES (@nome, @email, @senha, @altura, @peso, @hora_dormir, @hora_acordar)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha); // Aqui pode usar hash futuramente
                        cmd.Parameters.AddWithValue("@altura", alturaDecimal);
                        cmd.Parameters.AddWithValue("@peso", pesoDecimal);
                        cmd.Parameters.AddWithValue("@hora_dormir", horaDormir);
                        cmd.Parameters.AddWithValue("@hora_acordar", horaAcordar);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cadastro realizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }

        }
        private void btnVoltarCad_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void Controle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }
        private void textBoxConfirmarsenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void CadastroFrm_Load(object sender, EventArgs e)
        {
            this.BackColor = corPrimaria;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = corSecundaria;
                }
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = corSecundaria;
                    txt.ForeColor = corApoio;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                if (ctrl is Button btn)
                {
                    btn.BackColor = corPrimaria;
                    btn.ForeColor = Color.White;
                }
                if (ctrl is DateTimePicker dt)
                {
                    dt.CalendarMonthBackground = corSecundaria;
                    dt.CalendarForeColor = corTexto;
                    dt.BackColor = corSecundaria;
                    dt.ForeColor = corTexto;
                }
            }
        }

    }
}
