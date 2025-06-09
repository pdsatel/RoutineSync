using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tcc
{
    public partial class RotinasUserControl : UserControl
    {
        private int usuarioId;

        public RotinasUserControl(int usuarioId)
        {
            this.usuarioId = usuarioId;
            InitializeComponent();
        }

        public void CarregarRotinas(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            listViewRotinas.Items.Clear();
            foreach (var tarefa in tarefas)
            {
                var item = new ListViewItem();
                item.Checked = tarefa.Status == "Concluído";
                item.SubItems.Add(tarefa.Titulo);
                item.SubItems.Add(tarefa.DataEntrega.ToShortDateString());
                item.SubItems.Add(tarefa.Status);
                item.SubItems.Add(tarefa.Prioridade);
                item.Tag = tarefa;
                listViewRotinas.Items.Add(item);
            }
        }

        private void listViewRotinas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index >= 0 && e.Index < listViewRotinas.Items.Count)
            {
                var tarefa = (TarefasUserControl.TarefaInfo)listViewRotinas.Items[e.Index].Tag;
                tarefa.Status = (e.NewValue == CheckState.Checked) ? "Concluído" : "Pendente";
                // Se quiser, atualize o banco aqui
            }
        }
    }
}