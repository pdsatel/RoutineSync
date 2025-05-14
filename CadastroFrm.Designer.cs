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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBoxPeso = new TextBox();
            label9 = new Label();
            btnVoltarCad = new Button();
            SuspendLayout();
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(431, 561);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(153, 68);
            btnCadastrar.TabIndex = 19;
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
            dateTimeHoraAcordar.TabIndex = 18;
            // 
            // dateTimeHoraDormir
            // 
            dateTimeHoraDormir.Format = DateTimePickerFormat.Time;
            dateTimeHoraDormir.Location = new Point(431, 443);
            dateTimeHoraDormir.Name = "dateTimeHoraDormir";
            dateTimeHoraDormir.ShowUpDown = true;
            dateTimeHoraDormir.Size = new Size(133, 31);
            dateTimeHoraDormir.TabIndex = 17;
            // 
            // textBoxAltura
            // 
            textBoxAltura.Location = new Point(387, 319);
            textBoxAltura.Name = "textBoxAltura";
            textBoxAltura.Size = new Size(243, 31);
            textBoxAltura.TabIndex = 16;
            // 
            // textBoxConfirmarsenha
            // 
            textBoxConfirmarsenha.Location = new Point(387, 257);
            textBoxConfirmarsenha.Name = "textBoxConfirmarsenha";
            textBoxConfirmarsenha.Size = new Size(243, 31);
            textBoxConfirmarsenha.TabIndex = 14;
            textBoxConfirmarsenha.UseSystemPasswordChar = true;
            textBoxConfirmarsenha.TextChanged += textBoxConfirmarsenha_TextChanged;
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(387, 193);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.Size = new Size(243, 31);
            textBoxSenha.TabIndex = 13;
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
            textBoxNome.TabIndex = 11;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(387, 132);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(243, 31);
            textBoxEmail.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 32);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 20;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(387, 104);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 21;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 227);
            label4.Name = "label4";
            label4.Size = new Size(177, 25);
            label4.TabIndex = 22;
            label4.Text = "Confirme sua senha :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(387, 477);
            label5.Name = "label5";
            label5.Size = new Size(152, 25);
            label5.TabIndex = 23;
            label5.Text = "Hora que Acorda:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(387, 291);
            label6.Name = "label6";
            label6.Size = new Size(63, 25);
            label6.TabIndex = 24;
            label6.Text = "Altura:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(387, 353);
            label7.Name = "label7";
            label7.Size = new Size(53, 25);
            label7.TabIndex = 25;
            label7.Text = "Peso:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(387, 166);
            label8.Name = "label8";
            label8.Size = new Size(64, 25);
            label8.TabIndex = 26;
            label8.Text = "Senha:";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Location = new Point(387, 381);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.Size = new Size(243, 31);
            textBoxPeso.TabIndex = 27;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(387, 415);
            label9.Name = "label9";
            label9.Size = new Size(170, 25);
            label9.TabIndex = 28;
            label9.Text = "Hora que vai domir:";
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
            Controls.Add(label9);
            Controls.Add(textBoxPeso);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
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
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxPeso;
        private Label label9;
        private Button btnVoltarCad;
    }
}