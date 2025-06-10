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
        private IContainer components = null;

        private Label lblTitulo;
        private ListView listViewRotinas;
        private Button btnAtualizar;
        private Button btnExportar;
        private Button btnMarcarTodasFeitas;
        private Button btnAdicionar;
        private Button btnRemover;
        private ContextMenuStrip contextMenuRotinas;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem excluirToolStripMenuItem;
        private Label lblResumoExecucoes;

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
            components = new Container();
            lblTitulo = new Label();
            listViewRotinas = new ListView();
            contextMenuRotinas = new ContextMenuStrip(components);
            editarToolStripMenuItem = new ToolStripMenuItem();
            excluirToolStripMenuItem = new ToolStripMenuItem();
            btnAtualizar = new Button();
            btnExportar = new Button();
            btnMarcarTodasFeitas = new Button();
            btnAdicionar = new Button();
            btnRemover = new Button();
            lblResumoExecucoes = new Label();
            contextMenuRotinas.SuspendLayout();
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
            listViewRotinas.ContextMenuStrip = contextMenuRotinas;
            listViewRotinas.Font = new Font("Segoe UI", 11F);
            listViewRotinas.ForeColor = Color.FromArgb(51, 51, 51);
            listViewRotinas.FullRowSelect = true;
            listViewRotinas.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewRotinas.Location = new Point(30, 85);
            listViewRotinas.Name = "listViewRotinas";
            listViewRotinas.Size = new Size(790, 370);
            listViewRotinas.TabIndex = 1;
            listViewRotinas.UseCompatibleStateImageBehavior = false;
            listViewRotinas.View = View.Details;


            // Adicionar colunas ao listViewRotinas
            listViewRotinas.Columns.Add("", 30); // coluna para checkbox (pode ser vazia)
            listViewRotinas.Columns.Add("Título", 150);
            listViewRotinas.Columns.Add("Descrição", 250);
            listViewRotinas.Columns.Add("Status", 120);
            listViewRotinas.Columns.Add("Prioridade", 100);
            listViewRotinas.Columns.Add("Execuções/Mês", 100);
            // 
            // contextMenuRotinas
            // 
            contextMenuRotinas.ImageScalingSize = new Size(24, 24);
            contextMenuRotinas.Items.AddRange(new ToolStripItem[] { editarToolStripMenuItem, excluirToolStripMenuItem });
            contextMenuRotinas.Name = "contextMenuRotinas";
            contextMenuRotinas.Size = new Size(134, 68);
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(133, 32);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // excluirToolStripMenuItem
            // 
            excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            excluirToolStripMenuItem.Size = new Size(133, 32);
            excluirToolStripMenuItem.Text = "Excluir";
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.FromArgb(32, 46, 57);
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(30, 470);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(120, 40);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.FromArgb(32, 46, 57); ;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(160, 470);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(120, 40);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnMarcarTodasFeitas
            // 
            btnMarcarTodasFeitas.BackColor = Color.FromArgb(32, 46, 57);
            btnMarcarTodasFeitas.FlatStyle = FlatStyle.Flat;
            btnMarcarTodasFeitas.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMarcarTodasFeitas.ForeColor = Color.White;
            btnMarcarTodasFeitas.Location = new Point(290, 470);
            btnMarcarTodasFeitas.Name = "btnMarcarTodasFeitas";
            btnMarcarTodasFeitas.Size = new Size(180, 40);
            btnMarcarTodasFeitas.TabIndex = 4;
            btnMarcarTodasFeitas.Text = "Marcar todas feitas hoje";
            btnMarcarTodasFeitas.UseVisualStyleBackColor = false;
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.FromArgb(32, 46, 57);
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.Location = new Point(480, 470);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(120, 40);
            btnAdicionar.TabIndex = 5;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = false;
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.FromArgb(244, 67, 54);
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRemover.ForeColor = Color.White;
            btnRemover.Location = new Point(610, 470);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(120, 40);
            btnRemover.TabIndex = 6;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // lblResumoExecucoes
            // 
            lblResumoExecucoes.AutoSize = true;
            lblResumoExecucoes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResumoExecucoes.ForeColor = Color.FromArgb(32, 46, 57);
            lblResumoExecucoes.Location = new Point(30, 530);
            lblResumoExecucoes.Name = "lblResumoExecucoes";
            lblResumoExecucoes.Size = new Size(363, 32);
            lblResumoExecucoes.TabIndex = 7;
            lblResumoExecucoes.Text = "Total de execuções este mês: 0";
            // 
            // RotinasUserControl
            // 
            BackColor = Color.FromArgb(255, 252, 246);
            Controls.Add(lblTitulo);
            Controls.Add(listViewRotinas);
            Controls.Add(btnAtualizar);
            Controls.Add(btnExportar);
            Controls.Add(btnMarcarTodasFeitas);
            Controls.Add(btnAdicionar);
            Controls.Add(btnRemover);
            Controls.Add(lblResumoExecucoes);
            Name = "RotinasUserControl";
            Size = new Size(850, 600);
            contextMenuRotinas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}