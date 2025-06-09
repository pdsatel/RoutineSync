using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;




namespace Tcc
{
    partial class RotinasUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListView listViewRotinas;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnMarcarTodasFeitas;
        private System.Windows.Forms.Label lblResumoExecucoes;

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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.listViewRotinas = new System.Windows.Forms.ListView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnMarcarTodasFeitas = new System.Windows.Forms.Button();
            this.lblResumoExecucoes = new System.Windows.Forms.Label();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#202E39");
            this.lblTitulo.Text = "Minhas Rotinas";
            // 
            // listViewRotinas
            // 
            this.listViewRotinas.CheckBoxes = true;
            this.listViewRotinas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewRotinas.FullRowSelect = true;
            this.listViewRotinas.GridLines = false;
            this.listViewRotinas.Location = new System.Drawing.Point(30, 70);
            this.listViewRotinas.Name = "listViewRotinas";
            this.listViewRotinas.Size = new System.Drawing.Size(790, 390);
            this.listViewRotinas.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFCF6");
            this.listViewRotinas.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            this.listViewRotinas.View = System.Windows.Forms.View.Details;
            this.listViewRotinas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRotinas.Columns.Add("Feito", 60);
            this.listViewRotinas.Columns.Add("Título", 180);
            this.listViewRotinas.Columns.Add("Frequência", 120);
            this.listViewRotinas.Columns.Add("Status", 100);
            this.listViewRotinas.Columns.Add("Prioridade", 100);
            this.listViewRotinas.Columns.Add("Execuções/Mês", 120);

            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.ColorTranslator.FromHtml("#202E39");
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(30, 480);
            this.btnAtualizar.Size = new System.Drawing.Size(120, 40);
            this.btnAtualizar.Text = "Atualizar";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.ColorTranslator.FromHtml("#4A90E2");
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(170, 480);
            this.btnExportar.Size = new System.Drawing.Size(120, 40);
            this.btnExportar.Text = "Exportar";
            // 
            // btnMarcarTodasFeitas
            // 
            this.btnMarcarTodasFeitas.BackColor = System.Drawing.ColorTranslator.FromHtml("#7ED321");
            this.btnMarcarTodasFeitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarTodasFeitas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMarcarTodasFeitas.ForeColor = System.Drawing.Color.White;
            this.btnMarcarTodasFeitas.Location = new System.Drawing.Point(310, 480);
            this.btnMarcarTodasFeitas.Size = new System.Drawing.Size(180, 40);
            this.btnMarcarTodasFeitas.Text = "Marcar todas feitas hoje";
            // 
            // lblResumoExecucoes
            // 
            this.lblResumoExecucoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResumoExecucoes.ForeColor = System.Drawing.ColorTranslator.FromHtml("#202E39");
            this.lblResumoExecucoes.Location = new System.Drawing.Point(520, 480);
            this.lblResumoExecucoes.Size = new System.Drawing.Size(300, 40);
            this.lblResumoExecucoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResumoExecucoes.Text = "Total de execuções este mês: 0";

            // 
            // RotinasUserControl
            // 
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFCF6");
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.listViewRotinas);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnMarcarTodasFeitas);
            this.Controls.Add(this.lblResumoExecucoes);
            this.Name = "RotinasUserControl";
            this.Size = new System.Drawing.Size(850, 550);
        }

        #endregion
    }
}