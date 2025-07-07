



namespace Tcc
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
            flowPanelNotificacoes = new FlowLayoutPanel();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // flowPanelNotificacoes
            // 
            flowPanelNotificacoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowPanelNotificacoes.AutoScroll = true;
            flowPanelNotificacoes.FlowDirection = FlowDirection.TopDown;
            flowPanelNotificacoes.Location = new Point(13, 35);
            flowPanelNotificacoes.Margin = new Padding(3, 2, 3, 2);
            flowPanelNotificacoes.Name = "flowPanelNotificacoes";
            flowPanelNotificacoes.Size = new Size(394, 255);
            flowPanelNotificacoes.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(13, 8);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Caixa de Notificações";
            // 
            // Notificacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(lblTitulo);
            Controls.Add(flowPanelNotificacoes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Notificacao";
            Size = new Size(420, 308);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelNotificacoes;
        private System.Windows.Forms.Label lblTitulo;
    }
}