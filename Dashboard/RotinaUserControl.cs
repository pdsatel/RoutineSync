using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Syncfusion.Windows.Forms.Tools;
using Tcc;
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

            // Associe eventos aqui
            btnAtualizar.Click += BtnAtualizar_Click;
            btnExportar.Click += BtnExportar_Click;
            listViewRotinas.ItemCheck += listViewRotinas_ItemCheck;
            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
            excluirToolStripMenuItem.Click += excluirToolStripMenuItem_Click;
            btnConcluir.Click += btnConcluir_Click;
            listViewRotinas.OwnerDraw = true;
            listViewRotinas.DrawColumnHeader += (s, e) => e.DrawDefault = true;
            listViewRotinas.DrawSubItem += ListViewRotinas_DrawSubItem;

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
            listViewRotinas.Groups.Clear();

            // Dicionário para armazenar grupos por data
            Dictionary<string, ListViewGroup> gruposPorData = new Dictionary<string, ListViewGroup>();

            foreach (var tarefa in tarefas)
            {
                // Trata datas não definidas ou zeradas
                string dataGrupoStr;
                if (tarefa.DataEntrega == DateTime.MinValue)
                {
                    dataGrupoStr = "Sem data";
                }
                else
                {
                    dataGrupoStr = tarefa.DataEntrega.Date.ToString("dd/MM/yyyy");
                }

                // Crie o grupo se não existir ainda
                if (!gruposPorData.ContainsKey(dataGrupoStr))
                {
                    var grupo = new ListViewGroup(dataGrupoStr, HorizontalAlignment.Left);
                    gruposPorData[dataGrupoStr] = grupo;
                    listViewRotinas.Groups.Add(grupo);
                }

                var item = new ListViewItem(tarefa.Titulo);                    // Coluna 1: Título
                item.SubItems.Add(tarefa.DataEntrega == DateTime.MinValue ? "Sem data" : tarefa.DataEntrega.ToString("dd/MM/yyyy"));              // Coluna 2: Data Entrega
                item.SubItems.Add(tarefa.Status);                              // Coluna 3: Status
                item.SubItems.Add(tarefa.Prioridade);                          // Coluna 4: Prioridade
                item.SubItems.Add(tarefa.Descricao != null && tarefa.Descricao.Length > 50
                    ? tarefa.Descricao.Substring(0, 50) + "..."
                    : tarefa.Descricao ?? "");                                 // Coluna 5: Descrição
                item.Tag = tarefa;
                item.Checked = tarefa.Status != null &&
                               (tarefa.Status.Equals("Concluído", StringComparison.OrdinalIgnoreCase) ||
                                tarefa.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));

                if (item.Checked)
                {
                    item.BackColor = System.Drawing.Color.LightGreen;
                }

                // Adiciona o item ao grupo correspondente
                item.Group = gruposPorData[dataGrupoStr];
                listViewRotinas.Items.Add(item);
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {


            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());

        }
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewRotinas.Items)
            {
                if (item.Checked)
                {
                    if (item.Tag is TarefasUserControl.TarefaInfo tarefa)
                    {
                        // Atualiza no banco
                        using (MySqlConnection conn = Conexao.ObterConexao())
                        {
                            string sql = "UPDATE Tarefas SET status = 'concluida' WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id", tarefa.Id);
                            cmd.ExecuteNonQuery();
                        }
                        // Atualiza no objeto em memória
                        tarefa.Status = "Concluído";
                        item.Tag = tarefa; // (Redundante, mas mantém atualizado)
                    }
                }
            }

            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exportar rotinas - função ainda não implementada.");
        }
        private void listViewRotinas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
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

                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                TarefasUserControl.TarefaInfo tarefa = item.Tag as TarefasUserControl.TarefaInfo;
                if (tarefa != null)
                {
                    using (var frm = new EditarRotinaForm(
                        tarefa.Titulo,
                        tarefa.Descricao,
                        tarefa.DataEntrega,
                        tarefa.Prioridade))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // 1. Atualiza o objeto em memória
                            tarefa.Titulo = frm.NovoTitulo;
                            tarefa.Descricao = frm.NovaDescricao;
                            tarefa.DataEntrega = frm.NovaDataEntrega;
                            tarefa.Prioridade = frm.NovaPrioridade;

                            // 2. Atualiza no banco de dados
                            using (MySqlConnection conn = Conexao.ObterConexao())
                            {
                                string sql = "UPDATE Tarefas SET titulo = @titulo, descricao = @descricao, data_entrega = @data, prioridade = @prioridade WHERE id = @id";
                                MySqlCommand cmd = new MySqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@id", tarefa.Id);
                                cmd.Parameters.AddWithValue("@titulo", tarefa.Titulo);
                                cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);
                                cmd.Parameters.AddWithValue("@data", tarefa.DataEntrega);
                                cmd.Parameters.AddWithValue("@prioridade", tarefa.Prioridade);
                                cmd.ExecuteNonQuery();
                            }

                            // 3. Recarrega o ListView com as rotinas atualizadas
                            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
                            MessageBox.Show("Rotina atualizada com sucesso!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma rotina para editar.");
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                TarefaInfo tarefa = item.Tag as TarefaInfo;
                if (tarefa != null &&
                    MessageBox.Show("Confirma exclusão desta rotina?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (MySqlConnection conn = Conexao.ObterConexao())
                    {
                        string sql = "DELETE FROM Tarefas WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", tarefa.Id);
                        cmd.ExecuteNonQuery();
                    }
                    AtualizarRotinas();
                    MessageBox.Show("Rotina removida!");
                }
            }
        }
        private void ListViewRotinas_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            int prioridadeColIndex = 3; // 0: Título, 1: Data Entrega, 2: Status, 3: Prioridade, 4: Descrição

            // Checa se a rotina está concluída
            bool isConcluida = false;
            if (e.Item.Tag is TarefasUserControl.TarefaInfo tarefa)
            {
                isConcluida = tarefa.Status != null &&
                    (tarefa.Status.Equals("Concluído", StringComparison.OrdinalIgnoreCase) ||
                     tarefa.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            }

            if (isConcluida)
            {
                // Linha inteira verde claro
                using (Brush bg = new SolidBrush(Color.LightGreen))
                    e.Graphics.FillRectangle(bg, e.Bounds);

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                Color textColor = e.Item.Selected ? SystemColors.HighlightText : e.SubItem.ForeColor;
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, textColor, flags);
            }
            else if (e.ColumnIndex == prioridadeColIndex)
            {
                // Só a célula da prioridade colorida
                Color corFundo;
                string prioridade = e.SubItem.Text.ToLower();

                if (prioridade.Contains("baixa"))
                    corFundo = Color.FromArgb(200, 255, 255, 200); // Verde claro
                else if (prioridade.Contains("média") || prioridade.Contains("media"))
                    corFundo = Color.FromArgb(255, 255, 220, 180); // Laranja claro
                else if (prioridade.Contains("alta"))
                    corFundo = Color.FromArgb(255, 220, 120, 120); // Vermelho claro
                else
                    corFundo = e.Item.Selected ? SystemColors.Highlight : e.SubItem.BackColor;

                using (Brush bg = new SolidBrush(corFundo))
                    e.Graphics.FillRectangle(bg, e.Bounds);

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                Color textColor = e.Item.Selected ? SystemColors.HighlightText : e.SubItem.ForeColor;
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, textColor, flags);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
        public void AtualizarRotinas()
        {
            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
        }
      
    }
    
}