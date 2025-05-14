using MySql.Data.MySqlClient;



namespace Tcc
{
    public partial class MenuPrincipalFrm : Form
    {
        public MenuPrincipalFrm()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
            btnCadastro.Click += BtnCadastro_Click;
            btnEntrar.Click += btnEntrar_Click;

        }

        private void BtnCadastro_Click(object? sender, EventArgs e)
        {
            CadastroFrm frm = new CadastroFrm();
            frm.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string senha = textBoxSenha.Text.Trim();

            if (VerificarLogin(email, senha))
            {
                panelLogin.Visible = false;
                panelMenu.Visible = true;

            }
            else
            {
                MessageBox.Show("Email ou senha invalidos");
            }

        }
        private bool VerificarLogin(string email, string senha)
        {


            try
            {
                using (var conn = Conexao.ObterConexao())
                {
                    string query = "SELECT COUNT(*) FROM usuarios WHERE email = @Email AND senha = @Senha";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar login: " + ex.Message);
                return false;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            CadastroFrm cadastro = new CadastroFrm();
            cadastro.ShowDialog();
        }

        private void MenuPrincipalFrm_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelMenu.Visible = true;

            btnLogin.Visible = true;
            btnCadastro.Visible = true;
            labelTitulo.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelMenu.Visible = false;

        }
        private void btnVoltarlogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelMenu.Visible = true;
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
