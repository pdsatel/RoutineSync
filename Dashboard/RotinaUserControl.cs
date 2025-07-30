using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Tcc;
// Importa estaticamente a classe TarefaInfo para poder usá-la sem o prefixo TarefasUserControl.
using static Tcc.TarefasUserControl;

namespace Tcc
{
    // Define um UserControl para exibir tarefas em formato de "rotina", agrupadas por data.
    public partial class RotinasUserControl : UserControl
    {
        // Campos para armazenar o ID do usuário e a referência ao controle de tarefas.
        int usuarioId;
        private TarefasUserControl tarefasControl;

        // Construtor que recebe uma instância de TarefasUserControl.
        // Isso é um exemplo de injeção de dependência, permitindo que este controle acesse dados e funcionalidades do outro.
        public RotinasUserControl(TarefasUserControl tarefasControl)
        {
            InitializeComponent();
            // Armazena a referência ao controle de tarefas e obtém o ID do usuário a partir dele.
            this.tarefasControl = tarefasControl;
            this.usuarioId = tarefasControl.UsuarioId;
            this.Dock = DockStyle.Fill; // Faz o controle preencher o espaço do seu contêiner.

            // Associa os métodos de tratamento aos eventos dos controles.
            btnAtualizar.Click += BtnAtualizar_Click;
            excluirToolStripMenuItem.Click += excluirToolStripMenuItem_Click;
            btnConcluir.Click += btnConcluir_Click;

            // Habilita o desenho personalizado do ListView para colorização.
            listViewRotinas.OwnerDraw = true;
            listViewRotinas.DrawColumnHeader += (s, e) => e.DrawDefault = true; // Desenho padrão para o cabeçalho.
            listViewRotinas.DrawSubItem += ListViewRotinas_DrawSubItem; // Método customizado para desenhar as células.

            // Carrega as rotinas na inicialização do controle.
            // A chamada é feita duas vezes, a segunda sobrepõe a primeira. Pode ser simplificado para uma chamada.
            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
        }

        // Método principal para popular o ListView. Ele organiza as tarefas em grupos por data.
        public void CarregarRotinasDeTarefas(List<TarefaInfo> tarefas)
        {
            listViewRotinas.Items.Clear(); // Limpa itens existentes.
            listViewRotinas.Groups.Clear(); // Limpa grupos existentes.

            // Um dicionário ordenado é usado para garantir que os grupos de datas apareçam em ordem cronológica.
            SortedDictionary<string, ListViewGroup> gruposPorData = new SortedDictionary<string, ListViewGroup>();

            foreach (var tarefa in tarefas)
            {
                // Determina o nome do grupo com base na data de entrega da tarefa.
                string dataGrupoStr;
                if (tarefa.DataEntrega == DateTime.MinValue)
                {
                    dataGrupoStr = "Sem data";
                }
                else
                {
                    dataGrupoStr = tarefa.DataEntrega.ToString("dd/MM/yyyy HH:mm"); // Agrupamento por data e hora.
                }

                // Se o grupo para esta data ainda não existe, ele é criado.
                if (!gruposPorData.ContainsKey(dataGrupoStr))
                {
                    var grupo = new ListViewGroup(dataGrupoStr, HorizontalAlignment.Left);
                    gruposPorData[dataGrupoStr] = grupo;
                    listViewRotinas.Groups.Add(grupo);
                }

                // Cria o item do ListView com os dados da tarefa.
                var item = new ListViewItem(tarefa.Titulo);
                item.SubItems.Add(tarefa.DataEntrega == DateTime.MinValue ? "Sem data" : tarefa.DataEntrega.ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(tarefa.Status);
                item.SubItems.Add(tarefa.Prioridade);
                // Exibe um resumo da descrição para não ocupar muito espaço.
                item.SubItems.Add(tarefa.Descricao != null && tarefa.Descricao.Length > 50 ? tarefa.Descricao.Substring(0, 50) + "..." : tarefa.Descricao ?? "");

                // Armazena o objeto de dados completo na propriedade Tag do item para fácil acesso posterior.
                item.Tag = tarefa;

                // Marca o item como concluído visualmente.
                item.Checked = tarefa.Status != null && (tarefa.Status.Equals("Concluído", StringComparison.OrdinalIgnoreCase) || tarefa.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));

                if (item.Checked)
                {
                    item.BackColor = System.Drawing.Color.LightGreen;
                }

                // Atribui o item ao seu grupo correspondente.
                item.Group = gruposPorData[dataGrupoStr];
                listViewRotinas.Items.Add(item);
            }
        }

        // Evento de clique do botão "Atualizar".
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            // Busca os dados mais recentes do banco e recarrega a lista.
            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
        }

        // Evento de clique do botão "Concluir".
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            // Verifica se um item está selecionado.
            if (listViewRotinas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione uma tarefa para marcar como concluída.");
                return;
            }

            ListViewItem item = listViewRotinas.SelectedItems[0];

            // Obtém os dados da tarefa a partir da propriedade Tag.
            if (item.Tag is TarefasUserControl.TarefaInfo tarefa)
            {
                // Pede confirmação ao usuário.
                if (MessageBox.Show($"Marcar '{tarefa.Titulo}' como concluída?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Atualiza o status da tarefa no banco de dados.
                        using (MySqlConnection conn = Conexao.ObterConexao())
                        {
                            string sql = "UPDATE Tarefas SET status = 'concluida' WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id", tarefa.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // Atualiza a exibição na interface para refletir a mudança imediatamente.
                        tarefa.Status = "Concluída";
                        item.BackColor = Color.LightGreen;

                        // Recarrega a lista inteira para reordenar ou reagrupar se necessário.
                        CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar tarefa: {ex.Message}");
                    }
                }
            }
        }

