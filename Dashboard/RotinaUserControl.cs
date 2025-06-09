using System;
using System.Windows.Forms;
using static Tcc.TarefasUserControl;

namespace Tcc
{
    public partial class RotinasUserControl : UserControl

       
    {
        int usuarioId;
        public RotinasUserControl(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            // Associe eventos aqui
            btnAtualizar.Click += BtnAtualizar_Click;
            btnExportar.Click += BtnExportar_Click;
            btnMarcarTodasFeitas.Click += BtnMarcarTodasFeitas_Click;
            listViewRotinas.ItemCheck += ListViewRotinas_ItemCheck;

            // Carregue as rotinas iniciais (exemplo)
           
        }

        public void CarregarRotinas(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            // Limpe o listViewRotinas
            listViewRotinas.Items.Clear();

            foreach (var tarefa in tarefas)
            {
                var item = new ListViewItem(tarefa.Titulo);
                item.SubItems.Add(tarefa.DataEntrega.ToShortDateString());
                item.SubItems.Add(tarefa.Status);
                item.SubItems.Add(tarefa.Prioridade);
                item.SubItems.Add(tarefa.Descricao);
                item.Tag = tarefa;
                listViewRotinas.Items.Add(item);
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            // Atualize a lista de rotinas
            
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            // Exporte as rotinas (exemplo)
            MessageBox.Show("Exportar rotinas - função ainda não implementada.");
        }

        private void BtnMarcarTodasFeitas_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewRotinas.Items)
            {
                item.Checked = true;
                // Aqui você pode incrementar o campo "Execuções/Mês"
                int execucoes = int.Parse(item.SubItems[5].Text);
                execucoes++;
                item.SubItems[5].Text = execucoes.ToString();
            }
            AtualizarResumoExecucoes();
        }

        private void ListViewRotinas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Quando marca/desmarca uma rotina, atualize execuções/mês conforme necessário
            if (e.NewValue == CheckState.Checked)
            {
                var item = listViewRotinas.Items[e.Index];
                int execucoes = int.Parse(item.SubItems[5].Text);
                execucoes++;
                item.SubItems[5].Text = execucoes.ToString();
                AtualizarResumoExecucoes();
            }
        }

        private void AtualizarResumoExecucoes()
        {
            // Soma todas execuções do mês
            int total = 0;
            foreach (ListViewItem item in listViewRotinas.Items)
            {
                total += int.Parse(item.SubItems[5].Text);
            }
            lblResumoExecucoes.Text = $"Total de execuções este mês: {total}";
        }
    }
}