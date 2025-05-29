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
            calendar = new Calendar();
            panelInputs.SuspendLayout();
            SuspendLayout();
            // 
            // panelInputs
            // 
            panelInputs.BackColor = Color.FromArgb(45, 60, 70);
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
            panelInputs.Dock = DockStyle.Left;
            panelInputs.Location = new Point(0, 0);
            panelInputs.Name = "panelInputs";
            panelInputs.Padding = new Padding(10);
            panelInputs.Size = new Size(350, 767);
            panelInputs.TabIndex = 1;
            // 
            // labelTitulo
            // 
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(10, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(100, 23);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Título:";
            // 
            // textBoxTitulo
            // 
            textBoxTitulo.Location = new Point(10, 43);
            textBoxTitulo.Name = "textBoxTitulo";
            textBoxTitulo.Size = new Size(300, 31);
            textBoxTitulo.TabIndex = 1;
            // 
            // labelDescricao
            // 
            labelDescricao.ForeColor = Color.White;
            labelDescricao.Location = new Point(10, 74);
            labelDescricao.Name = "labelDescricao";
            labelDescricao.Size = new Size(100, 23);
            labelDescricao.TabIndex = 2;
            labelDescricao.Text = "Descrição:";
            // 
            // textBoxDescricao
            // 
            textBoxDescricao.Location = new Point(10, 97);
            textBoxDescricao.Name = "textBoxDescricao";
            textBoxDescricao.Size = new Size(300, 31);
            textBoxDescricao.TabIndex = 3;
            // 
            // labelHorario
            // 
            labelHorario.ForeColor = Color.White;
            labelHorario.Location = new Point(10, 128);
            labelHorario.Name = "labelHorario";
            labelHorario.Size = new Size(100, 23);
            labelHorario.TabIndex = 4;
            labelHorario.Text = "Horário:";
            // 
            // dateTimePickerHorario
            // 
            dateTimePickerHorario.Format = DateTimePickerFormat.Time;
            dateTimePickerHorario.Location = new Point(10, 151);
            dateTimePickerHorario.Name = "dateTimePickerHorario";
            dateTimePickerHorario.ShowUpDown = true;
            dateTimePickerHorario.Size = new Size(150, 31);
            dateTimePickerHorario.TabIndex = 5;
            // 
            // labelDiaSemana
            // 
            labelDiaSemana.ForeColor = Color.White;
            labelDiaSemana.Location = new Point(10, 182);
            labelDiaSemana.Name = "labelDiaSemana";
            labelDiaSemana.Size = new Size(100, 23);
            labelDiaSemana.TabIndex = 6;
            labelDiaSemana.Text = "Dia da Semana:";
            // 
            // comboBoxDiaSemana
            // 
            comboBoxDiaSemana.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" });
            comboBoxDiaSemana.Location = new Point(10, 205);
            comboBoxDiaSemana.Name = "comboBoxDiaSemana";
            comboBoxDiaSemana.Size = new Size(150, 33);
            comboBoxDiaSemana.TabIndex = 7;
            // 
            // listBoxRotinas
            // 
            listBoxRotinas.ItemHeight = 25;
            listBoxRotinas.Location = new Point(10, 238);
            listBoxRotinas.Name = "listBoxRotinas";
            listBoxRotinas.Size = new Size(300, 104);
            listBoxRotinas.TabIndex = 8;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(10, 358);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(140, 23);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.Click += btnSalvar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(150, 358);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(140, 23);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(10, 381);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(140, 23);
            btnExcluir.TabIndex = 11;
            btnExcluir.Text = "Excluir";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(150, 381);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(140, 23);
            btnLimpar.TabIndex = 12;
            btnLimpar.Text = "Limpar";
            // 
            // calendar
            // 
            calendar.BackColor = Color.White;
            calendar.CalendarMargin = new Padding(10);
            calendar.CalendarType = Calendar.CalendarTypes.MonthView;
            calendar.Date = new DateTime(2025, 5, 29, 9, 30, 20, 966);
            calendar.DateTemplate = "MMMM yyyy";
            calendar.DateTextColor = Color.FromArgb(80, 80, 155);
            calendar.DateTextFont = new Font("Arial", 14F, FontStyle.Bold);
            calendar.DayOfWeekTextColor = Color.FromArgb(34, 34, 34);
            calendar.DayOfWeekTextFont = new Font("Arial", 9F);
            calendar.DayOfWeekTextTemplate = "ddd";
            calendar.DayPosition = Calendar.DayLocations.UpperLeft;
            calendar.DayTextColor = Color.FromArgb(80, 80, 155);
            calendar.DayTextFont = new Font("Arial", 14F, FontStyle.Bold);
            calendar.Dock = DockStyle.Fill;
            calendar.GrayedOutDayTextColor = Color.FromArgb(200, 200, 200);
            calendar.GridLinesColor = Color.FromArgb(200, 210, 255);
            calendar.HandleDefaultNavigationClick = true;
            calendar.Location = new Point(350, 0);
            calendar.Margin = new Padding(5, 6, 5, 6);
            calendar.MaximumNumberOfEventsToShowInMonthView = 4;
            calendar.Name = "calendar";
            calendar.NavigationButtonsBorderColor = Color.FromArgb(197, 197, 197);
            calendar.NavigationButtonsColor = Color.FromArgb(245, 245, 245);
            calendar.NavigationButtonsFont = new Font("Arial", 13F, FontStyle.Bold);
            calendar.NavigationButtonsHoverColor = Color.FromArgb(250, 250, 250);
            calendar.NavigationButtonsTextColor = Color.FromArgb(68, 68, 68);
            calendar.ShowCommonHolidays = true;
            calendar.ShowDate = true;
            calendar.ShowFederalHolidays = true;
            calendar.ShowGrayedOutDays = true;
            calendar.ShowNavigationButtons = true;
            calendar.ShowTodayButton = true;
            calendar.Size = new Size(850, 767);
            calendar.TabIndex = 0;
            calendar.TodayButtonBorderColor = Color.FromArgb(197, 197, 197);
            calendar.TodayButtonColor = Color.FromArgb(245, 245, 245);
            calendar.TodayButtonDisabledTextColor = Color.FromArgb(184, 184, 184);
            calendar.TodayButtonFont = new Font("Arial", 13F, FontStyle.Bold);
            calendar.TodayButtonHeight = 29;
            calendar.TodayButtonHoverColor = Color.FromArgb(250, 250, 250);
            calendar.TodayButtonTextColor = Color.FromArgb(68, 68, 68);
            calendar.TodayButtonWidth = 112;
            calendar.WeekDaysBackgroundColor = Color.White;
            calendar.WeekEndsBackgroundColor = Color.FromArgb(240, 250, 255);
            // 
            // RotinaUserControl
            // 
            BackColor = Color.FromArgb(32, 46, 57);
            Controls.Add(calendar);
            Controls.Add(panelInputs);
            Name = "RotinaUserControl";
            Size = new Size(1200, 767);
            Load += RotinasUserControl_Load;
            SizeChanged += RotinaUserControl_SizeChanged;
            panelInputs.ResumeLayout(false);
            panelInputs.PerformLayout();
            ResumeLayout(false);
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
