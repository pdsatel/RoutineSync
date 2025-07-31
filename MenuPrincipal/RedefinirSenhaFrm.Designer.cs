namespace Tcc
{
    partial class RedefinirSenhaFrm
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
            labelTitulo = new Label();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelSenha = new Label();
            textBoxSenha = new TextBox();
            labelConfirmar = new Label();
            textBoxConfirmar = new TextBox();
            btnRedefinir = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitulo.Location = new Point(46, 12);
            labelTitulo.Margin = new Padding(2, 0, 2, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(193, 32);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Redefinir Senha";
            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.Location = new Point(24, 51);
            labelEmail.Margin = new Padding(2, 0, 2, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(77, 18);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "E-mail:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEmail.Location = new Point(108, 51);
            textBoxEmail.Margin = new Padding(2, 2, 2, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(155, 27);
            textBoxEmail.TabIndex = 2;
            // 
            // labelSenha
            // 
            labelSenha.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelSenha.Location = new Point(24, 81);
            labelSenha.Margin = new Padding(2, 0, 2, 0);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new Size(77, 18);
            labelSenha.TabIndex = 3;
            labelSenha.Text = "Nova Senha:";
            // 
            // textBoxSenha
            // 
            textBoxSenha.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSenha.Location = new Point(108, 81);
            textBoxSenha.Margin = new Padding(2, 2, 2, 2);
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.Size = new Size(155, 27);
            textBoxSenha.TabIndex = 4;
            textBoxSenha.UseSystemPasswordChar = true;
            // 
            // labelConfirmar
            // 
            labelConfirmar.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelConfirmar.Location = new Point(24, 111);
            labelConfirmar.Margin = new Padding(2, 0, 2, 0);
            labelConfirmar.Name = "labelConfirmar";
            labelConfirmar.Size = new Size(77, 18);
            labelConfirmar.TabIndex = 5;
            labelConfirmar.Text = "Confirmar:";
            // 
            // textBoxConfirmar
            // 
            textBoxConfirmar.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxConfirmar.Location = new Point(108, 111);
            textBoxConfirmar.Margin = new Padding(2, 2, 2, 2);
            textBoxConfirmar.Name = "textBoxConfirmar";
            textBoxConfirmar.Size = new Size(155, 27);
            textBoxConfirmar.TabIndex = 6;
            textBoxConfirmar.UseSystemPasswordChar = true;
            // 
            // btnRedefinir
            // 
            btnRedefinir.Location = new Point(46, 150);
            btnRedefinir.Margin = new Padding(2, 2, 2, 2);
            btnRedefinir.Name = "btnRedefinir";
            btnRedefinir.Size = new Size(98, 23);
            btnRedefinir.TabIndex = 7;
            btnRedefinir.Text = "Redefinir";
            btnRedefinir.UseVisualStyleBackColor = true;
            btnRedefinir.Click += btnRedefinir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(164, 150);
            btnCancelar.Margin = new Padding(2, 2, 2, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RedefinirSenhaFrm
            // 
            AcceptButton = btnRedefinir;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 192);
            Controls.Add(btnCancelar);
            Controls.Add(btnRedefinir);
            Controls.Add(textBoxConfirmar);
            Controls.Add(labelConfirmar);
            Controls.Add(textBoxSenha);
            Controls.Add(labelSenha);
            Controls.Add(textBoxEmail);
            Controls.Add(labelEmail);
            Controls.Add(labelTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RedefinirSenhaFrm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Redefinir Senha";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelSenha;
        private TextBox textBoxSenha;
        private Label labelConfirmar;
        private TextBox textBoxConfirmar;
        private Button btnRedefinir;
        private Button btnCancelar;
    }
}