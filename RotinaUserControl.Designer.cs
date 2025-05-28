using CalendarNet;


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
            components = new System.ComponentModel.Container();

            panelInputs = new Panel();
            labelTitulo = new Label();
            textBoxTitulo = new TextBox();
            labelDescricao = new Label();
            textBoxDescricao = new TextBox();
            labelHorario = new Label();
            dateTimePickerHorario = new DateTimePicker();
            labelDiaSemana = new Label();
            comboBoxDiaSemana = new ComboBox();
            listBoxRotinas = new ListBox();
            btnSalvar = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnLimpar = new Button();
            calendar = new CalendarNet.Calendar();

            // Painel de Inputs
            panelInputs.Dock = DockStyle.Left;
            panelInputs.Width = 350;
            panelInputs.Padding = new Padding(10);
            panelInputs.BackColor = Color.FromArgb(45, 60, 70);

            // Labels e Inputs
            labelTitulo.Text = "Título:";
            labelTitulo.Top = 20;
            labelTitulo.Left = 10;
            labelTitulo.ForeColor = Color.White;

            textBoxTitulo.Top = labelTitulo.Bottom + 5;
            textBoxTitulo.Left = 10;
            textBoxTitulo.Width = 300;

            labelDescricao.Text = "Descrição:";
            labelDescricao.Top = textBoxTitulo.Bottom + 15;
            labelDescricao.Left = 10;
            labelDescricao.ForeColor = Color.White;

            textBoxDescricao.Top = labelDescricao.Bottom + 5;
            textBoxDescricao.Left = 10;
            textBoxDescricao.Width = 300;

            labelHorario.Text = "Horário:";
            labelHorario.Top = textBoxDescricao.Bottom + 15;
            labelHorario.Left = 10;
            labelHorario.ForeColor = Color.White;

            dateTimePickerHorario.Top = labelHorario.Bottom + 5;
            dateTimePickerHorario.Left = 10;
            dateTimePickerHorario.Width = 150;
            dateTimePickerHorario.Format = DateTimePickerFormat.Time;
            dateTimePickerHorario.ShowUpDown = true;

            labelDiaSemana.Text = "Dia da Semana:";
            labelDiaSemana.Top = dateTimePickerHorario.Bottom + 15;
            labelDiaSemana.Left = 10;
            labelDiaSemana.ForeColor = Color.White;

            comboBoxDiaSemana.Top = labelDiaSemana.Bottom + 5;
            comboBoxDiaSemana.Left = 10;
            comboBoxDiaSemana.Width = 150;
            comboBoxDiaSemana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" });

            listBoxRotinas.Top = comboBoxDiaSemana.Bottom + 15;
            listBoxRotinas.Left = 10;
            listBoxRotinas.Width = 300;
            listBoxRotinas.Height = 120;

            // Botões
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = listBoxRotinas.Bottom + 10;
            btnSalvar.Left = 10;
            btnSalvar.Width = 140;

            btnEditar.Text = "Editar";
            btnEditar.Top = btnSalvar.Top;
            btnEditar.Left = btnSalvar.Right + 10;
            btnEditar.Width = 140;

            btnExcluir.Text = "Excluir";
            btnExcluir.Top = btnSalvar.Bottom + 10;
            btnExcluir.Left = 10;
            btnExcluir.Width = 140;

            btnLimpar.Text = "Limpar";
            btnLimpar.Top = btnExcluir.Top;
            btnLimpar.Left = btnExcluir.Right + 10;
            btnLimpar.Width = 140;

            // Adiciona todos os controles ao painel
            panelInputs.Controls.Add(labelTitulo);
            panelInputs.Controls.Add(textBoxTitulo);
            panelInputs.Controls.Add(labelDescricao);
            panelInputs.Controls.Add(textBoxDescricao);
            panelInputs.Controls.Add(labelHorario);
            panelInputs.Controls.Add(dateTimePickerHorario);
            panelInputs.Controls.Add(labelDiaSemana);
            panelInputs.Controls.Add(comboBoxDiaSemana);
            panelInputs.Controls.Add(listBoxRotinas);
            panelInputs.Controls.Add(btnSalvar);
            panelInputs.Controls.Add(btnEditar);
            panelInputs.Controls.Add(btnExcluir);
            panelInputs.Controls.Add(btnLimpar);

            // Calendário
            calendar.Dock = DockStyle.Fill;
            calendar.BackColor = Color.White;

            // UserControl
            BackColor = Color.FromArgb(32, 46, 57);
            Size = new Size(1200, 767);
            Controls.Add(calendar);
            Controls.Add(panelInputs);

            // Eventos
            Load += RotinasUserControl_Load;
            SizeChanged += RotinaUserControl_SizeChanged;
        }






        #endregion

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
        private Panel panelInputs;
        private CalendarNet.Calendar calendar;

    }
}
