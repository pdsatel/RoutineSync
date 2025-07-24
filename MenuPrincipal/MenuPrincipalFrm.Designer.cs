namespace Tcc
{
    partial class MenuPrincipalFrm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelDireita;
        private PictureBox pictureBoxLogo;

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
            labelTitulo = new Label();
            panelLogin = new Panel();
            labelLogin = new Label();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelSenha = new Label();
            textBoxSenha = new TextBox();
            btnEntrar = new Button();
            linkRegistrar = new LinkLabel();
            linkEsqueciSenha = new LinkLabel();
            pictureBoxOlhoLogin = new PictureBox();
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
            pictureBoxOlhoSenhaCadastro = new PictureBox();
            pictureBoxOlhoConfirmarSenha = new PictureBox();
            panelDireita = new Panel();
            pictureBoxLogo = new PictureBox();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOlhoLogin).BeginInit();
            panelCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOlhoSenhaCadastro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOlhoConfirmarSenha).BeginInit();
            panelDireita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
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
            panelLogin.Controls.Add(linkEsqueciSenha);
            panelLogin.Controls.Add(pictureBoxOlhoLogin);
            panelLogin.Location = new Point(2, 21);
            panelLogin.Margin = new Padding(2, 2, 2, 2);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(491, 527);
            panelLogin.TabIndex = 1;
            panelLogin.Visible = false;
            panelLogin.Paint += panelLogin_Paint;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            labelLogin.ForeColor = SystemColors.ActiveCaption;
            labelLogin.Location = new Point(421, 27);
            labelLogin.Margin = new Padding(2, 0, 2, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(104, 45);
            labelLogin.TabIndex = 6;
            labelLogin.Text = "Login";
            labelLogin.Click += label1_Click_1;
            // 
            // labelEmail
            // 
            labelEmail.Location = new Point(421, 84);
            labelEmail.Margin = new Padding(2, 0, 2, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(70, 18);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(421, 102);
            textBoxEmail.Margin = new Padding(2, 2, 2, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(211, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // labelSenha
            // 
            labelSenha.Location = new Point(421, 129);
            labelSenha.Margin = new Padding(2, 0, 2, 0);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(70, 18);
            labelSenha.TabIndex = 2;
            labelSenha.Text = "Senha:";
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(434, 147);
            textBoxSenha.Margin = new Padding(2, 2, 2, 2);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.Size = new Size(187, 23);
            textBoxSenha.TabIndex = 3;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(421, 180);
            btnEntrar.Margin = new Padding(2, 2, 2, 2);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(7, 18);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // linkRegistrar
            // 
            linkRegistrar.AutoSize = true;
            linkRegistrar.Location = new Point(421, 216);
            linkRegistrar.Name = "linkRegistrar";
            linkRegistrar.Size = new Size(179, 15);
            linkRegistrar.TabIndex = 8;
            linkRegistrar.TabStop = true;
            linkRegistrar.Text = "Não tem uma conta? Registre-se";
            linkRegistrar.Click += linkRegistrar_Click;
            // 
            // linkEsqueciSenha
            // 
            linkEsqueciSenha.AutoSize = true;
            linkEsqueciSenha.Location = new Point(421, 240);
            linkEsqueciSenha.Margin = new Padding(2, 0, 2, 0);
            linkEsqueciSenha.Name = "linkEsqueciSenha";
            linkEsqueciSenha.Size = new Size(118, 15);
            linkEsqueciSenha.TabIndex = 9;
            linkEsqueciSenha.TabStop = true;
            linkEsqueciSenha.Text = "Esqueci minha senha";
            linkEsqueciSenha.Click += linkEsqueciSenha_Click;
            // 
            // pictureBoxOlhoLogin
            // 
            pictureBoxOlhoLogin.Cursor = Cursors.Hand;
            pictureBoxOlhoLogin.Image = Properties.Resources.eye_close;
            pictureBoxOlhoLogin.Location = new Point(434, 147);
            pictureBoxOlhoLogin.Margin = new Padding(2, 2, 2, 2);
            pictureBoxOlhoLogin.Name = "pictureBoxOlhoLogin";
            pictureBoxOlhoLogin.Size = new Size(21, 17);
            pictureBoxOlhoLogin.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOlhoLogin.TabIndex = 10;
            pictureBoxOlhoLogin.TabStop = false;
            // 
            // panelCadastro
            // 
            panelCadastro.BackColor = Color.White;
            panelCadastro.BorderStyle = BorderStyle.FixedSingle;
            panelCadastro.Controls.Add(pictureBoxOlhoSenhaCadastro);
            panelCadastro.Controls.Add(pictureBoxOlhoConfirmarSenha);
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
            panelCadastro.Location = new Point(199, 36);
            panelCadastro.Margin = new Padding(2, 2, 2, 2);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Size = new Size(491, 325);
            panelCadastro.TabIndex = 2;
            panelCadastro.Visible = false;
            // 
            // labelCadastro
            // 
            labelCadastro.AutoSize = true;
            labelCadastro.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            labelCadastro.ForeColor = SystemColors.ActiveCaption;
            labelCadastro.Location = new Point(490, 13);
            labelCadastro.Margin = new Padding(2, 0, 2, 0);
            labelCadastro.Name = "labelCadastro";
            labelCadastro.Size = new Size(132, 37);
            labelCadastro.TabIndex = 0;
            labelCadastro.Text = "Cadastro";
            // 
            // labelNome
            // 
            labelNome.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelNome.Location = new Point(38, 54);
            labelNome.Margin = new Padding(2, 0, 2, 0);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(84, 17);
            labelNome.TabIndex = 1;
            labelNome.Text = "Nome:";
            // 
            // textBoxNomecad
            // 
            textBoxNomecad.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNomecad.Location = new Point(252, 54);
            textBoxNomecad.Margin = new Padding(2, 2, 2, 2);
            textBoxNomecad.Name = "textBoxNomecad";
            textBoxNomecad.Size = new Size(187, 27);
            textBoxNomecad.TabIndex = 2;
            // 
            // labelEmailcad
            // 
            labelEmailcad.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmailcad.Location = new Point(38, 54);
            labelEmailcad.Margin = new Padding(2, 0, 2, 0);
            labelEmailcad.Name = "labelEmailcad";
            labelEmailcad.Size = new Size(84, 17);
            labelEmailcad.TabIndex = 3;
            labelEmailcad.Text = "Email:";
            // 
            // textBoxEmailcad
            // 
            textBoxEmailcad.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmailcad.Location = new Point(252, 54);
            textBoxEmailcad.Margin = new Padding(2, 2, 2, 2);
            textBoxEmailcad.Name = "textBoxEmailcad";
            textBoxEmailcad.Size = new Size(187, 27);
            textBoxEmailcad.TabIndex = 4;
            // 
            // labelSenhacad
            // 
            labelSenhacad.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelSenhacad.Location = new Point(38, 54);
            labelSenhacad.Margin = new Padding(2, 0, 2, 0);
            labelSenhacad.Name = "labelSenhacad";
            labelSenhacad.Size = new Size(84, 17);
            labelSenhacad.TabIndex = 5;
            labelSenhacad.Text = "Senha:";
            // 
            // textBoxSenhacad
            // 
            textBoxSenhacad.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSenhacad.Location = new Point(252, 54);
            textBoxSenhacad.Margin = new Padding(2, 2, 2, 2);
            textBoxSenhacad.Name = "textBoxSenhacad";
            textBoxSenhacad.Size = new Size(187, 27);
            textBoxSenhacad.TabIndex = 6;
            // 
            // labelSenha2cad
            // 
            labelSenha2cad.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelSenha2cad.Location = new Point(38, 54);
            labelSenha2cad.Margin = new Padding(2, 0, 2, 0);
            labelSenha2cad.Name = "labelSenha2cad";
            labelSenha2cad.Size = new Size(84, 17);
            labelSenha2cad.TabIndex = 7;
            labelSenha2cad.Text = "Confirmar Senha:";
            // 
            // textBoxConfirmarsenha
            // 
            textBoxConfirmarsenha.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxConfirmarsenha.Location = new Point(252, 54);
            textBoxConfirmarsenha.Margin = new Padding(2, 2, 2, 2);
            textBoxConfirmarsenha.Name = "textBoxConfirmarsenha";
            textBoxConfirmarsenha.Size = new Size(187, 27);
            textBoxConfirmarsenha.TabIndex = 8;
            // 
            // labelAltura
            // 
            labelAltura.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelAltura.Location = new Point(38, 54);
            labelAltura.Margin = new Padding(2, 0, 2, 0);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new Size(84, 17);
            labelAltura.TabIndex = 9;
            labelAltura.Text = "Altura (cm):";
            // 
            // textBoxAltura
            // 
            textBoxAltura.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxAltura.Location = new Point(252, 54);
            textBoxAltura.Margin = new Padding(2, 2, 2, 2);
            textBoxAltura.Name = "textBoxAltura";
            textBoxAltura.Size = new Size(57, 27);
            textBoxAltura.TabIndex = 10;
            // 
            // labelPeso
            // 
            labelPeso.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelPeso.Location = new Point(38, 54);
            labelPeso.Margin = new Padding(2, 0, 2, 0);
            labelPeso.Name = "labelPeso";
            labelPeso.Size = new Size(84, 17);
            labelPeso.TabIndex = 11;
            labelPeso.Text = "Peso (kg):";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPeso.Location = new Point(252, 54);
            textBoxPeso.Margin = new Padding(2, 2, 2, 2);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.Size = new Size(57, 27);
            textBoxPeso.TabIndex = 12;
            // 
            // labelHoraDormir
            // 
            labelHoraDormir.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelHoraDormir.Location = new Point(38, 54);
            labelHoraDormir.Margin = new Padding(2, 0, 2, 0);
            labelHoraDormir.Name = "labelHoraDormir";
            labelHoraDormir.Size = new Size(84, 17);
            labelHoraDormir.TabIndex = 13;
            labelHoraDormir.Text = "Hora de Dormir:";
            // 
            // dateTimeHoraDormir
            // 
            dateTimeHoraDormir.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeHoraDormir.Format = DateTimePickerFormat.Time;
            dateTimeHoraDormir.Location = new Point(252, 54);
            dateTimeHoraDormir.Margin = new Padding(2, 2, 2, 2);
            dateTimeHoraDormir.Name = "dateTimeHoraDormir";
            dateTimeHoraDormir.ShowUpDown = true;
            dateTimeHoraDormir.Size = new Size(71, 27);
            dateTimeHoraDormir.TabIndex = 14;
            // 
            // labelHoraAcordar
            // 
            labelHoraAcordar.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelHoraAcordar.Location = new Point(38, 54);
            labelHoraAcordar.Margin = new Padding(2, 0, 2, 0);
            labelHoraAcordar.Name = "labelHoraAcordar";
            labelHoraAcordar.Size = new Size(84, 17);
            labelHoraAcordar.TabIndex = 15;
            labelHoraAcordar.Text = "Hora de Acordar:";
            // 
            // dateTimeHoraAcordar
            // 
            dateTimeHoraAcordar.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimeHoraAcordar.Format = DateTimePickerFormat.Time;
            dateTimeHoraAcordar.Location = new Point(252, 54);
            dateTimeHoraAcordar.Margin = new Padding(2, 2, 2, 2);
            dateTimeHoraAcordar.Name = "dateTimeHoraAcordar";
            dateTimeHoraAcordar.ShowUpDown = true;
            dateTimeHoraAcordar.Size = new Size(71, 27);
            dateTimeHoraAcordar.TabIndex = 16;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnCadastrar.Location = new Point(490, 324);
            btnCadastrar.Margin = new Padding(2, 2, 2, 2);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(84, 23);
            btnCadastrar.TabIndex = 17;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnVoltarCad
            // 
            btnVoltarCad.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnVoltarCad.Location = new Point(490, 324);
            btnVoltarCad.Margin = new Padding(2, 2, 2, 2);
            btnVoltarCad.Name = "btnVoltarCad";
            btnVoltarCad.Size = new Size(84, 23);
            btnVoltarCad.TabIndex = 18;
            btnVoltarCad.Text = "Voltar";
            btnVoltarCad.UseVisualStyleBackColor = true;
            btnVoltarCad.Click += btnVoltarCad_Click;
            // 
            // pictureBoxOlhoSenhaCadastro
            // 
            pictureBoxOlhoSenhaCadastro.Cursor = Cursors.Hand;
            pictureBoxOlhoSenhaCadastro.Image = Properties.Resources.eye_close;
            pictureBoxOlhoSenhaCadastro.Location = new Point(252, 54);
            pictureBoxOlhoSenhaCadastro.Margin = new Padding(2, 2, 2, 2);
            pictureBoxOlhoSenhaCadastro.Name = "pictureBoxOlhoSenhaCadastro";
            pictureBoxOlhoSenhaCadastro.Size = new Size(18, 16);
            pictureBoxOlhoSenhaCadastro.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOlhoSenhaCadastro.TabIndex = 19;
            pictureBoxOlhoSenhaCadastro.TabStop = false;
            // 
            // pictureBoxOlhoConfirmarSenha
            // 
            pictureBoxOlhoConfirmarSenha.Cursor = Cursors.Hand;
            pictureBoxOlhoConfirmarSenha.Image = Properties.Resources.eye_close;
            pictureBoxOlhoConfirmarSenha.Location = new Point(252, 54);
            pictureBoxOlhoConfirmarSenha.Margin = new Padding(2, 2, 2, 2);
            pictureBoxOlhoConfirmarSenha.Name = "pictureBoxOlhoConfirmarSenha";
            pictureBoxOlhoConfirmarSenha.Size = new Size(18, 16);
            pictureBoxOlhoConfirmarSenha.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOlhoConfirmarSenha.TabIndex = 20;
            pictureBoxOlhoConfirmarSenha.TabStop = false;
            // 
            // panelDireita
            // 
            panelDireita.BackColor = Color.FromArgb(32, 46, 57);
            panelDireita.Controls.Add(pictureBoxLogo);
            panelDireita.Dock = DockStyle.Right;
            panelDireita.Location = new Point(646, 0);
            panelDireita.Margin = new Padding(2, 2, 2, 2);
            panelDireita.Name = "panelDireita";
            panelDireita.Size = new Size(199, 449);
            panelDireita.TabIndex = 100;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Location = new Point(199, 60);
            pictureBoxLogo.Margin = new Padding(2, 2, 2, 2);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(154, 132);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // MenuPrincipalFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 449);
            Controls.Add(panelLogin);
            Controls.Add(panelCadastro);
            Controls.Add(panelDireita);
            Margin = new Padding(2, 2, 2, 2);
            Name = "MenuPrincipalFrm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.Manual;
            Text = "RoutineSync";
            WindowState = FormWindowState.Maximized;
            Load += MenuPrincipalFrm_Load;
            SizeChanged += MenuPrincipalFrm_SizeChanged;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOlhoLogin).EndInit();
            panelCadastro.ResumeLayout(false);
            panelCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOlhoSenhaCadastro).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOlhoConfirmarSenha).EndInit();
            panelDireita.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);

            // Garante que a logo fique centralizada mesmo se redimensionar
        }

        #endregion



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
        private LinkLabel linkEsqueciSenha;



        private System.Windows.Forms.PictureBox pictureBoxOlhoSenhaCadastro;
        private System.Windows.Forms.PictureBox pictureBoxOlhoConfirmarSenha;
        private System.Windows.Forms.PictureBox pictureBoxOlhoLogin;
    }
}