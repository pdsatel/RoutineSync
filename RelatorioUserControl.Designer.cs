namespace Tcc
{
    partial class RelatorioUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Adicione os campos PlotView aqui
        private OxyPlot.WindowsForms.PlotView plotViewPrioridade;
        private OxyPlot.WindowsForms.PlotView plotViewStatus;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se necessário descartar os recursos gerenciados; caso contrário, false.</param>
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
            this.plotViewPrioridade = new OxyPlot.WindowsForms.PlotView();
            this.plotViewStatus = new OxyPlot.WindowsForms.PlotView();

            // 
            // plotViewPrioridade
            // 
            this.plotViewPrioridade.Location = new System.Drawing.Point(20, 20);
            this.plotViewPrioridade.Name = "plotViewPrioridade";
            this.plotViewPrioridade.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewPrioridade.Size = new System.Drawing.Size(400, 300);
            this.plotViewPrioridade.TabIndex = 0;
            this.plotViewPrioridade.Text = "Gráfico Prioridade";
            this.plotViewPrioridade.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewPrioridade.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewPrioridade.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;

            // 
            // plotViewStatus
            // 
            this.plotViewStatus.Location = new System.Drawing.Point(450, 20);
            this.plotViewStatus.Name = "plotViewStatus";
            this.plotViewStatus.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewStatus.Size = new System.Drawing.Size(400, 300);
            this.plotViewStatus.TabIndex = 1;
            this.plotViewStatus.Text = "Gráfico Status";
            this.plotViewStatus.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewStatus.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewStatus.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;

            // 
            // RelatorioUserControl
            // 
            this.Controls.Add(this.plotViewPrioridade);
            this.Controls.Add(this.plotViewStatus);
            this.Name = "RelatorioUserControl";
            this.Size = new System.Drawing.Size(900, 350);
        }

        #endregion
    }
}