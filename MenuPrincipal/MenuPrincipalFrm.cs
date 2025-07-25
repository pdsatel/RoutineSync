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
        private bool senhaCadastroVisivel = true;
        private bool senhaCadastroConfirmVisivel = true;
        private bool senhaLoginVisivel = true;

        private Label labelNascimento;
        private DateTimePicker dateTimeNascimento;
        private Label labelNacionalidade;
        private TextBox textBoxNacionalidade;
        private Label labelProfissao;
        private TextBox textBoxProfissao;
        private Label labelTelefone;
        private TextBox textBoxTelefone;



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
            textBoxSenhacad.UseSystemPasswordChar = true;
            textBoxConfirmarsenha.UseSystemPasswordChar = true;
            textBoxSenha.UseSystemPasswordChar = true;


            pictureBoxOlhoSenhaCadastro.Image = Properties.Resources.eye_close;
            pictureBoxOlhoConfirmarSenha.Image = Properties.Resources.eye_close;
            pictureBoxOlhoLogin.Image = Properties.Resources.eye_close;

            labelNascimento = new Label();
            dateTimeNascimento = new DateTimePicker();
            labelNacionalidade = new Label();
            textBoxNacionalidade = new TextBox();
            labelProfissao = new Label();
            textBoxProfissao = new TextBox();
            labelTelefone = new Label();
            textBoxTelefone = new TextBox();

            panelCadastro.Controls.Add(labelNascimento);
            panelCadastro.Controls.Add(dateTimeNascimento);
            panelCadastro.Controls.Add(labelNacionalidade);
            panelCadastro.Controls.Add(textBoxNacionalidade);
            panelCadastro.Controls.Add(labelProfissao);
            panelCadastro.Controls.Add(textBoxProfissao);
            panelCadastro.Controls.Add(labelTelefone);
            panelCadastro.Controls.Add(textBoxTelefone);





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
                    string query = "SELECT id, senha FROM usuarios WHERE email = Email";
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
            int larguraCampo = 300;
            int alturaCampo = 36;
            int espacoVertical = 15;

            int panelWidth = panelLogin.Width;
            int centralX = (panelWidth - larguraCampo) / 2;

            // Label Login
            labelLogin.Top = 40;
            labelLogin.Left = (panelWidth - labelLogin.Width) / 2;

            // Email
            labelEmail.Top = labelLogin.Bottom + 30;
            labelEmail.Left = centralX;
            textBoxEmail.Top = labelEmail.Bottom + 2;
            textBoxEmail.Left = centralX;
            textBoxEmail.Width = larguraCampo;
            textBoxEmail.Height = alturaCampo;

            // Senha
            labelSenha.Top = textBoxEmail.Bottom + espacoVertical;
            labelSenha.Left = centralX;
            textBoxSenha.Top = labelSenha.Bottom + 2;
            textBoxSenha.Left = centralX;
            textBoxSenha.Width = larguraCampo;
            textBoxSenha.Height = alturaCampo;

            // Olho da senha
            pictureBoxOlhoLogin.Top = textBoxSenha.Top;
            pictureBoxOlhoLogin.Left = textBoxSenha.Right + 4;
            pictureBoxOlhoLogin.Size = new Size(alturaCampo, alturaCampo);

            // Botão Entrar
            btnEntrar.Top = textBoxSenha.Bottom + espacoVertical + 10;
            btnEntrar.Left = centralX;
            btnEntrar.Width = larguraCampo;
            btnEntrar.Height = alturaCampo;

            // Link Registrar
            linkRegistrar.Top = btnEntrar.Bottom + 10;
            linkRegistrar.Left = centralX;

            // Link Esqueci Senha
            linkEsqueciSenha.Top = linkRegistrar.Bottom + 6;
            linkEsqueciSenha.Left = centralX;
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
            if (!ValidateChildren())
                return;

            string nome = textBoxNomecad.Text.Trim();
            string email = textBoxEmailcad.Text.Trim();
            string senha = textBoxSenhacad.Text;
            string confirmarsenha = textBoxConfirmarsenha.Text;
            DateTime dataNascimento = dateTimeNascimento.Value.Date;
            string nacionalidade = textBoxNacionalidade.Text.Trim();
            string profissao = textBoxProfissao.Text.Trim();
            string telefone = textBoxTelefone.Text.Trim();

            // Data válida
            DateTime dataMinima = new DateTime(1900, 1, 1);
            if (dataNascimento < dataMinima || dataNascimento > DateTime.Now)
            {
                MessageBox.Show("Selecione uma data de nascimento válida (entre 01/01/1900 e hoje).");
                return;
            }

            // Campos obrigatórios
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmarsenha) ||
                string.IsNullOrEmpty(nacionalidade) || string.IsNullOrEmpty(profissao))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            // Nome, nacionalidade e profissão - tamanho
            if (nome.Length < 2 || nome.Length > 100)
            {
                MessageBox.Show("O nome deve ter entre 2 e 100 caracteres.");
                return;
            }

            if (nacionalidade.Length < 2 || nacionalidade.Length > 50 ||
                profissao.Length < 2 || profissao.Length > 50)
            {
                MessageBox.Show("Nacionalidade e profissão devem ter entre 2 e 50 caracteres.");
                return;
            }

            // Senhas iguais
            if (senha != confirmarsenha)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }

            // Senha forte
            if (senha.Length < 8 || !senha.Any(char.IsLetter) || !senha.Any(char.IsDigit))
            {
                MessageBox.Show("A senha deve conter pelo menos 8 caracteres, incluindo letras e números.");
                return;
            }

            // E-mail válido
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, informe um e-mail válido.");
                return;
            }

            // Telefone: somente números e 10 a 15 dígitos
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefone, @"^\d{10,15}$"))
            {
                MessageBox.Show("O telefone deve conter apenas números e ter entre 10 e 15 dígitos.");
                return;
            }

            try
            {
                using (var conn = Conexao.ObterConexao())
                {
                    // Verifica duplicidade de e-mail
                    string verificarEmail = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
                    using (var checkCmd = new MySqlCommand(verificarEmail, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Este e-mail já está cadastrado.");
                            return;
                        }
                    }

                    // Cadastro
                    string query = @"INSERT INTO usuarios 
                (nome, email, senha, data_nascimento, nacionalidade, profissao, telefone) 
                VALUES (@nome, @email, @senha, @data_nascimento, @nacionalidade, @profissao, @telefone)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", GerarHashSenha(senha)); // segurança
                        cmd.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                        cmd.Parameters.AddWithValue("@nacionalidade", nacionalidade);
                        cmd.Parameters.AddWithValue("@profissao", profissao);
                        cmd.Parameters.AddWithValue("@telefone", telefone);

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

                MessageBox.Show("Cadastro realizado com sucesso!");

                // Limpar campos
                textBoxNomecad.Clear();
                textBoxEmailcad.Clear();
                textBoxSenhacad.Clear();
                textBoxConfirmarsenha.Clear();
                dateTimeNascimento.Value = DateTime.Now;
                textBoxNacionalidade.Clear();
                textBoxProfissao.Clear();
                textBoxTelefone.Clear();

                panelCadastro.Visible = false;
                panelLogin.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
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

      

            // NOME
            private void CentralizarCadastro()
            {

            if (labelNascimento == null || dateTimeNascimento == null)
            {
                MessageBox.Show("Controles não inicializados corretamente!");
                return;
            }

            int larguraCampo = 300;
            int alturaCampo = 36;
            int larguraLabel = 160;
            int espacoVertical = 13;
            int panelWidth = panelCadastro.Width;
            int centralX = (panelWidth - larguraCampo) / 2;
            int labelX = centralX - larguraLabel - 12;
            int y = 40;

            // Título
            labelCadastro.Top = y;
            labelCadastro.Left = (panelWidth - labelCadastro.Width) / 2;
            y = labelCadastro.Bottom + 20;

            // NOME
            labelNome.Top = y;
            labelNome.Left = labelX;
            labelNome.Width = larguraLabel;
            labelNome.Text = "Nome:";
            labelNome.TextAlign = ContentAlignment.MiddleRight;
            textBoxNomecad.Top = y;
            textBoxNomecad.Left = centralX;
            textBoxNomecad.Width = larguraCampo;
            textBoxNomecad.Height = alturaCampo;
            y += alturaCampo + espacoVertical;

            // EMAIL
            labelEmailcad.Top = y;
            labelEmailcad.Left = labelX;
            labelEmailcad.Width = larguraLabel;
            labelEmailcad.Text = "Email:";
            labelEmailcad.TextAlign = ContentAlignment.MiddleRight;
            textBoxEmailcad.Top = y;
            textBoxEmailcad.Left = centralX;
            textBoxEmailcad.Width = larguraCampo;
            textBoxEmailcad.Height = alturaCampo;
            y += alturaCampo + espacoVertical;

            // SENHA
            labelSenhacad.Top = y;
            labelSenhacad.Left = labelX;
            labelSenhacad.Width = larguraLabel;
            labelSenhacad.Text = "Senha:";
            labelSenhacad.TextAlign = ContentAlignment.MiddleRight;
            textBoxSenhacad.Top = y;
            textBoxSenhacad.Left = centralX;
            textBoxSenhacad.Width = larguraCampo;
            textBoxSenhacad.Height = alturaCampo;
            int olhoTamanho = 22;
            pictureBoxOlhoSenhaCadastro.Top = textBoxSenhacad.Top + (alturaCampo - olhoTamanho) / 2;
            pictureBoxOlhoSenhaCadastro.Left = textBoxSenhacad.Right + 4;
            pictureBoxOlhoSenhaCadastro.Size = new Size(olhoTamanho, olhoTamanho);
            y += alturaCampo + espacoVertical;

            // CONFIRMAR SENHA
            labelSenha2cad.Top = y;
            labelSenha2cad.Left = labelX;
            labelSenha2cad.Width = larguraLabel;
            labelSenha2cad.Text = "Confirmar Senha:";
            labelSenha2cad.TextAlign = ContentAlignment.MiddleRight;
            textBoxConfirmarsenha.Top = y;
            textBoxConfirmarsenha.Left = centralX;
            textBoxConfirmarsenha.Width = larguraCampo;
            textBoxConfirmarsenha.Height = alturaCampo;
            pictureBoxOlhoConfirmarSenha.Top = textBoxConfirmarsenha.Top + (alturaCampo - olhoTamanho) / 2;
            pictureBoxOlhoConfirmarSenha.Left = textBoxConfirmarsenha.Right + 4;
            pictureBoxOlhoConfirmarSenha.Size = new Size(olhoTamanho, olhoTamanho);
            y += alturaCampo + espacoVertical;

            // DATA DE NASCIMENTO
            labelNascimento.Top = y;
            labelNascimento.Left = labelX;
            labelNascimento.Width = larguraLabel;
            labelNascimento.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelNascimento.Text = "Data de nascimento:";
            labelNascimento.TextAlign = ContentAlignment.MiddleRight;
            dateTimeNascimento.Top = y;
            dateTimeNascimento.Left = centralX;
            dateTimeNascimento.Width = larguraCampo;
            dateTimeNascimento.Height = alturaCampo;
            y += alturaCampo + espacoVertical;

            // NACIONALIDADE
            labelNacionalidade.Top = y;
            labelNacionalidade.Left = labelX;
            labelNacionalidade.Width = larguraLabel;
            labelNacionalidade.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelNacionalidade.Text = "Nacionalidade:";
            labelNacionalidade.TextAlign = ContentAlignment.MiddleRight;
            textBoxNacionalidade.Top = y;
            textBoxNacionalidade.Left = centralX;
            textBoxNacionalidade.Width = larguraCampo;
            textBoxNacionalidade.Height = alturaCampo;
            y += alturaCampo + espacoVertical;

            // PROFISSÃO
            labelProfissao.Top = y;
            labelProfissao.Left = labelX;
            labelProfissao.Width = larguraLabel;
            labelProfissao.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelProfissao.Text = "Profissão:";
            labelProfissao.TextAlign = ContentAlignment.MiddleRight;
            textBoxProfissao.Top = y;
            textBoxProfissao.Left = centralX;
            textBoxProfissao.Width = larguraCampo;
            textBoxProfissao.Height = alturaCampo;
            y += alturaCampo + espacoVertical;

            // TELEFONE (opcional)
            labelTelefone.Top = y;
            labelTelefone.Left = labelX;
            labelTelefone.Width = larguraLabel;
            labelTelefone.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelTelefone.Text = "Telefone:";
            labelTelefone.TextAlign = ContentAlignment.MiddleRight;
            textBoxTelefone.Top = y;
            textBoxTelefone.Left = centralX;
            textBoxTelefone.Width = larguraCampo;
            textBoxTelefone.Height = alturaCampo;
            y += alturaCampo + 2 * espacoVertical;

            // BOTÕES
            btnCadastrar.Top = y;
            btnCadastrar.Left = centralX;
            btnCadastrar.Width = 140;
            btnCadastrar.Height = alturaCampo;

            btnVoltarCad.Top = y;
            btnVoltarCad.Left = btnCadastrar.Right + 12;
            btnVoltarCad.Width = 140;
            btnVoltarCad.Height = alturaCampo;
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

