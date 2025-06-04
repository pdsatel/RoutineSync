using Syncfusion.Windows.Forms.Schedule;
using Syncfusion.Schedule;

namespace Tcc
{
    partial class RotinaUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        private void InitializeComponent()
        {
            this.panelInputs = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.labelHorario = new System.Windows.Forms.Label();
            this.dateTimePickerHorario = new System.Windows.Forms.DateTimePicker();
            this.labelDiaSemana = new System.Windows.Forms.Label();
            this.comboBoxDiaSemana = new System.Windows.Forms.ComboBox();
            this.listBoxRotinas = new System.Windows.Forms.ListBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.scheduler = new Syncfusion.Windows.Forms.Schedule.ScheduleControl();

            this.panelInputs.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(45, 60, 70);
            this.panelInputs.Controls.Add(this.labelTitulo);
            this.panelInputs.Controls.Add(this.textBoxTitulo);
            this.panelInputs.Controls.Add(this.labelDescricao);
            this.panelInputs.Controls.Add(this.textBoxDescricao);
            this.panelInputs.Controls.Add(this.labelHorario);
            this.panelInputs.Controls.Add(this.dateTimePickerHorario);
            this.panelInputs.Controls.Add(this.labelDiaSemana);
            this.panelInputs.Controls.Add(this.comboBoxDiaSemana);
            this.panelInputs.Controls.Add(this.listBoxRotinas);
            this.panelInputs.Controls.Add(this.btnSalvar);
            this.panelInputs.Controls.Add(this.btnEditar);
            this.panelInputs.Controls.Add(this.btnExcluir);
            this.panelInputs.Controls.Add(this.btnLimpar);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInputs.Location = new System.Drawing.Point(0, 0);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Padding = new System.Windows.Forms.Padding(10);
            this.panelInputs.Size = new System.Drawing.Size(350, 767);
            this.panelInputs.TabIndex = 1;

            // 
            // labelTitulo
            // 
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(10, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(100, 23);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Título:";

            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.Location = new System.Drawing.Point(10, 43);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(300, 31);
            this.textBoxTitulo.TabIndex = 1;

            // 
            // labelDescricao
            // 
            this.labelDescricao.ForeColor = System.Drawing.Color.White;
            this.labelDescricao.Location = new System.Drawing.Point(10, 74);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(100, 23);
            this.labelDescricao.TabIndex = 2;
            this.labelDescricao.Text = "Descrição:";

            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(10, 97);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(300, 31);
            this.textBoxDescricao.TabIndex = 3;

            // 
            // labelHorario
            // 
            this.labelHorario.ForeColor = System.Drawing.Color.White;
            this.labelHorario.Location = new System.Drawing.Point(10, 128);
            this.labelHorario.Name = "labelHorario";
            this.labelHorario.Size = new System.Drawing.Size(100, 23);
            this.labelHorario.TabIndex = 4;
            this.labelHorario.Text = "Horário:";

            // 
            // dateTimePickerHorario
            // 
            this.dateTimePickerHorario.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHorario.Location = new System.Drawing.Point(10, 151);
            this.dateTimePickerHorario.Name = "dateTimePickerHorario";
            this.dateTimePickerHorario.ShowUpDown = true;
            this.dateTimePickerHorario.Size = new System.Drawing.Size(150, 31);
            this.dateTimePickerHorario.TabIndex = 5;

            // 
            // labelDiaSemana
            // 
            this.labelDiaSemana.ForeColor = System.Drawing.Color.White;
            this.labelDiaSemana.Location = new System.Drawing.Point(10, 182);
            this.labelDiaSemana.Name = "labelDiaSemana";
            this.labelDiaSemana.Size = new System.Drawing.Size(100, 23);
            this.labelDiaSemana.TabIndex = 6;
            this.labelDiaSemana.Text = "Dia da Semana:";

            // 
            // comboBoxDiaSemana
            // 
            this.comboBoxDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" });
            this.comboBoxDiaSemana.Location = new System.Drawing.Point(10, 205);
            this.comboBoxDiaSemana.Name = "comboBoxDiaSemana";
            this.comboBoxDiaSemana.Size = new System.Drawing.Size(150, 33);
            this.comboBoxDiaSemana.TabIndex = 7;

            // 
            // listBoxRotinas
            // 
            this.listBoxRotinas.ItemHeight = 25;
            this.listBoxRotinas.Location = new System.Drawing.Point(10, 238);
            this.listBoxRotinas.Name = "listBoxRotinas";
            this.listBoxRotinas.Size = new System.Drawing.Size(300, 104);
            this.listBoxRotinas.TabIndex = 8;

            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(13, 358);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(140, 42);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";

            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(170, 361);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 42);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "Editar";

            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(10, 419);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(140, 34);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "Excluir";

            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(170, 419);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(140, 34);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";

            // 
            // scheduler (Syncfusion ScheduleControl)
            // 
            this.scheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduler.Location = new System.Drawing.Point(350, 0);
            this.scheduler.Name = "scheduler";
            this.scheduler.Size = new System.Drawing.Size(850, 767);
            this.scheduler.TabIndex = 0;

            // 
            // RotinasUserControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(32, 46, 57);
            this.Controls.Add(this.scheduler);
            this.Controls.Add(this.panelInputs);
            this.Name = "RotinasUserControl";
            this.Size = new System.Drawing.Size(1200, 767);

            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.ResumeLayout(false);
        }







        #endregion



        private Syncfusion.Windows.Forms.Schedule.ScheduleControl scheduler;
        private System.Windows.Forms.Panel panelInputs;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label labelHorario;
        private System.Windows.Forms.DateTimePicker dateTimePickerHorario;
        private System.Windows.Forms.Label labelDiaSemana;
        private System.Windows.Forms.ComboBox comboBoxDiaSemana;
        private System.Windows.Forms.ListBox listBoxRotinas;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;

    }
}
