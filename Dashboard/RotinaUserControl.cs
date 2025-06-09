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
            listViewRotinas.ItemCheck += listViewRotinas_ItemCheck;
            this.editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            this.excluirToolStripMenuItem.Click += excluirToolStripMenuItem_Click;

            // Carregue as rotinas iniciais (exemplo)

        }

        public void CarregarRotinas(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            // Limpe o listViewRotinas
            listViewRotinas.Items.Clear();

            listViewRotinas.Groups.Clear();
            var gruposPorData = new Dictionary<string, ListViewGroup>();

            foreach (var tarefa in tarefas)
            {
                var data = tarefa.DataEntrega;
                string datastr = tarefa.DataEntrega.ToShortDateString();

                if (!gruposPorData.ContainsKey(datastr))
                {
                    var grupo = new ListViewGroup(datastr, datastr);
                    listViewRotinas.Groups.Add(grupo);
                    gruposPorData[datastr] = grupo;
                }

                var item = new ListViewItem(""); // Coluna "Feito" (checkbox)
                item.SubItems.Add(tarefa.Titulo); // Coluna "Título"
                item.SubItems.Add(tarefa.DataEntrega.ToShortDateString()); // Data
                item.SubItems.Add(tarefa.Status); // Coluna "Status"
                item.SubItems.Add(tarefa.Prioridade); // Coluna "Prioridade"
                item.SubItems.Add("0"); // Ou tarefa.ExecucoesMes, se existir
                item.Tag = tarefa;
                item.Group = gruposPorData[datastr];
                listViewRotinas.Items.Add(item);
            }
            AtualizarResumoExecucoes();
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

        private void listViewRotinas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                // Pergunta ao usuário
                var result = MessageBox.Show("Tem certeza que deseja marcar esta tarefa como concluída?", "Confirmar conclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Aguarda o estado ser alterado, então remove
                    this.BeginInvoke(new Action(() =>
                    {
                        var item = listViewRotinas.Items[e.Index];
                        listViewRotinas.Items.Remove(item);
                        // Aqui, se quiser, atualize o status no banco de dados também!
                        AtualizarResumoExecucoes();
                    }));
                }
                else
                {
                    // Cancela o check
                    e.NewValue = CheckState.Unchecked;
                }
            }
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                var tarefa = (TarefasUserControl.TarefaInfo)item.Tag;
                // Aqui você pode abrir um painel de edição, formulário, ou editar inline.
                MessageBox.Show($"Editar tarefa: {tarefa.Titulo}");
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                if (MessageBox.Show("Confirma exclusão desta tarefa?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    listViewRotinas.Items.Remove(item);
                    // Remova do banco também, se necessário
                }
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