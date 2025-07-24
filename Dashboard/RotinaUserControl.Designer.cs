using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Tcc
{
    partial class RotinasUserControl
    {
        private IContainer components = null;
        private Label lblTitulo;
        private ListView listViewRotinas;
        private Button btnAtualizar;
        private Button btnConcluir;
        private Button btnRemover;
        private Button btnEditar;
        private TableLayoutPanel tableLayoutPanel;
        private FlowLayoutPanel panelBotoes;
        private ContextMenuStrip contextMenuRotinas;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem excluirToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            lblTitulo = new Label();
            listViewRotinas = new ListView();
            btnAtualizar = new Button();
            btnConcluir = new Button();
            btnRemover = new Button();
            btnEditar = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            panelBotoes = new FlowLayoutPanel();
            contextMenuRotinas = new ContextMenuStrip(components);
            editarToolStripMenuItem = new ToolStripMenuItem();
            excluirToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel.SuspendLayout();
            panelBotoes.SuspendLayout();
            contextMenuRotinas.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(32, 46, 57);
            lblTitulo.Location = new Point(3, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(844, 70);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gerenciar Tarefas";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listViewRotinas
            // 
            listViewRotinas.CheckBoxes = true;
            listViewRotinas.Dock = DockStyle.Fill;
            listViewRotinas.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            listViewRotinas.FullRowSelect = true;
            listViewRotinas.GridLines = true;
            listViewRotinas.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewRotinas.Location = new Point(3, 73);
            listViewRotinas.Name = "listViewRotinas";
            listViewRotinas.Size = new Size(844, 454);
            listViewRotinas.TabIndex = 1;
            listViewRotinas.UseCompatibleStateImageBehavior = false;
            listViewRotinas.View = View.Details;


            // Defina as colunas do ListView para aparecerem os dados!
            listViewRotinas.Columns.Add("Título", 180, HorizontalAlignment.Left);
            listViewRotinas.Columns.Add("Data Entrega", 120, HorizontalAlignment.Left);
            listViewRotinas.Columns.Add("Status", 90, HorizontalAlignment.Left);
            listViewRotinas.Columns.Add("Prioridade", 110, HorizontalAlignment.Left);
            listViewRotinas.Columns.Add("Descrição", 300, HorizontalAlignment.Left);
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.FromArgb(32, 46, 57);
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(33, 13);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(120, 40);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += BtnAtualizar_Click;
            // 
            // btnConcluir
            // 
            btnConcluir.BackColor = Color.FromArgb(32, 46, 57);
            btnConcluir.FlatStyle = FlatStyle.Flat;
            btnConcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnConcluir.ForeColor = Color.White;
            btnConcluir.Location = new Point(159, 13);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(120, 40);
            btnConcluir.TabIndex = 3;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = false;
            btnConcluir.Click += btnConcluir_Click;
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.FromArgb(244, 67, 54);
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemover.ForeColor = Color.White;
            btnRemover.Location = new Point(411, 13);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(120, 40);
            btnRemover.TabIndex = 5;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(32, 46, 57);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(285, 13);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(120, 40);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = Color.FromArgb(255, 252, 246);
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Controls.Add(lblTitulo, 0, 0);
            tableLayoutPanel.Controls.Add(listViewRotinas, 0, 1);
            tableLayoutPanel.Controls.Add(panelBotoes, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.Size = new Size(850, 600);
            tableLayoutPanel.TabIndex = 1;
            // 
            // panelBotoes
            // 
            panelBotoes.BackColor = Color.Transparent;
            panelBotoes.Controls.Add(btnAtualizar);
            panelBotoes.Controls.Add(btnConcluir);
            panelBotoes.Controls.Add(btnEditar);
            panelBotoes.Controls.Add(btnRemover);
            panelBotoes.Dock = DockStyle.Fill;
            panelBotoes.Location = new Point(3, 533);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(30, 10, 0, 10);
            panelBotoes.Size = new Size(844, 64);
            panelBotoes.TabIndex = 2;
            panelBotoes.WrapContents = false;
            // 
            // contextMenuRotinas
            // 
            contextMenuRotinas.ImageScalingSize = new Size(24, 24);
            contextMenuRotinas.Items.AddRange(new ToolStripItem[] { editarToolStripMenuItem, excluirToolStripMenuItem });
            contextMenuRotinas.Name = "contextMenuRotinas";
            contextMenuRotinas.Size = new Size(110, 48);
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(109, 22);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // excluirToolStripMenuItem
            // 
            excluirToolStripMenuItem.Name = "excluirToolStripMenuItem";
            excluirToolStripMenuItem.Size = new Size(109, 22);
            excluirToolStripMenuItem.Text = "Excluir";
            // 
            // RotinasUserControl
            // 
            BackColor = Color.FromArgb(255, 252, 246);
            Controls.Add(tableLayoutPanel);
            Name = "RotinasUserControl";
            Size = new Size(850, 600);
            Load += RotinasUserControl_Load;
            tableLayoutPanel.ResumeLayout(false);
            panelBotoes.ResumeLayout(false);
            contextMenuRotinas.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}