        // Evento de clique para o item de menu de contexto "Excluir".
        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                var tarefa = item.Tag as TarefaInfo;

                if (tarefa != null && MessageBox.Show($"Confirma exclusão da tarefa '{tarefa.Titulo}'?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Executa o comando DELETE no banco de dados.
                        using (MySqlConnection conn = Conexao.ObterConexao())
                        {
                            string sql = "DELETE FROM Tarefas WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id", tarefa.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // Remove o item da lista visualmente.
                        listViewRotinas.Items.Remove(item);
                        MessageBox.Show("Tarefa excluída com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma tarefa para excluir.");
            }
        }

        // Evento de clique do botão "Editar".
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listViewRotinas.SelectedItems.Count > 0)
            {
                var item = listViewRotinas.SelectedItems[0];
                TarefaInfo tarefa = item.Tag as TarefaInfo;

                if (tarefa != null)
                {
                    // Abre o formulário de edição, passando os dados atuais da tarefa.
                    using (var frm = new EditarRotinaForm(tarefa.Titulo, tarefa.Descricao, tarefa.DataEntrega, tarefa.Prioridade, tarefa.Status))
                    {
                        // Se o usuário confirmar a edição (clicar em Salvar)...
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                // Atualiza os dados do objeto tarefa com os novos valores do formulário.
                                tarefa.Titulo = frm.NovoTitulo;
                                tarefa.Descricao = frm.NovaDescricao;
                                tarefa.DataEntrega = frm.NovaDataEntrega;
                                tarefa.Prioridade = frm.NovaPrioridade;
                                tarefa.Status = frm.NovoStatus ?? "Pendente";

                                // Persiste as alterações no banco de dados.
                                using (MySqlConnection conn = Conexao.ObterConexao())
                                {
                                    string sql = @"UPDATE Tarefas SET titulo = @titulo, descricao = @descricao, data_entrega = @data, prioridade = @prioridade, status = @status WHERE id = @id";

                                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                                    cmd.Parameters.AddWithValue("@id", tarefa.Id);
                                    cmd.Parameters.AddWithValue("@titulo", tarefa.Titulo);
                                    cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);
                                    cmd.Parameters.AddWithValue("@data", tarefa.DataEntrega);
                                    cmd.Parameters.AddWithValue("@prioridade", tarefa.Prioridade);
                                    cmd.Parameters.AddWithValue("@status", tarefa.Status);
                                    cmd.ExecuteNonQuery();
                                }

                                // Atualiza o item no ListView para refletir as alterações sem recarregar tudo.
                                item.SubItems[0].Text = tarefa.Titulo;
                                item.SubItems[1].Text = tarefa.DataEntrega.ToString("dd/MM/yyyy HH:mm");
                                item.SubItems[2].Text = tarefa.Status;
                                item.SubItems[3].Text = tarefa.Prioridade;

                                MessageBox.Show("Tarefa atualizada com sucesso!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao atualizar: {ex.Message}");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma tarefa para editar.");
            }
        }

        // Método para desenhar as células do ListView, permitindo a colorização customizada.
        private void ListViewRotinas_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            int prioridadeColIndex = 3; // Coluna da Prioridade.

            bool isConcluida = false;
            if (e.Item.Tag is TarefasUserControl.TarefaInfo tarefa)
            {
                isConcluida = tarefa.Status != null && (tarefa.Status.Equals("Concluído", StringComparison.OrdinalIgnoreCase) || tarefa.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase));
            }

            if (isConcluida)
            {
                // Pinta a linha inteira de verde claro para tarefas concluídas.
                using (Brush bg = new SolidBrush(Color.LightGreen))
                    e.Graphics.FillRectangle(bg, e.Bounds);

                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, e.Item.Selected ? SystemColors.HighlightText : e.SubItem.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else if (e.ColumnIndex == prioridadeColIndex)
            {
                // Pinta apenas a célula de prioridade com base no seu valor.
                Color corFundo;
                string prioridade = e.SubItem.Text.ToLower();

                if (prioridade.Contains("baixa")) corFundo = Color.FromArgb(200, 255, 255, 200); // Verde claro
                else if (prioridade.Contains("média") || prioridade.Contains("media")) corFundo = Color.FromArgb(255, 255, 220, 180); // Laranja claro
                else if (prioridade.Contains("alta")) corFundo = Color.FromArgb(255, 220, 120, 120); // Vermelho claro
                else corFundo = e.Item.Selected ? SystemColors.Highlight : e.SubItem.BackColor;

                using (Brush bg = new SolidBrush(corFundo))
                    e.Graphics.FillRectangle(bg, e.Bounds);

                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, e.Item.Selected ? SystemColors.HighlightText : e.SubItem.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else
            {
                // Para todas as outras células, usa o desenho padrão.
                e.DrawDefault = true;
            }
        }

        // Método público que permite a atualização do controle de rotinas a partir de fora (ex: do Dashboard).
        public void AtualizarRotinas()
        {
            listViewRotinas.Items.Clear();
            CarregarRotinasDeTarefas(tarefasControl.BuscarTarefasBanco());
        }

        // Eventos vazios gerados pelo designer.
        private void btnAtualizar_Click_1(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void RotinasUserControl_Load(object sender, EventArgs e) { }
    }
}