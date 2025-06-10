using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Tcc.TarefasUserControl;

namespace Tcc
{
    public partial class RotinasUserControl : UserControl
    {
        int usuarioId;

        // Simulação de lista de tarefas/rotinas (substitua pelo seu repositório real)
        private List<TarefaInfo> listaRotinas = new List<TarefaInfo>();
        private TarefasUserControl tarefasControl;

        public RotinasUserControl(TarefasUserControl tarefasControl)
        {
            InitializeComponent();
            this.usuarioId = tarefasControl.UsuarioId;
            this.tarefasControl = tarefasControl;

            var tarefas = tarefasControl.BuscarTarefasBanco();
            CarregarRotinasDeTarefas(tarefas);


            // Associe eventos aqui
            btnAtualizar.Click += BtnAtualizar_Click;
            btnExportar.Click += BtnExportar_Click;
            btnMarcarTodasFeitas.Click += BtnMarcarTodasFeitas_Click;
            listViewRotinas.ItemCheck += listViewRotinas_ItemCheck;
           
            excluirToolStripMenuItem.Click += excluirToolStripMenuItem_Click;

            // Carregue as rotinas iniciais
            
        }

        // Método para buscar rotinas (simulação, adapte para banco de dados se necessário)
        private List<TarefaInfo> BuscarRotinasUsuario()
        {
            // Exemplo: retorna todas as rotinas do usuário
            // Filtre por usuárioId se for necessário
            return listaRotinas;
        }

        public void CarregarRotinasDeTarefas(List<TarefaInfo> tarefas)
        {
            listViewRotinas.Items.Clear();
            foreach (var tarefa in tarefas)
            {
                var item = new ListViewItem(""); // checkbox
                item.SubItems.Add(tarefa.Titulo);
                item.SubItems.Add(tarefa.Descricao.Length > 50 ? tarefa.Descricao.Substring(0, 50) + "..." : tarefa.Descricao);
                item.SubItems.Add(tarefa.Status);
                item.SubItems.Add(tarefa.Prioridade);
                item.SubItems.Add("0"); // execuções/mês, inicial
                item.Tag = tarefa;
                item.Checked = tarefa.Status.ToLower() == "concluído" || tarefa.Status.ToLower() == "concluida";
                listViewRotinas.Items.Add(item);
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                long tarefaId = (long)item.Tag;
                using (MySqlConnection conn = Conexao.ObterConexao())
                {
                    string sql = "UPDATE Tarefas SET status = 'Concluído' WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", tarefaId);
                    cmd.ExecuteNonQuery();
                }
                
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                long tarefaId = (long)item.Tag;

                // Monte e mostre um formulário de edição (ou campos na tela)
                // Depois que o usuário editar e clicar em salvar:
                // UPDATE Tarefas SET ... WHERE id = @id
                // E recarregue a lista:
                CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                if (MessageBox.Show("Confirma exclusão desta tarefa?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Remova do banco/lista também, se necessário
                    var tarefa = (TarefaInfo)item.Tag;
                    listaRotinas.Remove(tarefa);
                    listViewRotinas.Items.Remove(item);
                    AtualizarResumoExecucoes();
                }
            }
        }

        private void AtualizarResumoExecucoes()
        {
            int total = 0;
            foreach (ListViewItem item in listViewRotinas.Items)
            {
                total += int.Parse(item.SubItems[5].Text);
            }
            lblResumoExecucoes.Text = $"Total de execuções este mês: {total}";
        }

        private void lblResumoExecucoes_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                long tarefaId = (long)item.Tag;
                if (MessageBox.Show("Confirma exclusão desta rotina?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (MySqlConnection conn = Conexao.ObterConexao())
                    {
                        string sql = "DELETE FROM Tarefas WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", tarefaId);
                        cmd.ExecuteNonQuery();
                    }
                    CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
                }
            }
        }
    }
}