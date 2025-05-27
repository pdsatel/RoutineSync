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
            panelInputs.SuspendLayout();
            SuspendLayout();
            // 
            // panelInputs
            // 
            panelInputs.Controls.Add(labelTitulo);
            panelInputs.Controls.Add(textBoxTitulo);
            panelInputs.Controls.Add(labelDescricao);
            panelInputs.Controls.Add(textBoxDescricao);
            panelInputs.Controls.Add(labelHorario);
            panelInputs.Controls.Add(dateTimePickerHorario);
            panelInputs.Controls.Add(labelDiaSemana);
            panelInputs.Controls.Add(comboBoxDiaSemana);
            listBoxRotinas.Location = new Point(panelInputs.Right + 30, panelInputs.Top);
            panelInputs.Name = "panelInputs";
            listBoxRotinas.Size = new Size(300, 400);
            panelInputs.TabIndex = 0;
            panelInputs.SizeChanged += RotinaUserControl_SizeChanged;



            int btnTop = panelInputs.Bottom + 20;
            btnSalvar.Location = new Point(panelInputs.Left, btnTop);
            btnEditar.Location = new Point(btnSalvar.Right + 10, btnTop);
            btnExcluir.Location = new Point(btnEditar.Right + 10, btnTop);
            btnLimpar.Location = new Point(btnExcluir.Right + 10, btnTop);


            // labelTitulo
            // 
            labelTitulo.Location = new Point(0, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(100, 23);
            labelTitulo.TabIndex = 0;
            // 
            // textBoxTitulo
            // 
            textBoxTitulo.Location = new Point(0, 0);
            textBoxTitulo.Name = "textBoxTitulo";
            textBoxTitulo.Size = new Size(100, 31);
            textBoxTitulo.TabIndex = 1;
            // 
            // labelDescricao
            // 
            labelDescricao.Location = new Point(0, 0);
            labelDescricao.Name = "labelDescricao";
            labelDescricao.Size = new Size(100, 23);
            labelDescricao.TabIndex = 2;
            // 
            // textBoxDescricao
            // 
            textBoxDescricao.Location = new Point(0, 0);
            textBoxDescricao.Name = "textBoxDescricao";
            textBoxDescricao.Size = new Size(100, 31);
            textBoxDescricao.TabIndex = 3;
            // 
            // labelHorario
            // 
            labelHorario.Location = new Point(0, 0);
            labelHorario.Name = "labelHorario";
            labelHorario.Size = new Size(100, 23);
            labelHorario.TabIndex = 4;
            // 
            // dateTimePickerHorario
            // 
            dateTimePickerHorario.Location = new Point(0, 0);
            dateTimePickerHorario.Name = "dateTimePickerHorario";
            dateTimePickerHorario.Size = new Size(200, 31);
            dateTimePickerHorario.TabIndex = 5;
            // 
            // labelDiaSemana
            // 
            labelDiaSemana.Location = new Point(0, 0);
            labelDiaSemana.Name = "labelDiaSemana";
            labelDiaSemana.Size = new Size(100, 23);
            labelDiaSemana.TabIndex = 6;
            // 
            // comboBoxDiaSemana
            // 
            comboBoxDiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" });
            comboBoxDiaSemana.Location = new Point(0, 0);
            comboBoxDiaSemana.Name = "comboBoxDiaSemana";
            comboBoxDiaSemana.Size = new Size(121, 33);
            comboBoxDiaSemana.TabIndex = 7;
            // 
            // listBoxRotinas
            // 
            listBoxRotinas.ItemHeight = 25;
            listBoxRotinas.Location = new Point(350, 150);
            listBoxRotinas.Name = "listBoxRotinas";
            listBoxRotinas.Size = new Size(120, 79);
            listBoxRotinas.TabIndex = 1;
            // 
            // btnSalvar
            // 
            btnSalvar.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            btnSalvar.Location = new Point(0, 0);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 2;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnEditar
            // 
            btnEditar.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            btnEditar.Location = new Point(0, 0);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 3;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            btnExcluir.Location = new Point(0, 0);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 4;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.FlatAppearance.BorderColor = Color.FromArgb(74, 144, 226);
            btnLimpar.Location = new Point(0, 0);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 5;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // RotinaUserControl
            // 
            BackColor = Color.FromArgb(32, 46, 57);
            Controls.Add(panelInputs);
            Controls.Add(listBoxRotinas);
            Controls.Add(btnSalvar);
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(btnLimpar);
            Name = "RotinaUserControl";
            Size = new Size(1200, 767);
            Load += this.RotinasUserControl_Load;
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
    }
}
