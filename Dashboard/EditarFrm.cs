using System;
using System.Windows.Forms;

namespace Tcc
{
    public partial class EditarRotinaForm : Form
    {
        public string NovoTitulo { get; private set; }
        public string NovaDescricao { get; private set; }
        public DateTime NovaDataEntrega { get; private set; }
        public string NovaPrioridade { get; private set; }

        public EditarRotinaForm(string titulo, string descricao, DateTime dataEntrega, string prioridade)
        {
            InitializeComponent();

            txtTitulo.Text = titulo;
            txtDescricao.Text = descricao;
            dtpDataEntrega.Value = dataEntrega == DateTime.MinValue ? DateTime.Today : dataEntrega;
            cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
            cmbPrioridade.SelectedItem = string.IsNullOrEmpty(prioridade) ? "Média" : prioridade;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            NovoTitulo = txtTitulo.Text.Trim();
            NovaDescricao = txtDescricao.Text.Trim();
            NovaDataEntrega = dtpDataEntrega.Value;
            NovaPrioridade = cmbPrioridade.SelectedItem?.ToString() ?? "Média";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dtpDataEntrega_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}