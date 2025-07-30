// Importa as bibliotecas necessárias.
using System;
using System.Windows.Forms;

namespace Tcc
{
    // Define a classe para o formulário de edição de rotina.
    // Este formulário funciona como uma janela de diálogo modal para editar os detalhes de uma rotina existente.
    public partial class EditarRotinaForm : Form
    {
        // Propriedades públicas para armazenar os novos valores editados pelo usuário.
        // O código que abriu este formulário irá ler estas propriedades após o fechamento para obter os dados atualizados.
        // O 'private set' garante que esses valores só podem ser definidos dentro desta classe.
        public string NovoTitulo { get; private set; }
        public string NovaDescricao { get; private set; }
        public DateTime NovaDataEntrega { get; private set; }
        public string NovaPrioridade { get; private set; }
        public string NovoStatus { get; private set; }

        // Lista fixa de status possíveis para uma rotina/tarefa.
        private string[] statusList = { "Pendente", "Em andamento", "Concluído" };
        // Índice para controlar qual status da 'statusList' está selecionado.
        private int statusIndex = 0;

        // Construtor do formulário. Recebe os dados atuais da rotina para preencher os campos.
        public EditarRotinaForm(string titulo, string descricao, DateTime dataEntrega, string prioridade, string statusAtual)
        {
            InitializeComponent(); // Inicializa os componentes visuais do formulário.

            // Preenche os campos do formulário (TextBox, DateTimePicker, ComboBox) com os valores atuais da rotina.
            txtTitulo.Text = titulo;
            txtDescricao.Text = descricao;
            // Se a data de entrega for o valor mínimo (não definida), usa a data de hoje como padrão.
            dtpDataEntrega.Value = dataEntrega == DateTime.MinValue ? DateTime.Today : dataEntrega;
            // Adiciona as opções de prioridade ao ComboBox.
            cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
            // Define a prioridade selecionada, com "Média" como padrão se nenhuma for fornecida.
            cmbPrioridade.SelectedItem = string.IsNullOrEmpty(prioridade) ? "Média" : prioridade;

            // Encontra o índice do status atual na lista de status para inicializar o botão corretamente.
            statusIndex = Array.IndexOf(statusList, statusAtual);
            if (statusIndex < 0) statusIndex = 0; // Se o status não for encontrado, assume o primeiro (Pendente).

            // Define o texto do botão de status para o status atual da tarefa.
            btnStatusTarefa.Text = statusList[statusIndex];
        }

        // Evento de clique para o botão "Salvar".
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Atribui os valores dos campos do formulário às propriedades públicas.
            // O '.Trim()' remove espaços em branco do início e do fim do texto.
            NovoTitulo = txtTitulo.Text.Trim();
            NovaDescricao = txtDescricao.Text.Trim();
            NovaDataEntrega = dtpDataEntrega.Value;
            // Usa o operador '??' para garantir que "Média" seja o padrão se nada for selecionado.
            NovaPrioridade = cmbPrioridade.SelectedItem?.ToString() ?? "Média";
            NovoStatus = statusList[statusIndex]; // Salva o status que foi definido pelo botão de status.

            // Define o resultado do diálogo como OK. Isso informa ao código que chamou o formulário que o usuário confirmou as alterações.
            this.DialogResult = DialogResult.OK;
            this.Close(); // Fecha o formulário.
        }

        // Evento de clique para o botão que controla o status da tarefa.
        private void btnStatusTarefa_Click(object sender, EventArgs e)
        {
            // Usa o operador de módulo (%) para ciclar pelo array 'statusList'.
            // Quando o índice chega ao fim do array, ele volta para 0.
            statusIndex = (statusIndex + 1) % statusList.Length;
            btnStatusTarefa.Text = statusList[statusIndex]; // Atualiza o texto do botão com o novo status.

            // Muda a cor de fundo do botão para dar um feedback visual do status atual.
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

        // Evento de clique para o botão "Cancelar".
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Define o resultado do diálogo como Cancel. Isso informa que o usuário cancelou a operação.
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Fecha o formulário sem salvar as alterações.
        }

        // Evento gerado pelo designer quando o valor da data é alterado (sem implementação aqui).
        private void dtpDataEntrega_ValueChanged(object sender, EventArgs e)
        {
            // Nenhuma ação necessária.
        }
    }
}