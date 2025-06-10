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
            panelMenu = new Panel();
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
            btnVoltarLogin = new Button();

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

            // panelMenu
            panelMenu.BackColor = System.Drawing.Color.Transparent;
            panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panelMenu.Controls.Add(btnCadastro);
            panelMenu.Controls.Add(btnLogin);
            panelMenu.Controls.Add(labelTitulo);
            panelMenu.Location = new System.Drawing.Point(208, 45);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new System.Drawing.Size(586, 788);
            panelMenu.TabIndex = 0;
            panelMenu.Visible = false;
            panelMenu.Paint += panelMenu_Paint;

            // btnCadastro
            btnCadastro.Location = new System.Drawing.Point(237, 277);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new System.Drawing.Size(161, 67);
            btnCadastro.TabIndex = 2;
            btnCadastro.Text = "Cadastro";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnAbrirCadastro_Click;

            // btnLogin
            btnLogin.Location = new System.Drawing.Point(237, 357);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(161, 67);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;

            // labelTitulo
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            labelTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            labelTitulo.Location = new System.Drawing.Point(173, 102);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(308, 65);
            labelTitulo.TabIndex = 2;
            labelTitulo.Text = "RoutineSync";

            // panelLogin
            panelLogin.Controls.Add(labelLogin);
            panelLogin.Controls.Add(labelEmail);
            panelLogin.Controls.Add(textBoxEmail);
            panelLogin.Controls.Add(labelSenha);
            panelLogin.Controls.Add(textBoxSenha);
            panelLogin.Controls.Add(btnEntrar);
            panelLogin.Controls.Add(btnVoltarLogin);
            panelLogin.Location = new System.Drawing.Point(14, 42);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new System.Drawing.Size(601, 778);
            panelLogin.TabIndex = 1;
            panelLogin.Visible = false;
            panelLogin.Paint += panelLogin_Paint;

            // labelLogin
            labelLogin.AutoSize = true;
            labelLogin.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            labelLogin.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            labelLogin.Location = new System.Drawing.Point(171, 45);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new System.Drawing.Size(155, 65);
            labelLogin.TabIndex = 6;
            labelLogin.Text = "Login";
            labelLogin.Click += label1_Click_1;

            // labelEmail
            labelEmail.Location = new System.Drawing.Point(26, 163);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(100, 30);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";

            // textBoxEmail
            textBoxEmail.Location = new System.Drawing.Point(146, 163);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new System.Drawing.Size(300, 31);
            textBoxEmail.TabIndex = 1;

            // labelSenha
            labelSenha.Location = new System.Drawing.Point(26, 213);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new System.Drawing.Size(100, 30);
            labelSenha.TabIndex = 2;
            labelSenha.Text = "Senha:";

            // textBoxSenha
            textBoxSenha.Location = new System.Drawing.Point(146, 213);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.PasswordChar = '*';
            textBoxSenha.Size = new System.Drawing.Size(300, 31);
            textBoxSenha.TabIndex = 3;

            // btnEntrar
            btnEntrar.Location = new System.Drawing.Point(196, 273);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new System.Drawing.Size(100, 40);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;

            // btnVoltarLogin
            btnVoltarLogin.Location = new System.Drawing.Point(196, 333);
            btnVoltarLogin.Name = "btnVoltarLogin";
            btnVoltarLogin.Size = new System.Drawing.Size(100, 40);
            btnVoltarLogin.TabIndex = 5;
            btnVoltarLogin.Text = "Voltar";
            btnVoltarLogin.UseVisualStyleBackColor = true;
            btnVoltarLogin.Click += btnVoltarlogin_Click;

            // panelCadastro
            panelCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            panelCadastro.Location = new System.Drawing.Point(3, 35);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Size = new System.Drawing.Size(876, 523);
            panelCadastro.TabIndex = 2;
            panelCadastro.Visible = false;
            panelCadastro.Paint += panelCadastro_Paint;

            // labelCadastro
            labelCadastro.AutoSize = true;
            labelCadastro.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelCadastro.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            labelCadastro.Location = new System.Drawing.Point(160, 10);
            labelCadastro.Name = "labelCadastro";
            labelCadastro.Size = new System.Drawing.Size(168, 48);
            labelCadastro.TabIndex = 99;
            labelCadastro.Text = "Cadastro";

            // labelNome
            labelNome.Location = new System.Drawing.Point(51, 60);
            labelNome.Name = "labelNome";
            labelNome.Size = new System.Drawing.Size(100, 30);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome:";

            // textBoxNomecad
            textBoxNomecad.Location = new System.Drawing.Point(161, 60);
            textBoxNomecad.Name = "textBoxNomecad";
            textBoxNomecad.Size = new System.Drawing.Size(300, 31);
            textBoxNomecad.TabIndex = 1;

            // labelEmailcad
            labelEmailcad.Location = new System.Drawing.Point(51, 110);
            labelEmailcad.Name = "labelEmailcad";
            labelEmailcad.Size = new System.Drawing.Size(100, 30);
            labelEmailcad.TabIndex = 2;
            labelEmailcad.Text = "Email:";

            // textBoxEmailcad
            textBoxEmailcad.Location = new System.Drawing.Point(161, 110);
            textBoxEmailcad.Name = "textBoxEmailcad";
            textBoxEmailcad.Size = new System.Drawing.Size(300, 31);
            textBoxEmailcad.TabIndex = 3;

            // labelSenhacad
            labelSenhacad.Location = new System.Drawing.Point(51, 160);
            labelSenhacad.Name = "labelSenhacad";
            labelSenhacad.Size = new System.Drawing.Size(100, 30);
            labelSenhacad.TabIndex = 4;
            labelSenhacad.Text = "Senha:";

            // textBoxSenhacad
            textBoxSenhacad.Location = new System.Drawing.Point(161, 160);
            textBoxSenhacad.Name = "textBoxSenhacad";
            textBoxSenhacad.PasswordChar = '*';
            textBoxSenhacad.Size = new System.Drawing.Size(300, 31);
            textBoxSenhacad.TabIndex = 5;

            // labelSenha2cad
            labelSenha2cad.Location = new System.Drawing.Point(51, 210);
            labelSenha2cad.Name = "labelSenha2cad";
            labelSenha2cad.Size = new System.Drawing.Size(150, 30);
            labelSenha2cad.TabIndex = 6;
            labelSenha2cad.Text = "Confirmar Senha:";

            // textBoxConfirmarsenha
            textBoxConfirmarsenha.Location = new System.Drawing.Point(211, 210);
            textBoxConfirmarsenha.Name = "textBoxConfirmarsenha";
            textBoxConfirmarsenha.PasswordChar = '*';
            textBoxConfirmarsenha.Size = new System.Drawing.Size(250, 31);
            textBoxConfirmarsenha.TabIndex = 7;

            // labelAltura
            labelAltura.Location = new System.Drawing.Point(51, 260);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new System.Drawing.Size(100, 30);
            labelAltura.TabIndex = 8;
            labelAltura.Text = "Altura (cm):";

            // textBoxAltura
            textBoxAltura.Location = new System.Drawing.Point(161, 260);
            textBoxAltura.Name = "textBoxAltura";
            textBoxAltura.Size = new System.Drawing.Size(100, 31);
            textBoxAltura.TabIndex = 9;

            // labelPeso
            labelPeso.Location = new System.Drawing.Point(51, 310);
            labelPeso.Name = "labelPeso";
            labelPeso.Size = new System.Drawing.Size(100, 30);
            labelPeso.TabIndex = 10;
            labelPeso.Text = "Peso (kg):";

            // textBoxPeso
            textBoxPeso.Location = new System.Drawing.Point(161, 310);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.Size = new System.Drawing.Size(100, 31);
            textBoxPeso.TabIndex = 11;

            // labelHoraDormir
            labelHoraDormir.Location = new System.Drawing.Point(51, 360);
            labelHoraDormir.Name = "labelHoraDormir";
            labelHoraDormir.Size = new System.Drawing.Size(140, 30);
            labelHoraDormir.TabIndex = 12;
            labelHoraDormir.Text = "Hora de Dormir:";

            // dateTimeHoraDormir
            dateTimeHoraDormir.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dateTimeHoraDormir.Location = new System.Drawing.Point(211, 360);
            dateTimeHoraDormir.Name = "dateTimeHoraDormir";
            dateTimeHoraDormir.ShowUpDown = true;
            dateTimeHoraDormir.Size = new System.Drawing.Size(150, 31);
            dateTimeHoraDormir.TabIndex = 13;

            // labelHoraAcordar
            labelHoraAcordar.Location = new System.Drawing.Point(51, 400);
            labelHoraAcordar.Name = "labelHoraAcordar";
            labelHoraAcordar.Size = new System.Drawing.Size(140, 30);
            labelHoraAcordar.TabIndex = 14;
            labelHoraAcordar.Text = "Hora de Acordar:";

            // dateTimeHoraAcordar
            dateTimeHoraAcordar.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            dateTimeHoraAcordar.Location = new System.Drawing.Point(211, 410);
            dateTimeHoraAcordar.Name = "dateTimeHoraAcordar";
            dateTimeHoraAcordar.ShowUpDown = true;
            dateTimeHoraAcordar.Size = new System.Drawing.Size(150, 31);
            dateTimeHoraAcordar.TabIndex = 15;

            // btnCadastrar
            btnCadastrar.Location = new System.Drawing.Point(161, 460);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new System.Drawing.Size(100, 40);
            btnCadastrar.TabIndex = 16;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;

            // btnVoltarCad
            btnVoltarCad.Location = new System.Drawing.Point(269, 460);
            btnVoltarCad.Name = "btnVoltarCad";
            btnVoltarCad.Size = new System.Drawing.Size(100, 40);
            btnVoltarCad.TabIndex = 17;
            btnVoltarCad.Text = "Voltar";
            btnVoltarCad.UseVisualStyleBackColor = true;
            btnVoltarCad.Click += btnVoltarCad_Click;

            // MenuPrincipalFrm
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 775);
            this.Controls.Add(panelMenu);
            this.Controls.Add(panelLogin);
            this.Controls.Add(panelCadastro);
            this.Name = "MenuPrincipalFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RoutineSync";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += MenuPrincipalFrm_Load;
            this.SizeChanged += MenuPrincipalFrm_SizeChanged;

            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelCadastro.ResumeLayout(false);
            panelCadastro.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Button btnCadastro;
        private Button btnLogin;
        private Button btnVoltarLogin;

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
        private Panel panelMenu;
        private Label labelLogin;
        private Label labelTitulo;
    }
}