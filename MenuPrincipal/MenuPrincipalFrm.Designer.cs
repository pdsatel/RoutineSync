namespace Tcc
{
    partial class MenuPrincipalFrm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnCadastro = new Button();
            btnLogin = new Button();
            labelTitulo = new Label();
            panelLogin = new Panel();
            labelLogin = new Label();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelSenha = new Label();
            textBoxSenha = new TextBox();
            btnEntrar = new Button();
            linkRegistrar = new LinkLabel();
            panelCadastro = new Panel();
            labelCadastro = new Label();
            labelNome = new Label();
            textBoxNomecad = new TextBox();
            labelEmailcad = new Label();
            textBoxEmailcad = new TextBox();
            labelSenhacad = new Label();
            textBoxSenhacad = new TextBox();
            labelSenha2cad = new Label();
            textBoxConfirmarsenha = new TextBox();
            labelAltura = new Label();
            textBoxAltura = new TextBox();
            labelPeso = new Label();
            textBoxPeso = new TextBox();
            labelHoraDormir = new Label();
            dateTimeHoraDormir = new DateTimePicker();
            labelHoraAcordar = new Label();
            dateTimeHoraAcordar = new DateTimePicker();
            btnCadastrar = new Button();
            btnVoltarCad = new Button();
            panelLogin.SuspendLayout();
            panelCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // btnCadastro
            // 
            btnCadastro.Location = new Point(0, 0);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(75, 23);
            btnCadastro.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 0;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelTitulo.ForeColor = SystemColors.ActiveCaption;
            labelTitulo.Location = new Point(173, 102);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(308, 65);
            labelTitulo.TabIndex = 2;
            labelTitulo.Text = "RoutineSync";
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(labelLogin);
            panelLogin.Controls.Add(labelEmail);
            panelLogin.Controls.Add(textBoxEmail);
            panelLogin.Controls.Add(labelSenha);
            panelLogin.Controls.Add(textBoxSenha);
            panelLogin.Controls.Add(btnEntrar);
            panelLogin.Controls.Add(linkRegistrar);
            panelLogin.Location = new Point(14, 42);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(601, 778);
            panelLogin.TabIndex = 1;
            panelLogin.Visible = false;
            panelLogin.Paint += panelLogin_Paint;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelLogin.ForeColor = SystemColors.ActiveCaption;
            labelLogin.Location = new Point(601, 45);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(155, 65);
            labelLogin.TabIndex = 6;
            labelLogin.Text = "Login";
            labelLogin.Click += label1_Click_1;
            // 
            // labelEmail
            // 
            labelEmail.Location = new Point(601, 140);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 30);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(601, 170);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(300, 31);
            textBoxEmail.TabIndex = 1;
            // 
            // labelSenha
            // 
            labelSenha.Location = new Point(601, 215);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(100, 30);
            labelSenha.TabIndex = 2;
            labelSenha.Text = "Senha:";
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(601, 245);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.PasswordChar = '*';
            textBoxSenha.Size = new Size(300, 31);
            textBoxSenha.TabIndex = 3;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(601, 300);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(100, 40);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // linkRegistrar
            // 
            linkRegistrar.AutoSize = true;
            linkRegistrar.Location = new Point(601, 360);
            linkRegistrar.Margin = new Padding(4, 0, 4, 0);
            linkRegistrar.Name = "linkRegistrar";
            linkRegistrar.Size = new Size(270, 25);
            linkRegistrar.TabIndex = 8;
            linkRegistrar.TabStop = true;
            linkRegistrar.Text = "Não tem uma conta? Registre-se";
            linkRegistrar.Click += linkRegistrar_Click;
            // 
            // panelCadastro
            // 
            panelCadastro.BorderStyle = BorderStyle.FixedSingle;
            panelCadastro.Controls.Add(labelCadastro);
            panelCadastro.Controls.Add(labelNome);
            panelCadastro.Controls.Add(textBoxNomecad);
            panelCadastro.Controls.Add(labelEmailcad);
            panelCadastro.Controls.Add(textBoxEmailcad);
            panelCadastro.Controls.Add(labelSenhacad);
            panelCadastro.Controls.Add(textBoxSenhacad);
            panelCadastro.Controls.Add(labelSenha2cad);
            panelCadastro.Controls.Add(textBoxConfirmarsenha);
            panelCadastro.Controls.Add(labelAltura);
            panelCadastro.Controls.Add(textBoxAltura);
            panelCadastro.Controls.Add(labelPeso);
            panelCadastro.Controls.Add(textBoxPeso);
            panelCadastro.Controls.Add(labelHoraDormir);
            panelCadastro.Controls.Add(dateTimeHoraDormir);
            panelCadastro.Controls.Add(labelHoraAcordar);
            panelCadastro.Controls.Add(dateTimeHoraAcordar);
            panelCadastro.Controls.Add(btnCadastrar);
            panelCadastro.Controls.Add(btnVoltarCad);
            panelCadastro.Location = new Point(3, 35);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Size = new Size(876, 524);
            panelCadastro.TabIndex = 2;
            panelCadastro.Visible = false;
            panelCadastro.Paint += panelCadastro_Paint;
            // 
            // labelCadastro
            // 
            labelCadastro.AutoSize = true;
            labelCadastro.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelCadastro.ForeColor = SystemColors.ActiveCaption;
            labelCadastro.Location = new Point(160, 10);
            labelCadastro.Name = "labelCadastro";
            labelCadastro.Size = new Size(168, 48);
            labelCadastro.TabIndex = 99;
            labelCadastro.Text = "Cadastro";
            // 
            // labelNome
            // 
            labelNome.Location = new Point(51, 60);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(100, 30);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome:";
            // 
            // textBoxNomecad
            // 
            textBoxNomecad.Location = new Point(161, 60);
            textBoxNomecad.Name = "textBoxNomecad";
            textBoxNomecad.Size = new Size(300, 31);
            textBoxNomecad.TabIndex = 1;
            // 
            // labelEmailcad
            // 
            labelEmailcad.Location = new Point(51, 110);
            labelEmailcad.Name = "labelEmailcad";
            labelEmailcad.Size = new Size(100, 30);
            labelEmailcad.TabIndex = 2;
            labelEmailcad.Text = "Email:";
            // 
            // textBoxEmailcad
            // 
            textBoxEmailcad.Location = new Point(161, 110);
            textBoxEmailcad.Name = "textBoxEmailcad";
            textBoxEmailcad.Size = new Size(300, 31);
            textBoxEmailcad.TabIndex = 3;
            // 
            // labelSenhacad
            // 
            labelSenhacad.Location = new Point(51, 160);
            labelSenhacad.Name = "labelSenhacad";
            labelSenhacad.Size = new Size(100, 30);
            labelSenhacad.TabIndex = 4;
            labelSenhacad.Text = "Senha:";
            // 
            // textBoxSenhacad
            // 
            textBoxSenhacad.Location = new Point(161, 160);
            textBoxSenhacad.Name = "textBoxSenhacad";
            textBoxSenhacad.PasswordChar = '*';
            textBoxSenhacad.Size = new Size(300, 31);
            textBoxSenhacad.TabIndex = 5;
            // 
            // labelSenha2cad
            // 
            labelSenha2cad.Location = new Point(51, 210);
            labelSenha2cad.Name = "labelSenha2cad";
            labelSenha2cad.Size = new Size(150, 30);
            labelSenha2cad.TabIndex = 6;
            labelSenha2cad.Text = "Confirmar Senha:";
            // 
            // textBoxConfirmarsenha
            // 
            textBoxConfirmarsenha.Location = new Point(211, 210);
            textBoxConfirmarsenha.Name = "textBoxConfirmarsenha";
            textBoxConfirmarsenha.PasswordChar = '*';
            textBoxConfirmarsenha.Size = new Size(250, 31);
            textBoxConfirmarsenha.TabIndex = 7;
            // 
            // labelAltura
            // 
            labelAltura.Location = new Point(51, 260);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new Size(100, 30);
            labelAltura.TabIndex = 8;
            labelAltura.Text = "Altura (cm):";
            // 
            // textBoxAltura
            // 
            textBoxAltura.Location = new Point(161, 260);
            textBoxAltura.Name = "textBoxAltura";
            textBoxAltura.Size = new Size(100, 31);
            textBoxAltura.TabIndex = 9;
            // 
            // labelPeso
            // 
            labelPeso.Location = new Point(51, 310);
            labelPeso.Name = "labelPeso";
            labelPeso.Size = new Size(100, 30);
            labelPeso.TabIndex = 10;
            labelPeso.Text = "Peso (kg):";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Location = new Point(161, 310);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.Size = new Size(100, 31);
            textBoxPeso.TabIndex = 11;
            // 
            // labelHoraDormir
            // 
            labelHoraDormir.Location = new Point(51, 360);
            labelHoraDormir.Name = "labelHoraDormir";
            labelHoraDormir.Size = new Size(140, 30);
            labelHoraDormir.TabIndex = 12;
            labelHoraDormir.Text = "Hora de Dormir:";
            // 
            // dateTimeHoraDormir
            // 
            dateTimeHoraDormir.Format = DateTimePickerFormat.Time;
            dateTimeHoraDormir.Location = new Point(211, 360);
            dateTimeHoraDormir.Name = "dateTimeHoraDormir";
            dateTimeHoraDormir.ShowUpDown = true;
            dateTimeHoraDormir.Size = new Size(150, 31);
            dateTimeHoraDormir.TabIndex = 13;
            // 
            // labelHoraAcordar
            // 
            labelHoraAcordar.Location = new Point(51, 400);
            labelHoraAcordar.Name = "labelHoraAcordar";
            labelHoraAcordar.Size = new Size(140, 30);
            labelHoraAcordar.TabIndex = 14;
            labelHoraAcordar.Text = "Hora de Acordar:";
            // 
            // dateTimeHoraAcordar
            // 
            dateTimeHoraAcordar.Format = DateTimePickerFormat.Time;
            dateTimeHoraAcordar.Location = new Point(211, 410);
            dateTimeHoraAcordar.Name = "dateTimeHoraAcordar";
            dateTimeHoraAcordar.ShowUpDown = true;
            dateTimeHoraAcordar.Size = new Size(150, 31);
            dateTimeHoraAcordar.TabIndex = 15;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(161, 460);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(100, 40);
            btnCadastrar.TabIndex = 16;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnVoltarCad
            // 
            btnVoltarCad.Location = new Point(269, 460);
            btnVoltarCad.Name = "btnVoltarCad";
            btnVoltarCad.Size = new Size(100, 40);
            btnVoltarCad.TabIndex = 17;
            btnVoltarCad.Text = "Voltar";
            btnVoltarCad.UseVisualStyleBackColor = true;
            btnVoltarCad.Click += btnVoltarCad_Click;
            // 
            // MenuPrincipalFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 775);
            Controls.Add(panelLogin);
            Controls.Add(panelCadastro);
            Name = "MenuPrincipalFrm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.Manual;
            Text = "RoutineSync";
            WindowState = FormWindowState.Maximized;
            Load += MenuPrincipalFrm_Load;
            SizeChanged += MenuPrincipalFrm_SizeChanged;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelCadastro.ResumeLayout(false);
            panelCadastro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCadastro;
        private Button btnLogin;

        //Cadastro
        private Panel panelCadastro;
        private Label labelCadastro;
        private Button btnCadastrar;
        private DateTimePicker dateTimeHoraAcordar;
        private DateTimePicker dateTimeHoraDormir;
        private TextBox textBoxAltura;
        private TextBox textBoxConfirmarsenha;
        private TextBox textBoxSenhacad;
        private TextBox textBoxNomecad;
        private TextBox textBoxEmailcad;
        private TextBox textBoxPeso;
        private Button btnVoltarCad;
        private Label labelNome;
        private Label labelEmailcad;
        private Label labelSenhacad;
        private Label labelSenha2cad;
        private Label labelAltura;
        private Label labelPeso;
        private Label labelHoraDormir;
        private Label labelHoraAcordar;

        //login
        private Panel panelLogin;
        private TextBox textBoxEmail;
        private TextBox textBoxSenha;
        private Button btnEntrar;
        private Label labelEmail;
        private Label labelSenha;
        private Label labelLogin;
        private Label labelTitulo;
        private LinkLabel linkRegistrar;
    }
}