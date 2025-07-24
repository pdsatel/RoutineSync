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
        public string NovoStatus { get; private set; }


        private string[] statusList = { "Pendente", "Em andamento", "Concluído" };
        private int statusIndex = 0;


        public EditarRotinaForm(string titulo, string descricao, DateTime dataEntrega, string prioridade, string statusAtual)
        {
            InitializeComponent();

            txtTitulo.Text = titulo;
            txtDescricao.Text = descricao;
            dtpDataEntrega.Value = dataEntrega == DateTime.MinValue ? DateTime.Today : dataEntrega;
            cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
            cmbPrioridade.SelectedItem = string.IsNullOrEmpty(prioridade) ? "Média" : prioridade;

            statusIndex = Array.IndexOf(statusList, statusAtual);
            if (statusIndex < 0) statusIndex = 0;

            btnStatusTarefa.Text = statusList[statusIndex];

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            NovoTitulo = txtTitulo.Text.Trim();
            NovaDescricao = txtDescricao.Text.Trim();
            NovaDataEntrega = dtpDataEntrega.Value;
            NovaPrioridade = cmbPrioridade.SelectedItem?.ToString() ?? "Média";
            NovoStatus = statusList[statusIndex]; // Aqui salva o status correto

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnStatusTarefa_Click(object sender, EventArgs e)
        {
            statusIndex = (statusIndex + 1) % statusList.Length;
            btnStatusTarefa.Text = statusList[statusIndex];

            switch (statusList[statusIndex])
            {
                case "Pendente":
                    btnStatusTarefa.BackColor = Color.LightYellow;
                    break;
                case "Em andamento":
                    btnStatusTarefa.BackColor = Color.LightBlue;
                    break;
                case "Concluído":
                    btnStatusTarefa.BackColor = Color.LightGreen;
                    break;
            }
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