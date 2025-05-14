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
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelSenha = new Label();
            textBoxSenha = new TextBox();
            btnEntrar = new Button();
            btnVoltarLogin = new Button();
            btnCadastro = new Button();
            btnLogin = new Button();
            labelTitulo = new Label();
            panelMenu = new Panel();
            panelLogin.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(labelEmail);
            panelLogin.Controls.Add(textBoxEmail);
            panelLogin.Controls.Add(labelSenha);
            panelLogin.Controls.Add(textBoxSenha);
            panelLogin.Controls.Add(btnEntrar);
            panelLogin.Controls.Add(btnVoltarLogin);
            panelLogin.Location = new Point(235, 206);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(500, 300);
            panelLogin.TabIndex = 0;
            // 
            // labelEmail
            // 
            labelEmail.Location = new Point(30, 30);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 30);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(150, 30);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(300, 31);
            textBoxEmail.TabIndex = 1;
            // 
            // labelSenha
            // 
            labelSenha.Location = new Point(30, 80);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(100, 30);
            labelSenha.TabIndex = 2;
            labelSenha.Text = "Senha:";
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(150, 80);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.PasswordChar = '*';
            textBoxSenha.Size = new Size(300, 31);
            textBoxSenha.TabIndex = 3;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(200, 140);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(100, 40);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnVoltarLogin
            // 
            btnVoltarLogin.Location = new Point(200, 200);
            btnVoltarLogin.Name = "btnVoltarLogin";
            btnVoltarLogin.Size = new Size(100, 40);
            btnVoltarLogin.TabIndex = 5;
            btnVoltarLogin.Text = "Voltar";
            btnVoltarLogin.UseVisualStyleBackColor = true;
            btnVoltarLogin.Click += btnVoltarlogin_Click;
            // 
            // btnCadastro
            // 
            btnCadastro.Location = new Point(237, 246);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(162, 68);
            btnCadastro.TabIndex = 0;
            btnCadastro.Text = "Cadastro";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(237, 379);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 67);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.ForeColor = SystemColors.ActiveCaption;
            labelTitulo.Location = new Point(173, 101);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(308, 65);
            labelTitulo.TabIndex = 2;
            labelTitulo.Text = "RoutineSync";
            // 
            // panelMenu
            // 
            panelMenu.BorderStyle = BorderStyle.Fixed3D;
            panelMenu.Controls.Add(btnCadastro);
            panelMenu.Controls.Add(btnLogin);
            panelMenu.Controls.Add(labelTitulo);
            panelMenu.Location = new Point(169, 25);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(624, 580);
            panelMenu.TabIndex = 1;
            panelMenu.Visible = false;
            panelMenu.Paint += panelMenu_Paint;
            // 
            // MenuPrincipalFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 632);
            Controls.Add(panelMenu);
            Controls.Add(panelLogin);
            Name = "MenuPrincipalFrm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.Manual;
            Text = "RoutineSync";
            WindowState = FormWindowState.Maximized;
            Load += MenuPrincipalFrm_Load;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private Button btnCadastro;
        private Button btnLogin;
        private Label labelTitulo;
        private Button btnVoltarLogin;
        


        //login
        private Panel panelLogin;
        private TextBox textBoxEmail;
        private TextBox textBoxSenha;
        private Button btnEntrar;
        private Label labelEmail;
        private Label labelSenha;
        private Panel panelMenu;
    }
}
