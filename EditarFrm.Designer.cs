using System;
using System.Windows.Forms;




namespace Tcc
{
    partial class EditarRotinaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DateTimePicker dtpDataEntrega;
        private System.Windows.Forms.ComboBox cmbPrioridade;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblPrioridade;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.dtpDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.cmbPrioridade = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblPrioridade = new System.Windows.Forms.Label();
           
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Título:";
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Size = new System.Drawing.Size(60, 23);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(100, 20);
            this.txtTitulo.Size = new System.Drawing.Size(250, 23);
            // 
            // lblDescricao
            // 
            this.lblDescricao.Text = "Descrição:";
            this.lblDescricao.Location = new System.Drawing.Point(20, 60);
            this.lblDescricao.Size = new System.Drawing.Size(80, 23);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(100, 60);
            this.txtDescricao.Size = new System.Drawing.Size(250, 60);
            this.txtDescricao.Multiline = true;
            // 
            // lblData
            // 
            this.lblData.Text = "Data Entrega:";
            this.lblData.Location = new System.Drawing.Point(20, 140);
            this.lblData.Size = new System.Drawing.Size(90, 23);
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.Location = new System.Drawing.Point(120, 140);
            this.dtpDataEntrega.Size = new System.Drawing.Size(120, 23);
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblPrioridade
            // 
            this.lblPrioridade.Text = "Prioridade:";
            this.lblPrioridade.Location = new System.Drawing.Point(20, 180);
            this.lblPrioridade.Size = new System.Drawing.Size(80, 23);
            // 
            // cmbPrioridade
            // 
            this.cmbPrioridade.Location = new System.Drawing.Point(120, 180);
            this.cmbPrioridade.Size = new System.Drawing.Size(120, 23);
            this.cmbPrioridade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(100, 220);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(200, 220);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // EditarRotinaForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 270);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpDataEntrega);
            this.Controls.Add(this.lblPrioridade);
            this.Controls.Add(this.cmbPrioridade);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Rotina";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}