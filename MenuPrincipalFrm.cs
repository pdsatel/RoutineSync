using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;


namespace Tcc
{
    public partial class MenuPrincipalFrm : Form
    {

        Color corPrimaria = ColorTranslator.FromHtml("#202E39");
        Color corSecundaria = ColorTranslator.FromHtml("#FFFCF6");
        Color corTexto = ColorTranslator.FromHtml("#333333");
        Color corApoio = ColorTranslator.FromHtml("#4A90E2");
        Color corSuporte = ColorTranslator.FromHtml("#7ED321");


        public MenuPrincipalFrm()
        {
            InitializeComponent();

            this.SizeChanged += new EventHandler(MenuPrincipalFrm_SizeChanged);
            btnLogin.Click += btnLogin_Click;
            btnCadastro.Click += BtnCadastro_Click;
            btnEntrar.Click += btnEntrar_Click;

            this.StartPosition = FormStartPosition.CenterParent;

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

                MessageBox.Show("Login efetudado com sucesso");
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


      

// Exemplo: dentro do Form_Load ou após InitializeComponent
    private void ArredondarBotao(Button btn, int raio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }
    private void Controle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
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


        private void ArredondarControle(Control controle, int raio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, raio, raio), 180, 90);
            path.AddArc(new Rectangle(controle.Width - raio, 0, raio, raio), 270, 90);
            path.AddArc(new Rectangle(controle.Width - raio, controle.Height - raio, raio, raio), 0, 90);
            path.AddArc(new Rectangle(0, controle.Height - raio, raio, raio), 90, 90);
            path.CloseFigure();

            controle.Region = new Region(path);
        }

        private void MenuPrincipalFrm_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelMenu.Visible = true;

            btnLogin.Visible = true;
            btnCadastro.Visible = true;
            labelTitulo.Visible = true;


            textBoxEmail.KeyDown += Controle_KeyDown;
            textBoxSenha.KeyDown += Controle_KeyDown;
            btnEntrar.KeyDown += Controle_KeyDown;

            // Foco inicial no campo de email
            textBoxEmail.Focus();

            this.BackColor = corPrimaria;
            panelMenu.BackColor = corSecundaria;
            panelLogin.BackColor = corSecundaria;

            labelTitulo.ForeColor = corTexto;

            btnLogin.BackColor = corPrimaria;
            btnLogin.ForeColor = Color.White;
            btnCadastro.BackColor = corPrimaria;
            btnCadastro.ForeColor = Color.White;

            btnEntrar.BackColor = corPrimaria;
            btnEntrar.ForeColor = Color.White;

            ArredondarControle(panelLogin, 20);
            ArredondarControle(panelMenu, 20);
            ArredondarControle(btnLogin, 20);

            ArredondarBotao(btnLogin, 20);
            ArredondarBotao(btnCadastro, 20);
            ArredondarBotao(btnEntrar, 20);

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

        private void MenuPrincipalFrm_SizeChanged(object sender, EventArgs e)
        {
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );
        }

    }
}
