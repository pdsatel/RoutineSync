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

            // Painel configurações básicas
            panelInputs.BackColor = Color.Transparent; // ou a cor que quiser
            panelInputs.MinimumSize = new Size(200, 200);

            // Labels - textos fixos não precisam de Location aqui
            labelTitulo.Text = "Título:";
            labelDescricao.Text = "Descrição:";
            labelHorario.Text = "Horário:";
            labelDiaSemana.Text = "Dia da Semana:";

            // ComboBox itens
            comboBoxDiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" });

            // Botões textos
            btnSalvar.Text = "Salvar";
            btnEditar.Text = "Editar";
            btnExcluir.Text = "Excluir";
            btnLimpar.Text = "Limpar";

            // Adiciona controles ao painel
            panelInputs.Controls.Add(labelTitulo);
            panelInputs.Controls.Add(textBoxTitulo);
            panelInputs.Controls.Add(labelDescricao);
            panelInputs.Controls.Add(textBoxDescricao);
            panelInputs.Controls.Add(labelHorario);
            panelInputs.Controls.Add(dateTimePickerHorario);
            panelInputs.Controls.Add(labelDiaSemana);
            panelInputs.Controls.Add(comboBoxDiaSemana);

            // Adiciona controles ao UserControl
            Controls.Add(panelInputs);
            Controls.Add(listBoxRotinas);
            Controls.Add(btnSalvar);
            Controls.Add(btnEditar);
            Controls.Add(btnExcluir);
            Controls.Add(btnLimpar);

            // Configurações gerais do UserControl
            BackColor = Color.FromArgb(32, 46, 57);
            Size = new Size(1200, 767);

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
    }
}
