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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.labelConfirmar = new System.Windows.Forms.Label();
            this.textBoxConfirmar = new System.Windows.Forms.TextBox();
            this.btnRedefinir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitulo.Location = new System.Drawing.Point(65, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(265, 48);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Redefinir Senha";
            // 
            // labelEmail
            // 
            this.labelEmail.Location = new System.Drawing.Point(35, 85);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(110, 30);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "E-mail:";
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(155, 85);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(220, 31);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // labelSenha
            // 
            this.labelSenha.Location = new System.Drawing.Point(35, 135);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(110, 30);
            this.labelSenha.TabIndex = 3;
            this.labelSenha.Text = "Nova Senha:";
            this.labelSenha.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Location = new System.Drawing.Point(155, 135);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(220, 31);
            this.textBoxSenha.TabIndex = 4;
            this.textBoxSenha.UseSystemPasswordChar = true;
            this.textBoxSenha.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // labelConfirmar
            // 
            this.labelConfirmar.Location = new System.Drawing.Point(35, 185);
            this.labelConfirmar.Name = "labelConfirmar";
            this.labelConfirmar.Size = new System.Drawing.Size(110, 30);
            this.labelConfirmar.TabIndex = 5;
            this.labelConfirmar.Text = "Confirmar:";
            this.labelConfirmar.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // textBoxConfirmar
            // 
            this.textBoxConfirmar.Location = new System.Drawing.Point(155, 185);
            this.textBoxConfirmar.Name = "textBoxConfirmar";
            this.textBoxConfirmar.Size = new System.Drawing.Size(220, 31);
            this.textBoxConfirmar.TabIndex = 6;
            this.textBoxConfirmar.UseSystemPasswordChar = true;
            this.textBoxConfirmar.Font = new System.Drawing.Font("Segoe UI", 11F);
            // 
            // btnRedefinir
            // 
            this.btnRedefinir.Location = new System.Drawing.Point(65, 250);
            this.btnRedefinir.Name = "btnRedefinir";
            this.btnRedefinir.Size = new System.Drawing.Size(140, 38);
            this.btnRedefinir.TabIndex = 7;
            this.btnRedefinir.Text = "Redefinir";
            this.btnRedefinir.UseVisualStyleBackColor = true;
            this.btnRedefinir.Click += new System.EventHandler(this.btnRedefinir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(235, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 38);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // RedefinirSenhaFrm
            // 
            this.AcceptButton = this.btnRedefinir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 320);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRedefinir);
            this.Controls.Add(this.textBoxConfirmar);
            this.Controls.Add(this.labelConfirmar);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RedefinirSenhaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Redefinir Senha";
            this.ResumeLayout(false);
            this.PerformLayout();
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