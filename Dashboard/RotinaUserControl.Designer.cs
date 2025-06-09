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
        private System.Windows.Forms.ContextMenuStrip contextMenuRotinas;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirToolStripMenuItem;

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
            lblTitulo = new Label();
            listViewRotinas = new ListView();
            btnAtualizar = new Button();
            btnExportar = new Button();
            btnMarcarTodasFeitas = new Button();
            lblResumoExecucoes = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(32, 46, 57);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(343, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Minhas Rotinas";
            // 
            // listViewRotinas
            // 
            listViewRotinas.BackColor = Color.FromArgb(255, 252, 246);
            listViewRotinas.CheckBoxes = true;
            listViewRotinas.Font = new Font("Segoe UI", 11F);
            listViewRotinas.ForeColor = Color.FromArgb(51, 51, 51);
            listViewRotinas.FullRowSelect = true;
            listViewRotinas.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewRotinas.Location = new Point(30, 70);
            listViewRotinas.Name = "listViewRotinas";
            listViewRotinas.Size = new Size(790, 390);
            listViewRotinas.TabIndex = 1;
            listViewRotinas.UseCompatibleStateImageBehavior = false;
            listViewRotinas.View = View.Details;


            // Adiciona as colunas ao ListView
            listViewRotinas.Columns.Add("Feito", 60);         // 0 - Checkbox (visual)
            listViewRotinas.Columns.Add("Título", 180);       // 1
            listViewRotinas.Columns.Add("Data", 100);         // 2
            listViewRotinas.Columns.Add("Status", 100);       // 3
            listViewRotinas.Columns.Add("Prioridade", 100);   // 4
            listViewRotinas.Columns.Add("Execuções/Mês", 120);// 5
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.FromArgb(32, 46, 57);
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(30, 480);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(120, 40);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.FromArgb(74, 144, 226);
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(170, 480);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(120, 40);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnMarcarTodasFeitas
            // 
            btnMarcarTodasFeitas.BackColor = Color.FromArgb(126, 211, 33);
            btnMarcarTodasFeitas.FlatStyle = FlatStyle.Flat;
            btnMarcarTodasFeitas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMarcarTodasFeitas.ForeColor = Color.White;
            btnMarcarTodasFeitas.Location = new Point(310, 480);
            btnMarcarTodasFeitas.Name = "btnMarcarTodasFeitas";
            btnMarcarTodasFeitas.Size = new Size(180, 40);
            btnMarcarTodasFeitas.TabIndex = 4;
            btnMarcarTodasFeitas.Text = "Marcar todas feitas hoje";
            btnMarcarTodasFeitas.UseVisualStyleBackColor = false;
            // 
            // lblResumoExecucoes
            // 
            lblResumoExecucoes.Font = new Font("Segoe UI", 12F);
            lblResumoExecucoes.ForeColor = Color.FromArgb(32, 46, 57);
            lblResumoExecucoes.Location = new Point(520, 480);
            lblResumoExecucoes.Name = "lblResumoExecucoes";
            lblResumoExecucoes.Size = new Size(300, 40);
            lblResumoExecucoes.TabIndex = 5;
            lblResumoExecucoes.Text = "Total de execuções este mês: 0";
            lblResumoExecucoes.TextAlign = ContentAlignment.MiddleLeft;


            // 
            // contextMenuRotinas
            // 
            this.contextMenuRotinas = new System.Windows.Forms.ContextMenuStrip();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.contextMenuRotinas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.editarToolStripMenuItem, this.excluirToolStripMenuItem});

            this.editarToolStripMenuItem.Text = "Editar";
            this.excluirToolStripMenuItem.Text = "Excluir";
            this.listViewRotinas.ContextMenuStrip = this.contextMenuRotinas;
            // 
            // RotinasUserControl
            // 
            BackColor = Color.FromArgb(255, 252, 246);
            Controls.Add(lblTitulo);
            Controls.Add(listViewRotinas);
            Controls.Add(btnAtualizar);
            Controls.Add(btnExportar);
            Controls.Add(btnMarcarTodasFeitas);
            Controls.Add(lblResumoExecucoes);
            Name = "RotinasUserControl";
            Size = new Size(850, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}