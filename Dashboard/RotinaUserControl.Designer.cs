using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;




namespace Tcc
{
    partial class RotinasUserControl
    {
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListView listViewRotinas;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExportar;

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.listViewRotinas = new System.Windows.Forms.ListView();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Minhas Rotinas";
            // 
            // listViewRotinas
            // 
            this.listViewRotinas.CheckBoxes = true;
            this.listViewRotinas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewRotinas.FullRowSelect = true;
            this.listViewRotinas.GridLines = true;
            this.listViewRotinas.Location = new System.Drawing.Point(30, 70);
            this.listViewRotinas.Name = "listViewRotinas";
            this.listViewRotinas.Size = new System.Drawing.Size(740, 390);
            this.listViewRotinas.TabIndex = 1;
            this.listViewRotinas.UseCompatibleStateImageBehavior = false;
            this.listViewRotinas.View = System.Windows.Forms.View.Details;
            this.listViewRotinas.Columns.Add("Feito", 60);
            this.listViewRotinas.Columns.Add("Título", 220);
            this.listViewRotinas.Columns.Add("Data Entrega", 120);
            this.listViewRotinas.Columns.Add("Status", 120);
            this.listViewRotinas.Columns.Add("Prioridade", 120);
            this.listViewRotinas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewRotinas_ItemCheck);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(32, 46, 57);
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(30, 480);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(120, 40);
            this.btnAtualizar.TabIndex = 2;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(60, 141, 188);
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(170, 480);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(120, 40);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // RotinasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 248, 251);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.listViewRotinas);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExportar);
            this.Name = "RotinasUserControl";
            this.Size = new System.Drawing.Size(800, 550);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}