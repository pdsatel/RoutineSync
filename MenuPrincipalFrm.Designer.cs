using System.Security.Authentication;

namespace Tcc
{
    partial class MenuPrincipalFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelLogin = new Panel();
            labelLogin = new Label();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelSenha = new Label();
            textBoxSenha = new TextBox();
            btnEntrar = new Button();
            btnVoltarLogin = new Button();
            btnCadastro = new Button();
            btnLogin = new Button();
            panelMenu = new Panel();
            labelTitulo = new Label();
            panelCadastro = new Panel();
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
            panelMenu.SuspendLayout();
            panelCadastro.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(labelLogin);
            panelLogin.Controls.Add(labelEmail);
            panelLogin.Controls.Add(textBoxEmail);
            panelLogin.Controls.Add(labelSenha);
            panelLogin.Controls.Add(textBoxSenha);
            panelLogin.Controls.Add(btnEntrar);
            panelLogin.Controls.Add(btnVoltarLogin);
            panelLogin.Location = new Point(164, 46);
            panelLogin.Margin = new Padding(2);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(350, 258);
            panelLogin.TabIndex = 0;
            panelLogin.Paint += panelLogin_Paint;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.ForeColor = SystemColors.ActiveCaption;
            labelLogin.Location = new Point(120, 27);
            labelLogin.Margin = new Padding(2, 0, 2, 0);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(104, 45);
            labelLogin.TabIndex = 6;
            labelLogin.Text = "Login";
            labelLogin.Click += label1_Click_1;
            // 
            // labelEmail
            // 
            labelEmail.Location = new Point(18, 98);
            labelEmail.Margin = new Padding(2, 0, 2, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(70, 18);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(102, 98);
            textBoxEmail.Margin = new Padding(2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(211, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // labelSenha
            // 
            labelSenha.Location = new Point(18, 128);
            labelSenha.Margin = new Padding(2, 0, 2, 0);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(70, 18);
            labelSenha.TabIndex = 2;
            labelSenha.Text = "Senha:";
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(102, 128);
            textBoxSenha.Margin = new Padding(2);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.PasswordChar = '*';
            textBoxSenha.Size = new Size(211, 23);
            textBoxSenha.TabIndex = 3;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(137, 164);
            btnEntrar.Margin = new Padding(2);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(70, 24);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnVoltarLogin
            // 
            btnVoltarLogin.Location = new Point(137, 200);
            btnVoltarLogin.Margin = new Padding(2);
            btnVoltarLogin.Name = "btnVoltarLogin";
            btnVoltarLogin.Size = new Size(70, 24);
            btnVoltarLogin.TabIndex = 5;
            btnVoltarLogin.Text = "Voltar";
            btnVoltarLogin.UseVisualStyleBackColor = true;
            btnVoltarLogin.Click += btnVoltarlogin_Click;
            // 
            // btnCadastro
            // 
            btnCadastro.Location = new Point(166, 166);
            btnCadastro.Margin = new Padding(2);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(113, 40);
            btnCadastro.TabIndex = 2;
            btnCadastro.Text = "Cadastro";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnAbrirCadastro_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(166, 214);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(113, 40);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panelMenu
            // 
            panelMenu.BorderStyle = BorderStyle.Fixed3D;
            panelMenu.Controls.Add(btnCadastro);
            panelMenu.Controls.Add(btnLogin);
            panelMenu.Controls.Add(labelTitulo);
            panelMenu.Location = new Point(118, 23);
            panelMenu.Margin = new Padding(2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(431, 346);
            panelMenu.TabIndex = 1;
            panelMenu.Paint += panelMenu_Paint;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.ForeColor = SystemColors.ActiveCaption;
            labelTitulo.Location = new Point(121, 61);
            labelTitulo.Margin = new Padding(2, 0, 2, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(204, 45);
            labelTitulo.TabIndex = 2;
            labelTitulo.Text = "RoutineSync";




            // labelCadastro
            labelCadastro = new Label();
            labelCadastro.AutoSize = true;
            labelCadastro.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelCadastro.ForeColor = SystemColors.ActiveCaption;
            labelCadastro.Location = new Point(5, 10); // centralizado no topo
            labelCadastro.Name = "labelCadastro";
            labelCadastro.Size = new Size(180, 32);
            labelCadastro.TabIndex = 99;
            labelCadastro.Text = "Cadastro";




            // panelCadastro


            panelCadastro.BackColor = Color.White;
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
            panelCadastro.Location = new Point(40, 21);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Size = new Size(351, 360);
            panelCadastro.TabIndex = 0;
            panelCadastro.Paint += panelCadastro_Paint_1;

            
            // 
            // labelNome
            // 
            labelNome.Location = new Point(36, 55);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(70, 18);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome:";
            // 
            // textBoxNomecad
            // 
            textBoxNomecad.Location = new Point(113, 55);
            textBoxNomecad.Name = "textBoxNomecad";
            textBoxNomecad.Size = new Size(211, 23);
            textBoxNomecad.TabIndex = 1;
            // 
            // labelEmailcad
            // 
            labelEmailcad.Location = new Point(36, 79);
            labelEmailcad.Name = "labelEmailcad";
            labelEmailcad.Size = new Size(70, 18);
            labelEmailcad.TabIndex = 2;
            labelEmailcad.Text = "Email:";
            // 
            // textBoxEmailcad
            // 
            textBoxEmailcad.Location = new Point(113, 79);
            textBoxEmailcad.Name = "textBoxEmailcad";
            textBoxEmailcad.Size = new Size(211, 23);
            textBoxEmailcad.TabIndex = 3;
            // 
            // labelSenhacad
            // 
            labelSenhacad.Location = new Point(36, 103);
            labelSenhacad.Name = "labelSenhacad";
            labelSenhacad.Size = new Size(70, 18);
            labelSenhacad.TabIndex = 4;
            labelSenhacad.Text = "Senha:";
            // 
            // textBoxSenhacad
            // 
            textBoxSenhacad.Location = new Point(113, 103);
            textBoxSenhacad.Name = "textBoxSenhacad";
            textBoxSenhacad.PasswordChar = '*';
            textBoxSenhacad.Size = new Size(211, 23);
            textBoxSenhacad.TabIndex = 5;
            // 
            // labelSenha2cad
            // 
            labelSenha2cad.Location = new Point(36, 127);
            labelSenha2cad.Name = "labelSenha2cad";
            labelSenha2cad.Size = new Size(105, 18);
            labelSenha2cad.TabIndex = 6;
            labelSenha2cad.Text = "Confirmar Senha:";
            // 
            // textBoxConfirmarsenha
            // 
            textBoxConfirmarsenha.Location = new Point(148, 127);
            textBoxConfirmarsenha.Name = "textBoxConfirmarsenha";
            textBoxConfirmarsenha.PasswordChar = '*';
            textBoxConfirmarsenha.Size = new Size(176, 23);
            textBoxConfirmarsenha.TabIndex = 7;
            // 
            // labelAltura
            // 
            labelAltura.Location = new Point(36, 151);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new Size(70, 18);
            labelAltura.TabIndex = 8;
            labelAltura.Text = "Altura (cm):";
            // 
            // textBoxAltura
            // 
            textBoxAltura.Location = new Point(113, 151);
            textBoxAltura.Name = "textBoxAltura";
            textBoxAltura.Size = new Size(71, 23);
            textBoxAltura.TabIndex = 9;
            // 
            // labelPeso
            // 
            labelPeso.Location = new Point(36, 175);
            labelPeso.Name = "labelPeso";
            labelPeso.Size = new Size(70, 18);
            labelPeso.TabIndex = 10;
            labelPeso.Text = "Peso (kg):";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Location = new Point(113, 175);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.Size = new Size(71, 23);
            textBoxPeso.TabIndex = 11;
            // 
            // labelHoraDormir
            // 
            labelHoraDormir.Location = new Point(36, 199);
            labelHoraDormir.Name = "labelHoraDormir";
            labelHoraDormir.Size = new Size(98, 18);
            labelHoraDormir.TabIndex = 12;
            labelHoraDormir.Text = "Hora de Dormir:";
            // 
            // dateTimeHoraDormir
            // 
            dateTimeHoraDormir.Format = DateTimePickerFormat.Time;
            dateTimeHoraDormir.Location = new Point(148, 199);
            dateTimeHoraDormir.Name = "dateTimeHoraDormir";
            dateTimeHoraDormir.ShowUpDown = true;
            dateTimeHoraDormir.Size = new Size(106, 23);
            dateTimeHoraDormir.TabIndex = 13;
            // 
            // labelHoraAcordar
            // 
            labelHoraAcordar.Location = new Point(36, 223);
            labelHoraAcordar.Name = "labelHoraAcordar";
            labelHoraAcordar.Size = new Size(98, 18);
            labelHoraAcordar.TabIndex = 14;
            labelHoraAcordar.Text = "Hora de Acordar:";
            // 
            // dateTimeHoraAcordar
            // 
            dateTimeHoraAcordar.Format = DateTimePickerFormat.Time;
            dateTimeHoraAcordar.Location = new Point(148, 223);
            dateTimeHoraAcordar.Name = "dateTimeHoraAcordar";
            dateTimeHoraAcordar.ShowUpDown = true;
            dateTimeHoraAcordar.Size = new Size(106, 23);
            dateTimeHoraAcordar.TabIndex = 15;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(113, 259);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(70, 24);
            btnCadastrar.TabIndex = 16;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnVoltarCad
            // 
            btnVoltarCad.Location = new Point(188, 259);
            btnVoltarCad.Name = "btnVoltarCad";
            btnVoltarCad.Size = new Size(70, 24);
            btnVoltarCad.TabIndex = 17;
            btnVoltarCad.Text = "Voltar";
            btnVoltarCad.UseVisualStyleBackColor = true;
            btnVoltarCad.Click += btnVoltarCad_Click;
            // 
            // MenuPrincipalFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 596);
            Controls.Add(panelCadastro);
            Controls.Add(panelMenu);
            Controls.Add(panelLogin);
            Margin = new Padding(2);
            Name = "MenuPrincipalFrm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.Manual;
            Text = "RoutineSync";
            Load += MenuPrincipalFrm_Load;
            SizeChanged += MenuPrincipalFrm_SizeChanged;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelCadastro.ResumeLayout(false);
            panelCadastro.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private Button btnCadastro;
        private Button btnLogin;
        private Button btnVoltarLogin;

        //Cadastro
        private Panel panelCadastro;
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
        private Label labelCadastro;







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
