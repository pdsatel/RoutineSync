namespace Tcc
{
    partial class NotificacoesPopupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox listBoxNotificacoes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.listBoxNotificacoes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(185, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Notificações Próximas:";
            // 
            // listBoxNotificacoes
            // 
            this.listBoxNotificacoes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxNotificacoes.FormattingEnabled = true;
            this.listBoxNotificacoes.ItemHeight = 17;
            this.listBoxNotificacoes.Location = new System.Drawing.Point(12, 38);
            this.listBoxNotificacoes.Name = "listBoxNotificacoes";
            this.listBoxNotificacoes.Size = new System.Drawing.Size(320, 106);
            this.listBoxNotificacoes.TabIndex = 1;
            // 
            // NotificacoesPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(255, 252, 246);
            this.ClientSize = new System.Drawing.Size(344, 160);
            this.Controls.Add(this.listBoxNotificacoes);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NotificacoesPopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}