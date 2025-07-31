// Importa as bibliotecas necess�rias para a aplica��o.
// MySql.Data.MySqlClient: Para a conex�o com o banco de dados MySQL.
// MySqlX.XDevAPI: Outro conector para MySQL, embora n�o pare�a ser usado ativamente neste trecho.
// System.Drawing.Drawing2D: Para manipula��o de gr�ficos avan�ados, como arredondar cantos de controles.
// System.Security.Cryptography: Para fun��es de criptografia, usadas aqui para gerar hashes seguros de senha.
// System.Text.RegularExpressions: Para usar express�es regulares na valida��o de campos como e-mail e senha.
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Tcc
{
    // Define a classe do formul�rio principal, que herda da classe Form.
    public partial class MenuPrincipalFrm : Form
    {
        // Define a paleta de cores padr�o para a interface do usu�rio, facilitando a consist�ncia visual.
        Color corPrimaria = ColorTranslator.FromHtml("#202E39"); // Um azul escuro, usado para fundos e bot�es.
        Color corSecundaria = ColorTranslator.FromHtml("#FFFCF6"); // Um branco-amarelado, usado para pain�is.
        Color corTexto = ColorTranslator.FromHtml("#333333"); // Cor de texto padr�o.
        Color corApoio = ColorTranslator.FromHtml("#4A90E2"); // Cor de destaque.
        Color corSuporte = ColorTranslator.FromHtml("#7ED321"); // Cor de suporte/sucesso.

        // Declara��o de componentes e vari�veis de estado.
        private ErrorProvider errorProvider = new ErrorProvider(); // Componente para exibir �cones de erro ao lado dos controles com dados inv�lidos.
        private bool senhaCadastroVisivel = true; // Controla se a senha no campo de cadastro est� vis�vel ou mascarada.
        private bool senhaCadastroConfirmVisivel = true; // Controla a visibilidade da senha no campo de confirma��o.
        private bool senhaLoginVisivel = true; // Controla a visibilidade da senha no campo de login.

        // Declara��o dos controles de cadastro que ser�o criados dinamicamente (via c�digo).
        private Label labelNascimento;
        private DateTimePicker dateTimeNascimento;
        private Label labelNacionalidade;
        private ComboBox ComboBoxNacionalidade;
        private Label labelProfissao;
        private TextBox textBoxProfissao;
        private Label labelTelefone;
        private TextBox textBoxTelefone;

        // Construtor do formul�rio. � executado quando o formul�rio � criado.
        public MenuPrincipalFrm()
        {
            InitializeComponent(); // M�todo gerado pelo Designer do Windows Forms para inicializar os componentes criados na interface gr�fica.

            // Associa eventos a seus respectivos m�todos de tratamento (event handlers).
            this.Shown += MenuPrincipalFrm_Shown; // Executa quando o formul�rio � exibido pela primeira vez.
            this.SizeChanged += new EventHandler(MenuPrincipalFrm_SizeChanged); // Executa sempre que o formul�rio � redimensionado.
            this.Load += new EventHandler(MenuPrincipalFrm_Load); // Executa antes do formul�rio ser exibido.
                                                                  // Permite a valida��o, mas n�o impede a mudan�a de foco para controlos
                                                                  // que n�o exigem valida��o (como o bot�o de fechar).
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            // Eventos de valida��o para os campos de cadastro.
            textBoxEmailcad.Validating += textBoxEmailcad_Validating;
            textBoxSenhacad.Validating += textBoxSenhacad_Validating;
            textBoxConfirmarsenha.Validating += textBoxConfirmarsenha_Validating;

            // Eventos de clique para os �cones de "olho" que mostram/ocultam as senhas.
            pictureBoxOlhoSenhaCadastro.Click += pictureBoxOlhoSenhaCadastro_Click;
            pictureBoxOlhoConfirmarSenha.Click += pictureBoxOlhoConfirmarSenha_Click;
            pictureBoxOlhoLogin.Click += pictureBoxOlhoLogin_Click;

            // Define o estado inicial dos campos de senha como mascarados.
            textBoxSenhacad.UseSystemPasswordChar = true;
            textBoxConfirmarsenha.UseSystemPasswordChar = true;
            textBoxSenha.UseSystemPasswordChar = true;

            // Define a imagem inicial dos �cones "olho" para "fechado".
            pictureBoxOlhoSenhaCadastro.Image = Properties.Resources.eye_close;
            pictureBoxOlhoConfirmarSenha.Image = Properties.Resources.eye_close;
            pictureBoxOlhoLogin.Image = Properties.Resources.eye_close;

            // Instancia os controles de cadastro que foram declarados anteriormente.
            labelNascimento = new Label();
            dateTimeNascimento = new DateTimePicker();
            labelNacionalidade = new Label();
            ComboBoxNacionalidade = new ComboBox();
            labelProfissao = new Label();
            textBoxProfissao = new TextBox();
            labelTelefone = new Label();
            textBoxTelefone = new TextBox();

            // Adiciona os controles rec�m-criados ao painel de cadastro.
            panelCadastro.Controls.Add(labelNascimento);
            panelCadastro.Controls.Add(dateTimeNascimento);
            panelCadastro.Controls.Add(labelNacionalidade);
            panelCadastro.Controls.Add(ComboBoxNacionalidade);
            panelCadastro.Controls.Add(labelProfissao);
            panelCadastro.Controls.Add(textBoxProfissao);
            panelCadastro.Controls.Add(labelTelefone);
            panelCadastro.Controls.Add(textBoxTelefone);

            // Define a posi��o inicial do formul�rio para o centro da tela pai.
            this.StartPosition = FormStartPosition.CenterParent;
        }

        // Evento de clique para o bot�o "Entrar".
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim(); // Pega o email, removendo espa�os em branco no in�cio e fim.
            string senha = textBoxSenha.Text.Trim(); // Pega a senha.

            int idUsuario = ObterIdUsuario(email, senha); // Tenta validar o login e obter o ID do usu�rio.

            if (idUsuario > 0) // Se o ID for maior que 0, o login foi bem-sucedido.
            {
                Sessao.UsuarioId = idUsuario; // Armazena o ID do usu�rio em uma classe est�tica de sess�o.

                // Cria uma nova inst�ncia do formul�rio Dashboard.
                DashboardFrm dashboard = new DashboardFrm(idUsuario);
                // Define que, ao fechar o Dashboard, o formul�rio de login tamb�m ser� fechado.
                dashboard.FormClosed += (s, args) => this.Close();
                this.Hide(); // Esconde o formul�rio de login.
                dashboard.Show(); // Mostra o Dashboard.
            }
            else
            {
                // Se o login falhar, exibe uma mensagem de erro.
                MessageBox.Show("Email ou senha inv�lidos");
            }
        }

        // M�todo para verificar as credenciais no banco de dados.
        private int ObterIdUsuario(string email, string senha)
        {
            try
            {
                // Abre uma conex�o com o banco de dados. O 'using' garante que a conex�o ser� fechada.
                using (var conn = Conexao.ObterConexao())
                {
                    // Query SQL para buscar o ID e a senha (hash) do usu�rio com o email fornecido.
                    string query = "SELECT id, senha FROM usuarios WHERE email = @Email";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email); // Adiciona o email como par�metro para evitar SQL Injection.

                        using (var reader = cmd.ExecuteReader()) // Executa a query e obt�m um leitor de dados.
                        {
                            if (reader.Read()) // Se um registro for encontrado...
                            {
                                int id = reader.GetInt32("id"); // Pega o ID do usu�rio.
                                string hashSalva = reader.GetString("senha"); // Pega o hash da senha armazenado no banco.

                                // Valida se a senha digitada corresponde ao hash salvo.
                                if (ValidarSenha(senha, hashSalva))
                                    return id; // Retorna o ID se a senha for v�lida.
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro na conex�o ou na query, exibe uma mensagem.
                MessageBox.Show("Erro ao verificar login: " + ex.Message);
            }
            return 0; // Retorna 0 se o usu�rio n�o for encontrado ou a senha for inv�lida.
        }

        // M�todo est�tico para validar uma senha em texto puro contra um hash PBKDF2 salvo.
        public static bool ValidarSenha(string senha, string hashSalvo)
        {
            byte[] hashBytes = Convert.FromBase64String(hashSalvo); // Converte o hash (string Base64) de volta para bytes.
            byte[] salt = new byte[16]; // Cria um array para armazenar o salt.
            Array.Copy(hashBytes, 0, salt, 0, 16); // Extrai os primeiros 16 bytes (o salt) do hash armazenado.

            // Gera um novo hash da senha fornecida usando o mesmo salt extra�do.
            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20); // Gera um hash de 20 bytes.

            // Compara o hash rec�m-gerado com o hash original de forma segura (tempo constante) para evitar ataques de temporiza��o.
            uint diff = (uint)hashBytes.Length ^ (uint)(hash.Length + 16);
            for (int i = 0; i < 20; i++)
            {
                diff |= (uint)(hashBytes[i + 16] ^ hash[i]);
            }

            return diff == 0; // Retorna true se os hashes forem id�nticos.
        }

        // Evento de valida��o para o campo de email no cadastro.
        private void textBoxEmailcad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!EmailValido(textBoxEmailcad.Text)) // Verifica se o formato do email � v�lido.
            {
                errorProvider.SetError(textBoxEmailcad, "E-mail inv�lido."); // Mostra um erro se for inv�lido.
                e.Cancel = false; // N�o cancela o evento, permitindo que o foco mude, mas o erro � exibido.
            }
            else
            {
                errorProvider.SetError(textBoxEmailcad, ""); // Limpa o erro se for v�lido.
            }
        }

        // Evento de valida��o para o campo de senha no cadastro.
        private void textBoxSenhacad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!SenhaForte(textBoxSenhacad.Text)) // Verifica se a senha atende aos crit�rios de seguran�a.
            {
                errorProvider.SetError(textBoxSenhacad, "Senha fraca. Use letras mai�sculas, min�sculas, n�mero e especial.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(textBoxSenhacad, "");
            }
        }

        // Evento de valida��o para o campo de confirma��o de senha.
        private void textBoxConfirmarsenha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBoxSenhacad.Text != textBoxConfirmarsenha.Text) // Verifica se as senhas coincidem.
            {
                errorProvider.SetError(textBoxConfirmarsenha, "As senhas n�o coincidem.");
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(textBoxConfirmarsenha, "");
            }
        }

        // Evento de clique para o �cone de olho do campo de senha do cadastro.
        private void pictureBoxOlhoSenhaCadastro_Click(object sender, EventArgs e)
        {
            senhaCadastroVisivel = !senhaCadastroVisivel; // Inverte o estado de visibilidade.
            textBoxSenhacad.UseSystemPasswordChar = !senhaCadastroVisivel; // Aplica o mascaramento ou o remove.
            // Troca a imagem do olho para "aberto" ou "fechado" com base no estado.
            pictureBoxOlhoSenhaCadastro.Image = senhaCadastroVisivel ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        // Evento de clique para o �cone de olho do campo de confirma��o de senha.
        private void pictureBoxOlhoConfirmarSenha_Click(object sender, EventArgs e)
        {
            senhaCadastroConfirmVisivel = !senhaCadastroConfirmVisivel;
            textBoxConfirmarsenha.UseSystemPasswordChar = !senhaCadastroConfirmVisivel;
            pictureBoxOlhoConfirmarSenha.Image = senhaCadastroConfirmVisivel ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        // Evento de clique para o �cone de olho do campo de senha do login.
        private void pictureBoxOlhoLogin_Click(object sender, EventArgs e)
        {
            senhaLoginVisivel = !senhaLoginVisivel;
            textBoxSenha.UseSystemPasswordChar = !senhaLoginVisivel;
            pictureBoxOlhoLogin.Image = senhaLoginVisivel ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        // M�todo utilit�rio para arredondar os cantos de um bot�o.
        private void ArredondarBotao(Button btn, int raio)
        {
            GraphicsPath path = new GraphicsPath();
            // Desenha arcos nos quatro cantos do bot�o para criar o efeito arredondado.
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path); // Aplica a forma criada (path) � regi�o vis�vel do bot�o.
        }

        // Evento que captura o pressionamento de tecla em um controle.
        private void Controle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Se a tecla pressionada for Enter...
            {
                e.SuppressKeyPress = true; // Impede o som de "bip" do Windows.
                this.SelectNextControl((Control)sender, true, true, true, true); // Move o foco para o pr�ximo controle na ordem de tabula��o.
            }
        }

        // M�todo utilit�rio para arredondar os cantos de qualquer controle. (Similar a ArredondarBotao)
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

        // Evento executado no carregamento do formul�rio. Ideal para configura��es iniciais.
        private void MenuPrincipalFrm_Load(object sender, EventArgs e)
        {
            PreencherListBoxNacionalidade(); // Popula o ComboBox de nacionalidades com uma lista pr�-definida.

            // Aplica as cores definidas no in�cio da classe aos componentes.
            this.BackColor = corPrimaria;
            panelCadastro.BackColor = corSecundaria;
            panelLogin.BackColor = corSecundaria;

           

            // Define a visibilidade inicial dos pain�is: login vis�vel, cadastro oculto.
            panelLogin.Visible = true;
            panelCadastro.Visible = false;

            // Configura a posi��o e o tamanho iniciais dos pain�is.
            panelLogin.Location = new Point(0, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);

            textBoxEmail.Focus(); // Define o foco inicial no campo de email do login.

            // Estiliza os componentes do painel de login.
            labelLogin.ForeColor = corTexto;
            btnEntrar.BackColor = corPrimaria;
            btnEntrar.ForeColor = Color.White;
            labelLogin.ForeColor = corTexto;

            // Centraliza o t�tulo e os pain�is na janela.
            labelTitulo.Left = (this.ClientSize.Width - labelTitulo.Width) / 2;
            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;
            panelCadastro.Left = (this.ClientSize.Width - panelCadastro.Width) / 2;
            panelCadastro.Top = (this.ClientSize.Height - panelCadastro.Height) / 2;

            // Itera sobre todos os controles no painel de cadastro para aplicar estilos.
            foreach (Control ctrl in panelCadastro.Controls)
            {
                if (ctrl is Panel pnl) { pnl.BackColor = corSecundaria; }
                if (ctrl is Label lbl) { lbl.ForeColor = corTexto; }
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
                    // Estiliza o controle de data.
                    dt.CalendarMonthBackground = corPrimaria;
                    dt.CalendarForeColor = corTexto;
                    dt.BackColor = corPrimaria;
                    dt.ForeColor = corTexto;
                }
            }

            // Arredonda os cantos dos bot�es de cadastro.
            ArredondarBotao(btnVoltarCad, 20);
            ArredondarBotao(btnCadastrar, 20);

            // Chama os m�todos para centralizar os controles dentro de cada painel.
            CentralizarLogin();
            CentralizarCadastro();

            // Ativa a funcionalidade de "Enter para pular de campo" para ambos os pain�is.
            Enter(panelCadastro);
            Enter(panelLogin);
        }

        // Evento de clique para o bot�o "Abrir Cadastro" (n�o vis�vel, mas pode ser um link).
        private void btnAbrirCadastro_Click(object sender, EventArgs e)
        {
            // Alterna a visibilidade dos pain�is para mostrar o de cadastro.
            panelCadastro.Visible = true;
            panelLogin.Visible = false;
            // Ajusta a posi��o e o tamanho do painel de cadastro.
            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
        }

        // Evento de clique para o bot�o que volta para a tela de Login.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Alterna a visibilidade para mostrar o painel de login.
            panelCadastro.Visible = false;
            panelLogin.Visible = true;
            panelLogin.Location = new Point(this.ClientSize.Width / 2, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
        }

        // M�todo para centralizar e organizar os controles no painel de login.
        private void CentralizarLogin()
        {
            // Define dimens�es e espa�amentos padr�o.
            int larguraCampo = 300;
            int alturaCampo = 36;
            int espacoVertical = 15;
            int panelWidth = panelLogin.Width;
            int centralX = (panelWidth - larguraCampo) / 2; // Calcula a posi��o X para centralizar os campos.

            // Garante que a imagem da logo seja carregada.
            if (pictureBoxLogoLogin.Image == null)
            {
                pictureBoxLogoLogin.Image = Properties.Resources.RoutineSync__2_;
            }

            // Posiciona cada controle (label, textbox, bot�o, link) de forma calculada para um layout limpo.
            labelLogin.Top = 40;
            labelLogin.Left = (panelWidth - labelLogin.Width) / 2;

            labelEmail.Top = labelLogin.Bottom + 30;
            labelEmail.Left = centralX;
            textBoxEmail.Top = labelEmail.Bottom + 2;
            textBoxEmail.Left = centralX;
            textBoxEmail.Width = larguraCampo;
            textBoxEmail.Height = alturaCampo;

            labelSenha.Top = textBoxEmail.Bottom + espacoVertical;
            labelSenha.Left = centralX;
            textBoxSenha.Top = labelSenha.Bottom + 2;
            textBoxSenha.Left = centralX;
            textBoxSenha.Width = larguraCampo;
            textBoxSenha.Height = alturaCampo;

            pictureBoxOlhoLogin.Top = textBoxSenha.Top;
            pictureBoxOlhoLogin.Left = textBoxSenha.Right + 4;
            pictureBoxOlhoLogin.Size = new Size(alturaCampo, alturaCampo);

            btnEntrar.Top = textBoxSenha.Bottom + espacoVertical + 10;
            btnEntrar.Left = centralX;
            btnEntrar.Width = larguraCampo;
            btnEntrar.Height = alturaCampo;

            linkRegistrar.Top = btnEntrar.Bottom + 10;
            linkRegistrar.Left = centralX;

            linkEsqueciSenha.Top = linkRegistrar.Bottom + 6;
            linkEsqueciSenha.Left = centralX;
        }

        // Evento chamado quando o formul�rio � redimensionado.
        private void MenuPrincipalFrm_SizeChanged(object sender, EventArgs e)
        {
            // Reajusta o tamanho do painel ativo para ocupar metade da nova largura da janela.
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
            // Re-centraliza os controles para se adaptarem ao novo tamanho do painel.
            CentralizarLogin();
            CentralizarCadastro();
        }

        // Evento de clique do bot�o "Cadastrar".
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Valida os campos antes de prosseguir.
            if (!ValidateChildren())
                return;

            // Coleta os dados dos campos do formul�rio.
            string nome = textBoxNomecad.Text.Trim();
            string email = textBoxEmailcad.Text.Trim();
            string senha = textBoxSenhacad.Text;
            string confirmarsenha = textBoxConfirmarsenha.Text;
            DateTime dataNascimento = dateTimeNascimento.Value.Date;
            string nacionalidade = ComboBoxNacionalidade.Text.Trim();
            string profissao = textBoxProfissao.Text.Trim();
            string telefone = textBoxTelefone.Text.Trim();

            // Inicia uma s�rie de valida��es de neg�cio.
            // Data de nascimento v�lida.
            DateTime dataMinima = new DateTime(1900, 1, 1);
            if (dataNascimento < dataMinima || dataNascimento > DateTime.Now)
            {
                MessageBox.Show("Selecione uma data de nascimento v�lida (entre 01/01/1900 e hoje).");
                return;
            }

            // Campos obrigat�rios.
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmarsenha) ||
                string.IsNullOrEmpty(nacionalidade) || string.IsNullOrEmpty(profissao))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigat�rios.");
                return;
            }

            // Valida��o de tamanho dos campos de texto.
            if (nome.Length < 2 || nome.Length > 100)
            {
                MessageBox.Show("O nome deve ter entre 2 e 100 caracteres.");
                return;
            }
            if (nacionalidade.Length < 2 || nacionalidade.Length > 50 ||
                profissao.Length < 2 || profissao.Length > 50)
            {
                MessageBox.Show("Nacionalidade e profiss�o devem ter entre 2 e 50 caracteres.");
                return;
            }

            // Confirma��o de senha.
            if (senha != confirmarsenha)
            {
                MessageBox.Show("As senhas n�o coincidem.");
                return;
            }

            // For�a da senha.
            if (senha.Length < 8 || !senha.Any(char.IsLetter) || !senha.Any(char.IsDigit))
            {
                MessageBox.Show("A senha deve conter pelo menos 8 caracteres, incluindo letras e n�meros.");
                return;
            }

            // Formato do e-mail.
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Por favor, informe um e-mail v�lido.");
                return;
            }

            // Formato do telefone.
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefone, @"^\d{10,15}$"))
            {
                MessageBox.Show("O telefone deve conter apenas n�meros e ter entre 10 e 15 d�gitos.");
                return;
            }

            // Se todas as valida��es passarem, prossegue para a inser��o no banco de dados.
            try
            {
                using (var conn = Conexao.ObterConexao())
                {
                    // Verifica se o e-mail j� est� em uso.
                    string verificarEmail = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
                    using (var checkCmd = new MySqlCommand(verificarEmail, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Este e-mail j� est� cadastrado.");
                            return;
                        }
                    }

                    // Query de inser��o para o novo usu�rio.
                    string query = @"INSERT INTO usuarios 
                               (nome, email, senha, data_nascimento, nacionalidade, profissao, telefone) 
                               VALUES (@nome, @email, @senha, @data_nascimento, @nacionalidade, @profissao, @telefone)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Adiciona os par�metros � query, garantindo a seguran�a.
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", GerarHashSenha(senha)); // Importante: Armazena o HASH da senha, nunca a senha pura.
                        cmd.Parameters.AddWithValue("@data_nascimento", dataNascimento);
                        cmd.Parameters.AddWithValue("@nacionalidade", nacionalidade);
                        cmd.Parameters.AddWithValue("@profissao", profissao);
                        cmd.Parameters.AddWithValue("@telefone", telefone);

                        cmd.ExecuteNonQuery(); // Executa a inser��o.
                    }
                    conn.Close(); // Fecha a conex�o.
                }

                MessageBox.Show("Cadastro realizado com sucesso!");

                // Limpa todos os campos do formul�rio de cadastro.
                textBoxNomecad.Clear();
                textBoxEmailcad.Clear();
                textBoxSenhacad.Clear();
                textBoxConfirmarsenha.Clear();
                dateTimeNascimento.Value = DateTime.Now;
                textBoxProfissao.Clear();
                textBoxTelefone.Clear();

                // Retorna para a tela de login.
                panelCadastro.Visible = false;
                panelLogin.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        // Evento do bot�o "Voltar" no painel de cadastro.
        private void btnVoltarCad_Click(object sender, EventArgs e)
        {
            panelCadastro.Visible = false; // Oculta o painel de cadastro.
            panelLogin.Visible = true; // Exibe o painel de login.
            // Reposiciona o painel de login.
            panelLogin.Location = new Point(0, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
        }

        // M�todo utilit�rio que usa Regex para validar o formato de um e-mail.
        private bool EmailValido(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // M�todo utilit�rio que usa Regex para verificar se a senha atende aos requisitos de seguran�a.
        private bool SenhaForte(string senha)
        {
            // Exige no m�nimo 8 caracteres, 1 letra min�scula, 1 mai�scula, 1 n�mero e 1 caractere especial.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";
            return Regex.IsMatch(senha, pattern);
        }

        // Evento de clique para o link "Registrar-se" na tela de login.
        private void linkRegistrar_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false; // Oculta login.
            panelCadastro.Visible = true; // Mostra cadastro.
            // Ajusta a posi��o e tamanho do painel.
            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);
        }

        // Evento de clique para o link "Esqueci a senha".
        private void linkEsqueciSenha_Click(object sender, EventArgs e)
        {
            // Abre um novo formul�rio para o processo de redefini��o de senha.
            var frm = new RedefinirSenhaFrm();
            frm.ShowDialog(); // Mostra como um di�logo modal, bloqueando o formul�rio atual.
        }

        // M�todo recursivo para aplicar o evento KeyDown a todos os TextBoxes dentro de um controle pai.
        private void Enter(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                    txt.KeyDown += Controle_KeyDown; // Adiciona o handler ao TextBox.

                if (ctrl.HasChildren)
                    Enter(ctrl); // Chama a si mesmo para os sub-controles (ex: pain�is dentro de pain�is).
            }
        }

        // Evento que ocorre quando o formul�rio � exibido pela primeira vez.
        private void MenuPrincipalFrm_Shown(object sender, EventArgs e)
        {
            // Reajusta a posi��o e o tamanho dos pain�is.
            panelLogin.Location = new Point(0, 0);
            panelLogin.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);

            panelCadastro.Location = new Point(0, 0);
            panelCadastro.Size = new Size(this.ClientSize.Width / 2, this.ClientSize.Height);

            // Define dimens�es para os campos.
            int larguraCampo = 280;
            int alturaCampo = 40;

            // Redimensiona o bot�o Entrar.
            btnEntrar.Width = larguraCampo;
            btnEntrar.Height = alturaCampo;

            // Aplica uma fonte maior aos campos de login.
            Font fonteMaior = new Font("Segoe UI", 12F, FontStyle.Regular);
            textBoxEmail.Font = fonteMaior;
            textBoxSenha.Font = fonteMaior;
        }

        // M�todo para centralizar e organizar os controles no painel de cadastro.
        private void CentralizarCadastro()
        {
            // Verifica��o para evitar erros se os controles n�o foram inicializados.
            if (labelNascimento == null || dateTimeNascimento == null)
            {
                MessageBox.Show("Bem Vindo a RoutineSync!");
                return;
            }

            // Define dimens�es e espa�amentos padr�o.
            int larguraCampo = 300;
            int alturaCampo = 36;
            int larguraLabel = 160;
            int espacoVertical = 13;
            int panelWidth = panelCadastro.Width;
            int centralX = (panelWidth - larguraCampo) / 2;
            int labelX = centralX - larguraLabel - 12; // Posi��o X para os labels, alinhados � direita dos campos.
            int y = 40; // Coordenada Y inicial, que ser� incrementada para cada linha de controle.

            // Posiciona o t�tulo do painel.
            labelCadastro.Top = y;
            labelCadastro.Left = (panelWidth - labelCadastro.Width) / 2;
            y = labelCadastro.Bottom + 20;

            // Posiciona os controles para Nome.
            labelNome.Top = y;
            labelNome.Left = labelX;
            labelNome.Width = larguraLabel;
            labelNome.Text = "Nome:";
            labelNome.TextAlign = ContentAlignment.MiddleRight;
            textBoxNomecad.Top = y;
            textBoxNomecad.Left = centralX;
            textBoxNomecad.Width = larguraCampo;
            textBoxNomecad.Height = alturaCampo;
            y += alturaCampo + espacoVertical; // Atualiza a posi��o Y para a pr�xima linha.

            // Repete o processo de posicionamento para todos os outros campos:
            // Email, Senha, Confirmar Senha, Data de Nascimento, Nacionalidade, Profiss�o e Telefone.
            // Para cada campo, define a posi��o do Label e do controle de entrada (TextBox, DateTimePicker, etc.),
            // alinhando-os de forma consistente e incrementando a vari�vel 'y'.

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

            labelNacionalidade.Top = y;
            labelNacionalidade.Left = labelX;
            labelNacionalidade.Width = larguraLabel;
            labelNacionalidade.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelNacionalidade.Text = "Nacionalidade:";
            labelNacionalidade.TextAlign = ContentAlignment.MiddleRight;
            ComboBoxNacionalidade.Top = y;
            ComboBoxNacionalidade.Left = centralX;
            ComboBoxNacionalidade.Width = larguraCampo;
            ComboBoxNacionalidade.Height = alturaCampo;
            y += alturaCampo + espacoVertical;

            labelProfissao.Top = y;
            labelProfissao.Left = labelX;
            labelProfissao.Width = larguraLabel;
            labelProfissao.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelProfissao.Text = "Profiss�o:";
            labelProfissao.TextAlign = ContentAlignment.MiddleRight;
            textBoxProfissao.Top = y;
            textBoxProfissao.Left = centralX;
            textBoxProfissao.Width = larguraCampo;
            textBoxProfissao.Height = alturaCampo;
            y += alturaCampo + espacoVertical;

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

            // Posiciona os bot�es de "Cadastrar" e "Voltar" lado a lado.
            btnCadastrar.Top = y;
            btnCadastrar.Left = centralX;
            btnCadastrar.Width = 140;
            btnCadastrar.Height = alturaCampo;

            btnVoltarCad.Top = y;
            btnVoltarCad.Left = btnCadastrar.Right + 12;
            btnVoltarCad.Width = 140;
            btnVoltarCad.Height = alturaCampo;
        }

        // M�todo para preencher o ComboBox de nacionalidades com uma lista fixa.
        private void PreencherListBoxNacionalidade()
        {
            ComboBoxNacionalidade.Items.Clear(); // Limpa itens existentes.

            // Adiciona uma lista de pa�ses.
            ComboBoxNacionalidade.Items.Add("Brasil");
            ComboBoxNacionalidade.Items.Add("Argentina");
            ComboBoxNacionalidade.Items.Add("Estados Unidos");
            // ... (restante da lista)
        }

        // M�todo est�tico para gerar um hash seguro de senha usando o algoritmo PBKDF2.
        public static string GerarHashSenha(string senha)
        {
            // Gera um "salt" criptograficamente seguro de 16 bytes. O salt � um valor aleat�rio que
            // � adicionado � senha antes do hashing para evitar ataques de rainbow table.
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            // Usa a classe Rfc2898DeriveBytes (implementa��o do PBKDF2) para gerar o hash.
            // 10000 � o n�mero de itera��es, um valor que torna o processo de hashing mais lento
            // e, portanto, mais resistente a ataques de for�a bruta.
            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20); // Gera um hash de 20 bytes (padr�o para SHA-1 usado no PBKDF2).

            // Combina o salt e o hash em um �nico array de bytes para f�cil armazenamento.
            byte[] hashBytes = new byte[36]; // 16 bytes para o salt + 20 bytes para o hash.
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Converte o array de bytes combinado para uma string Base64 para ser armazenado no banco de dados.
            return Convert.ToBase64String(hashBytes);
        }
    }
}