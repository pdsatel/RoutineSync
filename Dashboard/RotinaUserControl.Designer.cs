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
            private Button btnConcluir;
            private Button btnAdicionar;
            private Button btnRemover;
            private ContextMenuStrip contextMenuRotinas;
            private ToolStripMenuItem editarToolStripMenuItem;
            private ToolStripMenuItem excluirToolStripMenuItem;
           
            private Button btnEditar;

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
            {
                
            }
                contextMenuRotinas = new ContextMenuStrip(components);
                editarToolStripMenuItem = new ToolStripMenuItem();
                excluirToolStripMenuItem = new ToolStripMenuItem();
                btnAtualizar = new Button();
                btnExportar = new Button();
                btnConcluir = new Button();
                btnAdicionar = new Button();
                btnRemover = new Button();
                btnEditar = new Button();
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
            listViewRotinas = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(30, 85),
                Size = new Size(900, 450),
                Font = new Font("Segoe UI", 11),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 51, 51),
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
                CheckBoxes = true,
                UseCompatibleStateImageBehavior = false,
                Name = "listViewRotinas",
                TabIndex = 1
            };
                listViewRotinas.Columns.Add("Título", 200);
                listViewRotinas.Columns.Add("Data Entrega", 120);
                listViewRotinas.Columns.Add("Status", 100);
                listViewRotinas.Columns.Add("Prioridade", 100);
                listViewRotinas.Columns.Add("Descrição", 250);
            // Adicionar colunas ao listViewRotinas

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
                btnAtualizar.Location = new Point(30, 550);
                btnAtualizar.Name = "btnAtualizar";
                btnAtualizar.Size = new Size(120, 40);
                btnAtualizar.TabIndex = 2;
                btnAtualizar.Text = "Atualizar";
                btnAtualizar.UseVisualStyleBackColor = false;
                // 
            
                // 
               
                // 
                // btnConcluir
                // 
                btnConcluir.BackColor = Color.FromArgb(32, 46, 57);
                btnConcluir.FlatStyle = FlatStyle.Flat;
                btnConcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnConcluir.ForeColor = Color.White;
                btnConcluir.Location = new Point(290, 550);
                btnConcluir.Name = "btnConcluir";
                btnConcluir.Size = new Size(180, 40);
                btnConcluir.TabIndex = 4;
                btnConcluir.Text = "Concluida";
                btnConcluir.UseVisualStyleBackColor = false;
                // 
                // btnAdicionar
                
                // 
                // btnRemover
                // 
                btnRemover.BackColor = Color.FromArgb(244, 67, 54);
                btnRemover.FlatStyle = FlatStyle.Flat;
                btnRemover.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnRemover.ForeColor = Color.White;
                btnRemover.Location = new Point(610, 550);
                btnRemover.Name = "btnRemover";
                btnRemover.Size = new Size(120, 40);
                btnRemover.TabIndex = 6;
                btnRemover.Text = "Remover";
                btnRemover.UseVisualStyleBackColor = false;
                btnRemover.Click += btnRemover_Click;
            // 
                // ... (demais declarações)
                btnEditar.BackColor = Color.FromArgb(32, 46, 57);
                btnEditar.FlatStyle = FlatStyle.Flat;
                btnEditar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnEditar.ForeColor = Color.White;
                btnEditar.Location = new Point(480, 550); // ajuste a posição como quiser
                btnEditar.Name = "btnEditar";
                btnEditar.Size = new Size(120, 40);
                btnEditar.TabIndex = 5;
                btnEditar.Text = "Editar";
                btnEditar.UseVisualStyleBackColor = false;
                btnEditar.Click += btnEditar_Click;
                Controls.Add(btnEditar);
            // 
            // RotinasUserControl
            // 
            BackColor = Color.FromArgb(255, 252, 246);
                Controls.Add(lblTitulo);
                Controls.Add(listViewRotinas);
                Controls.Add(btnAtualizar);
                Controls.Add(btnExportar);
                Controls.Add(btnConcluir);
                Controls.Add(btnAdicionar);
                Controls.Add(btnRemover);
                Controls.Add(btnEditar);
                Name = "RotinasUserControl";
                Size = new Size(850, 600);
                contextMenuRotinas.ResumeLayout(false);
                ResumeLayout(false);
                PerformLayout();
            }

            #endregion
        }
    }