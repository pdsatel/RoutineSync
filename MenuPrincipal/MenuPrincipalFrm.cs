using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace Tcc
{
    public partial class MenuPrincipalFrm : Form
    {

        Color corPrimaria = ColorTranslator.FromHtml("#202E39");
        Color corSecundaria = ColorTranslator.FromHtml("#FFFCF6");
        Color corTexto = ColorTranslator.FromHtml("#333333");
        Color corApoio = ColorTranslator.FromHtml("#4A90E2");
        Color corSuporte = ColorTranslator.FromHtml("#7ED321");
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool senhaCadastroVisivel = false;
        private bool senhaCadastroConfirmVisivel = false;
        private bool senhaLoginVisivel = false;



        public MenuPrincipalFrm()
        {
            InitializeComponent();

            this.Shown += MenuPrincipalFrm_Shown;
            this.SizeChanged += new EventHandler(MenuPrincipalFrm_SizeChanged);
           
            this.Load += new EventHandler(MenuPrincipalFrm_Load);
            textBoxEmailcad.Validating += textBoxEmailcad_Validating;
            textBoxSenhacad.Validating += textBoxSenhacad_Validating;
            textBoxConfirmarsenha.Validating += textBoxConfirmarsenha_Validating;
            pictureBoxOlhoSenhaCadastro.Click += pictureBoxOlhoSenhaCadastro_Click;
            pictureBoxOlhoConfirmarSenha.Click += pictureBoxOlhoConfirmarSenha_Click;
            pictureBoxOlhoLogin.Click += pictureBoxOlhoLogin_Click;

            // Começa ocultando as senhas
            textBoxSenhacad.UseSystemPasswordChar = false;
            textBoxConfirmarsenha.UseSystemPasswordChar = false;
            textBoxSenha.UseSystemPasswordChar = false;


            pictureBoxOlhoSenhaCadastro.Image = Properties.Resources.eye_close;
            pictureBoxOlhoConfirmarSenha.Image = Properties.Resources.eye_close;
            pictureBoxOlhoLogin.Image = Properties.Resources.eye_close;


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
                    string query = "SELECT id, senha FROM usuarios WHERE email = @Email";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string hashSalva = reader.GetString("senha");

                                if (ValidarSenha(senha, hashSalva))
                                    return id;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar login: " + ex.Message);
            }
            return 0;
        }

        public static bool ValidarSenha(string senha, string hashSalvo)
        {
            byte[] hashBytes = Convert.FromBase64String(hashSalvo);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }
        private void textBoxEmailcad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!EmailValido(textBoxEmailcad.Text))
            {
                errorProvider.SetError(textBoxEmailcad, "E-mail inválido.");
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(textBoxEmailcad, "");
            }
        }

        private void textBoxSenhacad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!SenhaForte(textBoxSenhacad.Text))
            {
                errorProvider.SetError(textBoxSenhacad, "Senha fraca. Use letras maiúsculas, minúsculas, número e especial.");
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(textBoxSenhacad, "");
            }
        }

        private void textBoxConfirmarsenha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxSenhacad.Text != textBoxConfirmarsenha.Text)
            {
                errorProvider.SetError(textBoxConfirmarsenha, "As senhas não coincidem.");
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(textBoxConfirmarsenha, "");
            }
        }

        private bool senhaVisivel = false;

        private void pictureBoxOlhoSenhaCadastro_Click(object sender, EventArgs e)
        {
            senhaCadastroVisivel = !senhaCadastroVisivel;
            textBoxSenhacad.UseSystemPasswordChar = !senhaCadastroVisivel;
            pictureBoxOlhoSenhaCadastro.Image = senhaCadastroVisivel ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        private void pictureBoxOlhoConfirmarSenha_Click(object sender, EventArgs e)
        {
            senhaCadastroConfirmVisivel = !senhaCadastroConfirmVisivel;
            textBoxConfirmarsenha.UseSystemPasswordChar = !senhaCadastroConfirmVisivel;
            pictureBoxOlhoConfirmarSenha.Image = senhaCadastroConfirmVisivel ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        private void pictureBoxOlhoLogin_Click(object sender, EventArgs e)
        {
            senhaLoginVisivel = !senhaLoginVisivel;
            textBoxSenha.UseSystemPasswordChar = !senhaLoginVisivel;
            pictureBoxOlhoLogin.Image = senhaLoginVisivel ? Properties.Resources.eye_open : Properties.Resources.eye_close;
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

            
                // Ajusta cores e posição inicial
            this.BackColor = corPrimaria;

            panelCadastro.BackColor = corSecundaria;
            panelLogin.BackColor = corSecundaria;

            panelLogin.Visible = true;
            panelCadastro.Visible = false;
            

                // Posicionamento fixo à esquerda
            panelLogin.Location = new Point(0, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);

                // Foco no e-mail
                textBoxEmail.Focus();

               // Cores
            labelLogin.ForeColor = corTexto;
            btnEntrar.BackColor = corPrimaria;
            btnEntrar.ForeColor = Color.White;
                
            labelLogin.ForeColor = corTexto;


            labelTitulo.Left = (this.ClientSize.Width - labelTitulo.Width) / 2;

            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;

            panelCadastro.Left = (this.ClientSize.Width - panelCadastro.Width) / 2;
            panelCadastro.Top = (this.ClientSize.Height - panelCadastro.Height) / 2;
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
           
            
            ArredondarBotao(btnVoltarCad, 20);
            ArredondarBotao(btnCadastrar, 20);


           CentralizarLogin ();
            CentralizarCadastro();
            Enter(panelCadastro);
            Enter(panelLogin);
        }
        private void btnAbrirCadastro_Click(object sender, EventArgs e)
        {

            
            panelCadastro.Visible = true;
            panelLogin.Visible = false;
            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        { 
            panelCadastro.Visible = false;
            panelLogin.Visible = true;
            panelLogin.Location = new Point(this.ClientSize.Width / 2, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);

        }
        private void btnVoltarlogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CentralizarLogin()
        {
            int panelWidth = panelLogin.Width;

            int centralX = (panelWidth - 300) / 2;

            labelLogin.Left = (panelWidth - labelLogin.Width) / 2;

            labelEmail.Left = centralX;
            textBoxEmail.Left = centralX;

            labelSenha.Left = centralX;
            textBoxSenha.Left = centralX;

            btnEntrar.Left = centralX + 100;

            linkRegistrar.Left = centralX;
        }


        private void MenuPrincipalFrm_SizeChanged(object sender, EventArgs e)
        {
            if (panelLogin.Visible)
            {
                panelLogin.Location = new Point(0, 0);
                panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
            }
            
            else if (panelCadastro.Visible)
            {
                panelCadastro.Location = new Point(0, 0);
                panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
            }
            CentralizarLogin();
            CentralizarCadastro();
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            

            if(!ValidateChildren())
                return;
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
                        cmd.Parameters.AddWithValue("@senha", GerarHashSenha(senha));
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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
            panelLogin.Visible = true; 
        }
        private void btnVoltarCad_Click(object sender, EventArgs e)
        {
            panelCadastro.Visible = false;
            panelLogin.Visible = true;
            panelLogin.Location = new Point(0, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);



        }
        private bool EmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private bool SenhaForte(string senha)
        {
            // Pelo menos 8 caracteres, 1 minúscula, 1 maiúscula, 1 número, 1 especial
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            return Regex.IsMatch(senha, pattern);
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
        private void linkRegistrar_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelCadastro.Visible = true;
            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
        }

        private void linkEsqueciSenha_Click(object sender, EventArgs e)
        {
            // Aqui você pode abrir um novo formulário para redefinição
            var frm = new RedefinirSenhaFrm();
            frm.ShowDialog();
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
        private void MenuPrincipalFrm_Shown(object sender, EventArgs e)
        {
            panelLogin.Location = new Point(0, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);

            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);


            int larguraCampo = 280;
            int alturaCampo = 40;

            // Redimensiona textboxes
            

            // Redimensiona botão Entrar
            btnEntrar.Width = larguraCampo;
            btnEntrar.Height = alturaCampo;

            // Ajusta fonte
            Font fonteMaior = new Font("Segoe UI", 12F, FontStyle.Regular);
            textBoxEmail.Font = fonteMaior;
            textBoxSenha.Font = fonteMaior;
           

            // Posiciona verticalmente
            int centroX = (panelLogin.Width - larguraCampo) / 2;
            int startY = 100;

        }

        private void CentralizarCadastro()
        {
            int panelWidth = panelCadastro.Width;
            int centralX = (panelWidth - 300) / 2;

            labelCadastro.Left = (panelWidth - labelCadastro.Width) / 2;

            textBoxNomecad.Left = centralX;
            textBoxEmailcad.Left = centralX;
            textBoxSenhacad.Left = centralX;
            textBoxConfirmarsenha.Left = centralX;
            textBoxAltura.Left = centralX;
            textBoxPeso.Left = centralX;
            dateTimeHoraDormir.Left = centralX;
            dateTimeHoraAcordar.Left = centralX;

            btnCadastrar.Left = centralX;
            btnVoltarCad.Left = centralX + 110;
        }


       

// Gera hash seguro da senha (PBKDF2)
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

