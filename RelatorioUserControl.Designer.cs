namespace Tcc
{
    partial class RelatorioUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Adicione o campo Chart aqui
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;

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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();

            // chart1
            this.chart1.Location = new System.Drawing.Point(20, 20);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(400, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend());

            // chart2
            this.chart2.Location = new System.Drawing.Point(450, 20);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(400, 300);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            this.chart2.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend());

            // RelatorioUserControl
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.chart2);
            this.Size = new System.Drawing.Size(900, 350);

            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
        }
    }
    #endregion
}
