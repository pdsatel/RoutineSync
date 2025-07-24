using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tcc
{
    partial class EditarRotinaForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblDescricao;
        private TextBox txtDescricao;
        private Label lblDataEntrega;
        private DateTimePicker dtpDataEntrega;
        private Label lblPrioridade;
        private ComboBox cmbPrioridade;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnStatusTarefa;

        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblDescricao = new Label();
            txtDescricao = new TextBox();
            lblDataEntrega = new Label();
            dtpDataEntrega = new DateTimePicker();
            lblPrioridade = new Label();
            cmbPrioridade = new ComboBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitulo.Location = new Point(40, 36);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(66, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // txtTitulo
            txtTitulo.BackColor = Color.White;
            txtTitulo.BorderStyle = BorderStyle.FixedSingle;
            txtTitulo.ForeColor = Color.FromArgb(51, 51, 51);
            txtTitulo.Location = new Point(140, 32);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(340, 34);
            txtTitulo.TabIndex = 1;
            // lblDescricao
            lblDescricao.AutoSize = true;
            lblDescricao.ForeColor = Color.FromArgb(51, 51, 51);
            lblDescricao.Location = new Point(40, 84);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(100, 28);
            lblDescricao.TabIndex = 2;
            lblDescricao.Text = "Descrição:";
            // txtDescricao
            txtDescricao.BackColor = Color.White;
            txtDescricao.BorderStyle = BorderStyle.FixedSingle;
            txtDescricao.ForeColor = Color.FromArgb(51, 51, 51);
            txtDescricao.Location = new Point(140, 80);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(340, 80);
            txtDescricao.TabIndex = 3;
            // lblDataEntrega
            lblDataEntrega.AutoSize = true;
            lblDataEntrega.ForeColor = Color.FromArgb(51, 51, 51);
            lblDataEntrega.Location = new Point(40, 185);
            lblDataEntrega.Name = "lblDataEntrega";
            lblDataEntrega.Size = new Size(129, 28);
            lblDataEntrega.TabIndex = 4;
            lblDataEntrega.Text = "Data Entrega:";
            // dtpDataEntrega
            dtpDataEntrega.CalendarMonthBackground = Color.White;
            dtpDataEntrega.ForeColor = Color.FromArgb(51, 51, 51);
            dtpDataEntrega.Format = DateTimePickerFormat.Custom;
            dtpDataEntrega.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDataEntrega.ShowUpDown = true;
            dtpDataEntrega.Location = new Point(175, 180);
            dtpDataEntrega.Name = "dtpDataEntrega";
            dtpDataEntrega.Size = new Size(180, 34);
            dtpDataEntrega.TabIndex = 5;
            // lblPrioridade
            lblPrioridade.AutoSize = true;
            lblPrioridade.ForeColor = Color.FromArgb(51, 51, 51);
            lblPrioridade.Location = new Point(40, 235);
            lblPrioridade.Name = "lblPrioridade";
            lblPrioridade.Size = new Size(107, 28);
            lblPrioridade.TabIndex = 6;
            lblPrioridade.Text = "Prioridade:";
            // cmbPrioridade
            cmbPrioridade.BackColor = Color.White;
            cmbPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridade.ForeColor = Color.FromArgb(51, 51, 51);
            cmbPrioridade.FormattingEnabled = true;
            cmbPrioridade.Location = new Point(153, 232);
            cmbPrioridade.Name = "cmbPrioridade";
            cmbPrioridade.Size = new Size(140, 36);
            cmbPrioridade.TabIndex = 7;
            // btnSalvar
            btnSalvar.BackColor = Color.FromArgb(32, 46, 57);
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(140, 300);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(120, 40);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // btnCancelar
            btnCancelar.BackColor = Color.FromArgb(32, 46, 57);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(280, 300);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 40);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;


            btnStatusTarefa = new Button();
            btnStatusTarefa.Text = "Pendente";
            btnStatusTarefa.Click += btnStatusTarefa_Click;
            btnStatusTarefa.Location = new Point(305, 232); // posição onde quiser
            btnStatusTarefa.Size = new Size(140, 36);
            this.Controls.Add(btnStatusTarefa);

            // EditarRotinaForm
            AcceptButton = btnSalvar;
            BackColor = Color.FromArgb(255, 252, 246);
            CancelButton = btnCancelar;
            ClientSize = new Size(540, 390);
            Controls.Add(lblTitulo);
            Controls.Add(txtTitulo);
            Controls.Add(lblDescricao);
            Controls.Add(txtDescricao);
            Controls.Add(lblDataEntrega);
            Controls.Add(dtpDataEntrega);
            Controls.Add(lblPrioridade);
            Controls.Add(cmbPrioridade);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditarRotinaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Rotina";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}