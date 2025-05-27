using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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

            

            this.StartPosition = FormStartPosition.CenterParent;

        }



        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string senha = textBoxSenha.Text.Trim();

            int idUsuario = ObterIdUsuario(email, senha);

            if (idUsuario > 0)
            {
                Sessao.UsuarioId = idUsuario;

                
                DashboardFrm dashboard = new DashboardFrm(idUsuario);
                dashboard.FormClosed += (s, args) => this.Close();
                this.Hide();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Email ou senha inválidos");
            }
        }

        private int ObterIdUsuario(string email, string senha)
        {
            try
            {
                using (var conn = Conexao.ObterConexao())
                {
                    string query = "SELECT id FROM usuarios WHERE email = @Email AND senha = @Senha";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result); // ID do usuário
                        }
                        else
                        {
                            return 0; // Login inválido
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar login: " + ex.Message);
                return 0;
            }
        }



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

            panelCadastro.BackColor = ColorTranslator.FromHtml("#FFFCF6");
            panelLogin.Visible = false;
            panelMenu.Visible = true;
            panelCadastro.Visible = false;

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

            btnVoltarLogin.BackColor = corPrimaria;
            btnVoltarLogin.ForeColor = Color.White;

            labelLogin.ForeColor = corTexto;

            
          

            //Cadastro


            foreach (Control ctrl in panelCadastro.Controls)
            {


                if (ctrl is Panel pnl)
                {
                    pnl.BackColor = corSecundaria;
                }

                if (ctrl is Label lbl)
                    lbl.ForeColor = corTexto;

                if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.ForeColor = corPrimaria;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }

                if (ctrl is Button btn)
                {
                    btn.BackColor = corPrimaria;
                    btn.ForeColor = Color.White;
                }

                if (ctrl is DateTimePicker dt)
                {
                    dt.CalendarMonthBackground = corPrimaria;
                    dt.CalendarForeColor = corTexto;
                    dt.BackColor = corPrimaria;
                    dt.ForeColor = corTexto;
                }
            }

            //Botões

            ArredondarControle(panelLogin, 20);
            ArredondarControle(panelMenu, 20);
            ArredondarControle(btnLogin, 20);
            ArredondarControle(panelCadastro, 20);

            ArredondarBotao(btnLogin, 20);
            ArredondarBotao(btnCadastro, 20);
            ArredondarBotao(btnEntrar, 20);
            ArredondarBotao(btnVoltarCad, 20);
            ArredondarBotao(btnCadastrar, 20);

            CentralizarPainel(panelMenu);
            CentralizarPainel(panelCadastro);
            CentralizarPainel(panelLogin);
            Enter(panelCadastro);   
        }
        private void btnAbrirCadastro_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelCadastro.Visible = true;
            panelLogin.Visible = false;
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

        private void CentralizarPainel(Control painel)
        {
            painel.Left = (this.ClientSize.Width - painel.Width) / 2;
            painel.Top = (this.ClientSize.Height - painel.Height) / 2;
        }

        private void MenuPrincipalFrm_SizeChanged(object sender, EventArgs e)
        {
            CentralizarPainel(panelMenu);
            CentralizarPainel(panelLogin);
            CentralizarPainel(panelCadastro);
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomecad.Text;
            string email = textBoxEmailcad.Text;
            string senha = textBoxSenhacad.Text;
            string confirmarsenha = textBoxConfirmarsenha.Text;
            string altura = textBoxAltura.Text;
            string peso = textBoxPeso.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmarsenha))
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
                    string query = "INSERT INTO usuarios (nome, email, senha, altura, peso, hora_dormir, hora_acordar) " +
                                   "VALUES (@nome, @email, @senha, @altura, @peso, @hora_dormir, @hora_acordar)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@altura", alturaDecimal);
                        cmd.Parameters.AddWithValue("@peso", pesoDecimal);
                        cmd.Parameters.AddWithValue("@hora_dormir", horaDormir);
                        cmd.Parameters.AddWithValue("@hora_acordar", horaAcordar);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cadastro realizado com sucesso!");

                // Limpar os campos
                textBoxNomecad.Clear();
                textBoxEmailcad.Clear();
                textBoxSenhacad.Clear();
                textBoxConfirmarsenha.Clear();
                textBoxAltura.Clear();
                textBoxPeso.Clear();
                dateTimeHoraDormir.Value = DateTime.Now;
                dateTimeHoraAcordar.Value = DateTime.Now;

                panelCadastro.Visible = false;
                panelMenu.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }
        private void btnVoltarCad_Click(object sender, EventArgs e)
        {
            panelCadastro.Visible = false;
            panelMenu.Visible = true;
        }

        private void panelCadastro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNomecad_TextChanged(object sender, EventArgs e)
        {

        }
        private void Enter(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                    txt.KeyDown += Controle_KeyDown;

                if (ctrl.HasChildren)
                    Enter(ctrl);
            }
        }

        private void AplicarFonte(Control parent, Font fonte)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Font = fonte;

                if (ctrl.HasChildren)
                {
                    AplicarFonte(ctrl, fonte);
                }
            }
        }


    }
}
