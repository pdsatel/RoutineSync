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
            panelLogin.Location = new Point(3, 35);
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

            linkEsqueciSenha = new LinkLabel();
            linkEsqueciSenha.AutoSize = true;
            linkEsqueciSenha.Location = new Point(601, 400); // Ajuste a posição conforme necessário
            linkEsqueciSenha.Name = "linkEsqueciSenha";
            linkEsqueciSenha.Size = new Size(200, 25);
            linkEsqueciSenha.TabIndex = 9;
            linkEsqueciSenha.TabStop = true;
            linkEsqueciSenha.Text = "Esqueci minha senha";
            linkEsqueciSenha.Click += linkEsqueciSenha_Click;
            panelLogin.Controls.Add(linkEsqueciSenha);

            // 
            // panelCadastro
            // 
            panelCadastro.BorderStyle = BorderStyle.FixedSingle;
            panelCadastro.Size = new Size(700, 540); // Diminuiu: menos largo e mais baixo
            panelCadastro.Location = new Point((this.ClientSize.Width - panelCadastro.Width) / 2, 60);
            panelCadastro.BackColor = Color.White;
            panelCadastro.Visible = false;
            panelCadastro.Controls.Clear();
            panelCadastro.Controls.AddRange(new Control[] {
            labelCadastro, labelNome, textBoxNomecad, labelEmailcad, textBoxEmailcad,
            labelSenhacad, textBoxSenhacad, labelSenha2cad, textBoxConfirmarsenha,
            labelAltura, textBoxAltura, labelPeso, textBoxPeso,
            labelHoraDormir, dateTimeHoraDormir, labelHoraAcordar, dateTimeHoraAcordar,
            btnCadastrar, btnVoltarCad });

            // labelCadastro
            labelCadastro.AutoSize = true;
            labelCadastro.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelCadastro.ForeColor = SystemColors.ActiveCaption;
            labelCadastro.Location = new Point((panelCadastro.Width - 180) / 2, 22);
            labelCadastro.Size = new Size(180, 50);
            labelCadastro.Text = "Cadastro";

            // Parâmetros para campos menores e espaçamento
            int campoLargura = 265;
            int campoAltura = 28;
            int labelLargura = 120;
            int xLabel = 55;
            int xCampo = xLabel + labelLargura + 8;
            int yInicio = 90;
            int yStep = 44;

            // labelNome
            labelNome.Location = new Point(xLabel, yInicio);
            labelNome.Size = new Size(labelLargura, campoAltura);
            labelNome.Text = "Nome:";
            labelNome.Font = new Font("Segoe UI", 11F);

            // textBoxNomecad
            textBoxNomecad.Location = new Point(xCampo, yInicio);
            textBoxNomecad.Size = new Size(campoLargura, campoAltura);
            textBoxNomecad.Font = new Font("Segoe UI", 11F);

            // labelEmailcad
            labelEmailcad.Location = new Point(xLabel, yInicio + yStep);
            labelEmailcad.Size = new Size(labelLargura, campoAltura);
            labelEmailcad.Text = "Email:";
            labelEmailcad.Font = new Font("Segoe UI", 11F);

            // textBoxEmailcad
            textBoxEmailcad.Location = new Point(xCampo, yInicio + yStep);
            textBoxEmailcad.Size = new Size(campoLargura, campoAltura);
            textBoxEmailcad.Font = new Font("Segoe UI", 11F);

            // labelSenhacad
            labelSenhacad.Location = new Point(xLabel, yInicio + 2 * yStep);
            labelSenhacad.Size = new Size(labelLargura, campoAltura);
            labelSenhacad.Text = "Senha:";
            labelSenhacad.Font = new Font("Segoe UI", 11F);

            // textBoxSenhacad
            textBoxSenhacad.Location = new Point(xCampo, yInicio + 2 * yStep);
            textBoxSenhacad.Size = new Size(campoLargura, campoAltura);
            textBoxSenhacad.Font = new Font("Segoe UI", 11F);
            textBoxSenhacad.PasswordChar = '*';

            // labelSenha2cad
            labelSenha2cad.Location = new Point(xLabel, yInicio + 3 * yStep);
            labelSenha2cad.Size = new Size(labelLargura + 15, campoAltura);
            labelSenha2cad.Text = "Confirmar Senha:";
            labelSenha2cad.Font = new Font("Segoe UI", 11F);

            // textBoxConfirmarsenha
            textBoxConfirmarsenha.Location = new Point(xCampo, yInicio + 3 * yStep);
            textBoxConfirmarsenha.Size = new Size(campoLargura, campoAltura);
            textBoxConfirmarsenha.Font = new Font("Segoe UI", 11F);
            textBoxConfirmarsenha.PasswordChar = '*';

            // labelAltura
            labelAltura.Location = new Point(xLabel, yInicio + 4 * yStep);
            labelAltura.Size = new Size(labelLargura, campoAltura);
            labelAltura.Text = "Altura (cm):";
            labelAltura.Font = new Font("Segoe UI", 11F);

            // textBoxAltura
            textBoxAltura.Location = new Point(xCampo, yInicio + 4 * yStep);
            textBoxAltura.Size = new Size(80, campoAltura);
            textBoxAltura.Font = new Font("Segoe UI", 11F);

            // labelPeso
            labelPeso.Location = new Point(xLabel, yInicio + 5 * yStep);
            labelPeso.Size = new Size(labelLargura, campoAltura);
            labelPeso.Text = "Peso (kg):";
            labelPeso.Font = new Font("Segoe UI", 11F);

            // textBoxPeso
            textBoxPeso.Location = new Point(xCampo, yInicio + 5 * yStep);
            textBoxPeso.Size = new Size(80, campoAltura);
            textBoxPeso.Font = new Font("Segoe UI", 11F);

            // labelHoraDormir
            labelHoraDormir.Location = new Point(xLabel, yInicio + 6 * yStep);
            labelHoraDormir.Size = new Size(labelLargura, campoAltura);
            labelHoraDormir.Text = "Hora de Dormir:";
            labelHoraDormir.Font = new Font("Segoe UI", 11F);

            // dateTimeHoraDormir
            dateTimeHoraDormir.Format = DateTimePickerFormat.Time;
            dateTimeHoraDormir.Location = new Point(xCampo, yInicio + 6 * yStep);
            dateTimeHoraDormir.Size = new Size(100, campoAltura);
            dateTimeHoraDormir.Font = new Font("Segoe UI", 11F);
            dateTimeHoraDormir.ShowUpDown = true;

            // labelHoraAcordar
            labelHoraAcordar.Location = new Point(xLabel, yInicio + 7 * yStep);
            labelHoraAcordar.Size = new Size(labelLargura, campoAltura);
            labelHoraAcordar.Text = "Hora de Acordar:";
            labelHoraAcordar.Font = new Font("Segoe UI", 11F);

            // dateTimeHoraAcordar
            dateTimeHoraAcordar.Format = DateTimePickerFormat.Time;
            dateTimeHoraAcordar.Location = new Point(xCampo, yInicio + 7 * yStep);
            dateTimeHoraAcordar.Size = new Size(100, campoAltura);
            dateTimeHoraAcordar.Font = new Font("Segoe UI", 11F);
            dateTimeHoraAcordar.ShowUpDown = true;

            // Botões centralizados na parte inferior do painel
            panelCadastro.BorderStyle = BorderStyle.FixedSingle;
            panelCadastro.Size = new Size(700, 540);
            panelCadastro.Location = new Point((this.ClientSize.Width - panelCadastro.Width) / 2, 60);
            panelCadastro.BackColor = Color.White;
            panelCadastro.Visible = false;

            // ...[configuração dos outros controles]...

            // Crie e configure os botões antes de adicionar ao painel
            btnCadastrar = new Button();
            btnCadastrar.Size = new Size(120, 38);
            btnCadastrar.Location = new Point(panelCadastro.Width / 2 - btnCadastrar.Width - 14, panelCadastro.Height - 62);
            btnCadastrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;

            btnVoltarCad = new Button();
            btnVoltarCad.Size = new Size(120, 38);
            btnVoltarCad.Location = new Point(panelCadastro.Width / 2 + 14, panelCadastro.Height - 62);
            btnVoltarCad.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnVoltarCad.Text = "Voltar";
            btnVoltarCad.UseVisualStyleBackColor = true;
            btnVoltarCad.Click += btnVoltarCad_Click;

            // Adicione todos os controles depois de configurar
            panelCadastro.Controls.AddRange(new Control[] {
            labelCadastro, labelNome, textBoxNomecad, labelEmailcad, textBoxEmailcad,
            labelSenhacad, textBoxSenhacad, labelSenha2cad, textBoxConfirmarsenha,
            labelAltura, textBoxAltura, labelPeso, textBoxPeso,
            labelHoraDormir, dateTimeHoraDormir, labelHoraAcordar, dateTimeHoraAcordar,
            btnCadastrar, btnVoltarCad
});
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
        private LinkLabel linkEsqueciSenha;
    }
}