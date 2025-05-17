namespace Tcc
{
    partial class CadastroFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCadastrar = new Button();
            dateTimeHoraAcordar = new DateTimePicker();
            dateTimeHoraDormir = new DateTimePicker();
            textBoxAltura = new TextBox();
            textBoxConfirmarsenha = new TextBox();
            textBoxSenha = new TextBox();
            label1 = new Label();
            textBoxNome = new TextBox();
            textBoxEmail = new TextBox();
            labelNome = new Label();
            labelEmailcad = new Label();
            labelSenha2cad = new Label();
            labelHoraAcordar = new Label();
            labelAltura = new Label();
            labelPeso = new Label();
            labelSenhacad = new Label();
            textBoxPeso = new TextBox();
            labelHoraDormir = new Label();
            btnVoltarCad = new Button();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(431, 561);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(153, 68);
            btnCadastrar.TabIndex = 9;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // dateTimeHoraAcordar
            // 
            dateTimeHoraAcordar.Format = DateTimePickerFormat.Time;
            dateTimeHoraAcordar.Location = new Point(431, 505);
            dateTimeHoraAcordar.Name = "dateTimeHoraAcordar";
            dateTimeHoraAcordar.ShowUpDown = true;
            dateTimeHoraAcordar.Size = new Size(133, 31);
            dateTimeHoraAcordar.TabIndex = 8;
            // 
            // dateTimeHoraDormir
            // 
            dateTimeHoraDormir.Format = DateTimePickerFormat.Time;
            dateTimeHoraDormir.Location = new Point(431, 443);
            dateTimeHoraDormir.Name = "dateTimeHoraDormir";
            dateTimeHoraDormir.ShowUpDown = true;
            dateTimeHoraDormir.Size = new Size(133, 31);
            dateTimeHoraDormir.TabIndex = 7;
            // 
            // textBoxAltura
            // 
            textBoxAltura.Location = new Point(387, 319);
            textBoxAltura.Name = "textBoxAltura";
            textBoxAltura.Size = new Size(243, 31);
            textBoxAltura.TabIndex = 5;
            // 
            // textBoxConfirmarsenha
            // 
            textBoxConfirmarsenha.Location = new Point(387, 257);
            textBoxConfirmarsenha.Name = "textBoxConfirmarsenha";
            textBoxConfirmarsenha.Size = new Size(243, 31);
            textBoxConfirmarsenha.TabIndex = 4;
            textBoxConfirmarsenha.UseSystemPasswordChar = true;
            textBoxConfirmarsenha.TextChanged += textBoxConfirmarsenha_TextChanged;
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(387, 193);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.Size = new Size(243, 31);
            textBoxSenha.TabIndex = 3;
            textBoxSenha.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(472, -50);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 12;
            label1.Text = "Faça seu cadastro";
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(387, 70);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(243, 31);
            textBoxNome.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(387, 132);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(243, 31);
            textBoxEmail.TabIndex = 2;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(387, 32);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(65, 25);
            labelNome.TabIndex = 20;
            labelNome.Text = "Nome:";
            labelNome.Click += label2_Click;
            // 
            // labelEmailcad
            // 
            labelEmailcad.AutoSize = true;
            labelEmailcad.Location = new Point(387, 104);
            labelEmailcad.Name = "labelEmailcad";
            labelEmailcad.Size = new Size(58, 25);
            labelEmailcad.TabIndex = 21;
            labelEmailcad.Text = "Email:";
            // 
            // labelSenha2cad
            // 
            labelSenha2cad.AutoSize = true;
            labelSenha2cad.Location = new Point(387, 227);
            labelSenha2cad.Name = "labelSenha2cad";
            labelSenha2cad.Size = new Size(177, 25);
            labelSenha2cad.TabIndex = 22;
            labelSenha2cad.Text = "Confirme sua senha :";
            // 
            // labelHoraAcordar
            // 
            labelHoraAcordar.AutoSize = true;
            labelHoraAcordar.Location = new Point(387, 477);
            labelHoraAcordar.Name = "labelHoraAcordar";
            labelHoraAcordar.Size = new Size(152, 25);
            labelHoraAcordar.TabIndex = 23;
            labelHoraAcordar.Text = "Hora que Acorda:";
            // 
            // labelAltura
            // 
            labelAltura.AutoSize = true;
            labelAltura.Location = new Point(387, 291);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new Size(63, 25);
            labelAltura.TabIndex = 24;
            labelAltura.Text = "Altura:";
            // 
            // labelPeso
            // 
            labelPeso.AutoSize = true;
            labelPeso.Location = new Point(387, 353);
            labelPeso.Name = "labelPeso";
            labelPeso.Size = new Size(53, 25);
            labelPeso.TabIndex = 25;
            labelPeso.Text = "Peso:";
            // 
            // labelSenhacad
            // 
            labelSenhacad.AutoSize = true;
            labelSenhacad.Location = new Point(387, 166);
            labelSenhacad.Name = "labelSenhacad";
            labelSenhacad.Size = new Size(64, 25);
            labelSenhacad.TabIndex = 26;
            labelSenhacad.Text = "Senha:";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Location = new Point(387, 381);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.Size = new Size(243, 31);
            textBoxPeso.TabIndex = 6;
            // 
            // labelHoraDormir
            // 
            labelHoraDormir.AutoSize = true;
            labelHoraDormir.Location = new Point(387, 415);
            labelHoraDormir.Name = "labelHoraDormir";
            labelHoraDormir.Size = new Size(170, 25);
            labelHoraDormir.TabIndex = 28;
            labelHoraDormir.Text = "Hora que vai domir:";
            // 
            // btnVoltarCad
            // 
            btnVoltarCad.Location = new Point(452, 647);
            btnVoltarCad.Name = "btnVoltarCad";
            btnVoltarCad.Size = new Size(112, 34);
            btnVoltarCad.TabIndex = 29;
            btnVoltarCad.Text = "Voltar";
            btnVoltarCad.UseVisualStyleBackColor = true;
            btnVoltarCad.Click += btnVoltarCad_Click;
            // 
            // CadastroFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 702);
            Controls.Add(btnVoltarCad);
            Controls.Add(labelHoraDormir);
            Controls.Add(textBoxPeso);
            Controls.Add(labelSenhacad);
            Controls.Add(labelPeso);
            Controls.Add(labelAltura);
            Controls.Add(labelHoraAcordar);
            Controls.Add(labelSenha2cad);
            Controls.Add(labelEmailcad);
            Controls.Add(labelNome);
            Controls.Add(btnCadastrar);
            Controls.Add(dateTimeHoraAcordar);
            Controls.Add(dateTimeHoraDormir);
            Controls.Add(textBoxAltura);
            Controls.Add(textBoxConfirmarsenha);
            Controls.Add(textBoxSenha);
            Controls.Add(label1);
            Controls.Add(textBoxNome);
            Controls.Add(textBoxEmail);
            Name = "CadastroFrm";
            Text = " ";
            Load += CadastroFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCadastrar;
        private DateTimePicker dateTimeHoraAcordar;
        private DateTimePicker dateTimeHoraDormir;
        private TextBox textBoxAltura;
        private TextBox textBoxConfirmarsenha;
        private TextBox textBoxSenha;
        private Label label1;
        private TextBox textBoxNome;
        private TextBox textBoxEmail;
        private Label labelNome;
        private Label labelEmailcad;
        private Label labelSenha2cad;
        private Label labelHoraAcordar;
        private Label labelAltura;
        private Label labelPeso;
        private Label labelSenhacad;
        private TextBox textBoxPeso;
        private Label labelHoraDormir;
        private Button btnVoltarCad;
    }
}