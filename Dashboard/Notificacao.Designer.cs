



namespace RoutineSync
{
    partial class Notificacao
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowPanelNotificacoes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(15, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(222, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Caixa de Notificações";
            // 
            // flowPanelNotificacoes
            // 
            this.flowPanelNotificacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelNotificacoes.AutoScroll = true;
            this.flowPanelNotificacoes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelNotificacoes.Location = new System.Drawing.Point(15, 50);
            this.flowPanelNotificacoes.Name = "flowPanelNotificacoes";
            this.flowPanelNotificacoes.Size = new System.Drawing.Size(450, 340);
            this.flowPanelNotificacoes.TabIndex = 1;
            this.flowPanelNotificacoes.WrapContents = true;
            // 
            // Notificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.flowPanelNotificacoes);
            this.Name = "Notificacao";
            this.Size = new System.Drawing.Size(480, 410);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelNotificacoes;
        private System.Windows.Forms.Label lblTitulo;
    }
}