using System;
using System.Windows.Forms;

namespace Tcc
{
    public partial class DashboardFrm : Form
    {
        public DashboardFrm()
        {
            InitializeComponent();
        }

        private void DashboardFrm_Load(object sender, EventArgs e)
        {
            // Pode carregar painel inicial aqui, se quiser
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            // ListView para exibir tarefas
            ListView listViewTarefas = new ListView();
            listViewTarefas.View = View.Details;
            listViewTarefas.FullRowSelect = true;
            listViewTarefas.GridLines = true;
            listViewTarefas.Columns.Add("Título", 200);
            listViewTarefas.Columns.Add("Data Entrega", 120);
            listViewTarefas.Columns.Add("Status", 100);
            listViewTarefas.Columns.Add("Prioridade", 100);
            listViewTarefas.Location = new Point(10, 10);
            listViewTarefas.Size = new Size(600, 400);
            panelConteudo.Controls.Add(listViewTarefas);

            // Campos para criar/editar tarefa (exemplo simples)
            Label lblTitulo = new Label() { Text = "Título", Location = new Point(620, 10) };
            TextBox txtTitulo = new TextBox() { Location = new Point(620, 30), Width = 250 };

            Label lblDescricao = new Label() { Text = "Descrição", Location = new Point(620, 60) };
            TextBox txtDescricao = new TextBox() { Location = new Point(620, 80), Width = 250, Height = 80, Multiline = true };

            Label lblData = new Label() { Text = "Data de Entrega", Location = new Point(620, 170) };
            DateTimePicker dtpDataEntrega = new DateTimePicker() { Location = new Point(620, 190) };

            Label lblStatus = new Label() { Text = "Status", Location = new Point(620, 220) };
            ComboBox cmbStatus = new ComboBox() { Location = new Point(620, 240), Width = 150 };
            cmbStatus.Items.AddRange(new string[] { "Pendente", "Em andamento", "Concluído" });
            cmbStatus.SelectedIndex = 0;

            Label lblPrioridade = new Label() { Text = "Prioridade", Location = new Point(620, 270) };
            ComboBox cmbPrioridade = new ComboBox() { Location = new Point(620, 290), Width = 150 };
            cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
            cmbPrioridade.SelectedIndex = 1;

            Button btnSalvar = new Button() { Text = "Salvar", Location = new Point(620, 340), Width = 100 };
            Button btnExcluir = new Button() { Text = "Excluir", Location = new Point(740, 340), Width = 100 };

            panelConteudo.Controls.AddRange(new Control[] {
            lblTitulo, txtTitulo, lblDescricao, txtDescricao,
            lblData, dtpDataEntrega, lblStatus, cmbStatus,
            lblPrioridade, cmbPrioridade, btnSalvar, btnExcluir
             });


        }

        private void btnRotina_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir painel de Rotina");
        }

        private void btnSaude_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir painel de Saúde");
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir painel de Relatórios");
        }

        private void btnIA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir painel de Sugestões IA");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
