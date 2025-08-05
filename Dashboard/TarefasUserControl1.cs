using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tcc
{
    // Define um UserControl para gerenciar tarefas. Este controle encapsula toda a lógica e a interface
    // para listar, adicionar e excluir tarefas de um usuário específico.
    public partial class TarefasUserControl : UserControl
    {
        // Campos privados para os componentes da interface que serão criados programaticamente.
        private ListView listViewTarefas;
        private TextBox txtTitulo;
        private TextBox txtDescricao;
        private DateTimePicker dtpDataEntrega;
        private ComboBox cmbStatus;
        private ComboBox cmbPrioridade;

        // ID do usuário logado, essencial para filtrar as tarefas.
        public int UsuarioId;
        // Tooltip para exibir a descrição completa da tarefa ao passar o mouse.
        private ToolTip toolTipDescricao = new ToolTip();


        // Classe aninhada para modelar os dados de uma tarefa.
        // Funciona como um DTO (Data Transfer Object) para transportar informações da tarefa.
        public class TarefaInfo
        {
            public long Id { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public DateTime DataEntrega { get; set; }
            public string Status { get; set; }
            public string Prioridade { get; set; }
            public int UsuarioId { get; set; }

        }
        // Construtor do UserControl. Recebe o ID do usuário para associar as tarefas.
        public TarefasUserControl(int idUsuario)
        {
            InitializeComponent(); // Método padrão para inicializar componentes do designer.
            InicializarComponentesPersonalizados(); // Chama o método para criar a UI dinamicamente.

            UsuarioId = idUsuario; // Armazena o ID do usuário.
        }

        // Método central para criar e configurar todos os componentes da interface dinamicamente via código.
        private void InicializarComponentesPersonalizados()
        {
            this.Load += TarefasUserControl_Load; // Associa o evento Load do controle.

            // Configuração do ListView para exibir as tarefas.
            listViewTarefas = new ListView
            {
                View = View.Details, // Define a exibição em colunas.
                FullRowSelect = true, // Permite selecionar a linha inteira.
                GridLines = true, // Exibe linhas de grade.
                Location = new Point(10, 10),
                Size = new Size(800, 850)
            };
            // Adiciona as colunas ao ListView.
            listViewTarefas.Columns.Add("Título", 200);
            listViewTarefas.Columns.Add("Data Entrega", 150);
            listViewTarefas.Columns.Add("Status", 110);
            listViewTarefas.Columns.Add("Prioridade", 110);
            listViewTarefas.Columns.Add("Descrição", 250);
            Controls.Add(listViewTarefas); // Adiciona o ListView ao UserControl.

            // Eventos para funcionalidades personalizadas do ListView.
            listViewTarefas.MouseMove += ListViewTarefas_MouseMove; // Para exibir o tooltip.
            listViewTarefas.OwnerDraw = true; // Habilita o desenho personalizado dos itens.
            listViewTarefas.DrawColumnHeader += (s, e) => e.DrawDefault = true; // Mantém o desenho padrão do cabeçalho.
            listViewTarefas.DrawSubItem += ListViewTarefas_DrawSubItem; // Evento para desenhar cada célula (subitem).

            // Variáveis para posicionar os controles do formulário à direita.
            int startX = 830;
            int currentY = 10;
            int espacamentoVertical = 30;
            int larguraCampo = 350;

            // Criação dinâmica do formulário de adição/edição.
            // Título
            var lblTitulo = new Label() { Text = "Título", Location = new Point(startX, currentY), AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(32, 46, 57) };
            Controls.Add(lblTitulo);
            currentY += espacamentoVertical;
            txtTitulo = new TextBox() { Location = new Point(startX, currentY), Width = larguraCampo, Font = new Font("Segoe UI", 11), ForeColor = Color.FromArgb(51, 51, 51), BackColor = Color.White };
            Controls.Add(txtTitulo);
            currentY += espacamentoVertical + 10;

            // Descrição
            var lblDescricao = new Label() { Text = "Descrição", Location = new Point(startX, currentY), AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(32, 46, 57) };
            Controls.Add(lblDescricao);
            currentY += espacamentoVertical;
            txtDescricao = new TextBox() { Location = new Point(startX, currentY), Width = larguraCampo, Height = 140, Multiline = true, Font = new Font("Segoe UI", 11), ForeColor = Color.FromArgb(51, 51, 51), BackColor = Color.White };
            Controls.Add(txtDescricao);
            currentY += txtDescricao.Height + 10;

            // Data de Entrega
            var lblDataEntrega = new Label() { Text = "Data de Entrega", Location = new Point(startX, currentY), AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(32, 46, 57) };
            Controls.Add(lblDataEntrega);
            currentY += espacamentoVertical;

            // DateTimePicker principal para selecionar data e hora.
            dtpDataEntrega = new DateTimePicker()
            {
                Location = new Point(startX, currentY),
                Font = new Font("Segoe UI", 11),
                Width = 200,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm", // Formato personalizado.
                ShowUpDown = true, // Mostra botões de incremento/decremento.
                // Estilos visuais.
                CalendarForeColor = Color.Black,
                CalendarMonthBackground = Color.White,
                CalendarTitleBackColor = Color.FromArgb(32, 46, 57),
                CalendarTitleForeColor = Color.White,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 51, 51)
            };
            Controls.Add(dtpDataEntrega);

            // Interações visuais para o DateTimePicker (foco/saída).
            dtpDataEntrega.Enter += (s, e) => { dtpDataEntrega.BackColor = Color.LightBlue; dtpDataEntrega.Font = new Font("Segoe UI", 11, FontStyle.Bold); };
            dtpDataEntrega.Leave += (s, e) => { dtpDataEntrega.BackColor = Color.White; dtpDataEntrega.Font = new Font("Segoe UI", 11, FontStyle.Regular); };

            // Tooltip para guiar o usuário.
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(dtpDataEntrega, "Escolha data e horário da entrega (formato: dd/MM/yyyy HH:mm)");

            // Botão com ícone de calendário.
            Button btnAbrirCalendario = new Button() { Location = new Point(startX + dtpDataEntrega.Width + 10, currentY), Size = new Size(32, 32), BackColor = Color.Transparent, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, };
            btnAbrirCalendario.FlatAppearance.BorderSize = 0;
            btnAbrirCalendario.Click += (s, e) => dtpDataEntrega.Focus();
            Controls.Add(btnAbrirCalendario);
            currentY += espacamentoVertical + 10;

            // Status
            var lblStatus = new Label() { Text = "Status", Location = new Point(startX, currentY), AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(32, 46, 57) };
            Controls.Add(lblStatus);
            currentY += espacamentoVertical;
            cmbStatus = new ComboBox() { Location = new Point(startX, currentY), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 11), BackColor = Color.White, ForeColor = Color.FromArgb(51, 51, 51), FlatStyle = FlatStyle.Flat };
            cmbStatus.Items.AddRange(new string[] { "Pendente", "Em andamento", "Concluído" });
            cmbStatus.SelectedIndex = 0;
            Controls.Add(cmbStatus);
            currentY += espacamentoVertical + 10;

            // Prioridade
            var lblPrioridade = new Label() { Text = "Prioridade", Location = new Point(startX, currentY), AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(32, 46, 57) };
            Controls.Add(lblPrioridade);
            currentY += espacamentoVertical;
            cmbPrioridade = new ComboBox() { Location = new Point(startX, currentY), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 11), BackColor = Color.White, ForeColor = Color.FromArgb(51, 51, 51), FlatStyle = FlatStyle.Flat };
            cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
            cmbPrioridade.SelectedIndex = 1;
            Controls.Add(cmbPrioridade);
            currentY += espacamentoVertical + 20;

            // Botões de Ação
            btnSalvar = new Button() { Text = "Salvar", Location = new Point(startX, currentY), Width = 140, Height = 45, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.White, BackColor = Color.FromArgb(32, 46, 57), FlatStyle = FlatStyle.Flat };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);
            btnExcluir = new Button() { Text = "Excluir", Location = new Point(startX + 160, currentY), Width = 140, Height = 45, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.White, BackColor = Color.FromArgb(244, 67, 54), FlatStyle = FlatStyle.Flat };
            btnExcluir.Click += btnExcluir_Click;
            Controls.Add(btnExcluir);
            currentY += 60;
        }

        // Carrega as tarefas do banco de dados e as exibe no ListView.
        public void CarregarTarefas()
        {
            listViewTarefas.Items.Clear(); // Limpa a lista antes de carregar.

            try
            {
                using (MySqlConnection conn = Conexao.ObterConexao())
                {
                    string sql = "SELECT id, titulo, descricao, data_entrega, status, prioridade FROM Tarefas WHERE usuario_id = @usuarioId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", UsuarioId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Extrai os dados do leitor.
                            long tarefaId = reader.GetInt64("id");
                            string titulo = reader.GetString("titulo");
                            DateTime dataEntrega = reader.GetDateTime("data_entrega");
                            string status = reader.GetString("status");
                            string prioridade = reader.GetString("prioridade");
                            string descricao = reader.GetString("descricao");

                            // Cria um item para o ListView.
                            var item = new ListViewItem(titulo);
                            item.SubItems.Add(dataEntrega.ToString("dd/MM/yyyy HH:mm"));
                            item.SubItems.Add(status);
                            item.SubItems.Add(prioridade);
                            string resumo = descricao.Length > 50 ? descricao.Substring(0, 50) + "..." : descricao;
                            item.SubItems.Add(resumo); // Adiciona a descrição completa na coluna.

                            // Armazena o objeto de dados completo na propriedade Tag do item.
                            // Isso facilita o acesso a todos os dados da tarefa posteriormente.
                            item.Tag = new TarefaInfo
                            {
                                Id = tarefaId,
                                Titulo = titulo,
                                Descricao = descricao,
                                DataEntrega = dataEntrega,
                                Status = status,
                                Prioridade = prioridade,
                                UsuarioId = UsuarioId
                            };
                            listViewTarefas.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tarefas: " + ex.Message);
            }
        }

        // Evento para desenhar as células do ListView, permitindo a colorização customizada.
        private void ListViewTarefas_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            bool isConcluida = false;
            // Pega o objeto TarefaInfo da propriedade Tag do item.
            if (e.Item.Tag is TarefaInfo tarefa)
            {
                isConcluida = tarefa.Status != null && tarefa.Status.Equals("Concluído", StringComparison.OrdinalIgnoreCase);
            }

            int prioridadeColIndex = 3; // Índice da coluna de prioridade.

            if (isConcluida)
            {
                // Pinta o fundo da linha inteira de verde claro se a tarefa estiver concluída.
                using (Brush bg = new SolidBrush(Color.LightGreen))
                    e.Graphics.FillRectangle(bg, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, e.SubItem.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else if (e.ColumnIndex == prioridadeColIndex)
            {
                // Pinta o fundo apenas da célula de prioridade com base no seu valor.
                Color corFundo;
                string prioridade = e.SubItem.Text.ToLower();

                if (prioridade.Contains("baixa")) corFundo = Color.FromArgb(200, 255, 255, 200); // Verde claro
                else if (prioridade.Contains("média")) corFundo = Color.FromArgb(255, 255, 220, 180); // Laranja claro
                else if (prioridade.Contains("alta")) corFundo = Color.FromArgb(255, 220, 120, 120); // Vermelho claro
                else corFundo = e.Item.Selected ? SystemColors.Highlight : e.SubItem.BackColor;

                using (Brush bg = new SolidBrush(corFundo))
                    e.Graphics.FillRectangle(bg, e.Bounds);

                Color textColor = e.Item.Selected ? SystemColors.HighlightText : e.SubItem.ForeColor;
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, textColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else
            {
                // Para todas as outras células, usa o desenho padrão.
                e.DrawDefault = true;
            }
        }

        // Evento de clique do botão "Salvar" para adicionar uma nova tarefa.
        // No ficheiro: TarefasUserControl1.cs
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            DateTime dataEntrega = dtpDataEntrega.Value;
            string status = cmbStatus.SelectedItem.ToString();
            string prioridade = cmbPrioridade.SelectedItem.ToString();

            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("O Titulo da tarefa não pode estar vazio.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Conexao.ObterConexao())
                {
                    string sql = @"INSERT INTO Tarefas (usuario_id, titulo, descricao, data_entrega, status, prioridade)
                           VALUES (@usuarioId, @titulo, @descricao, @data_entrega, @status, @prioridade)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", UsuarioId);
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@data_entrega", dataEntrega);
                    // --- CORREÇÃO AQUI: Removido o .ToLower() para guardar o valor exato ("Concluída") ---
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@prioridade", prioridade);
                    cmd.ExecuteNonQuery();
                }

                // Limpa os campos
                txtTitulo.Clear();
                txtDescricao.Clear();
                dtpDataEntrega.Value = DateTime.Now;
                cmbStatus.SelectedIndex = 0;
                cmbPrioridade.SelectedIndex = 1;

                MessageBox.Show("Tarefa salva com sucesso!");

                // Recarrega a lista para mostrar a nova tarefa
                CarregarTarefas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar tarefa: " + ex.Message);
            }
        }

        // Evento de clique para o botão "Excluir".
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se uma tarefa está selecionada no ListView.
            if (listViewTarefas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione uma tarefa para excluir.");
                return;
            }

            // Obtém o item selecionado e seu objeto de dados da propriedade Tag.
            var itemSelecionado = listViewTarefas.SelectedItems[0];
            TarefaInfo info = itemSelecionado.Tag as TarefaInfo;
            long tarefaId = info.Id;

            // Exibe uma caixa de diálogo de confirmação.
            var resultado = MessageBox.Show("Tem certeza que deseja excluir esta tarefa?", "Confirmação", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = Conexao.ObterConexao())
                    {
                        // Query SQL para excluir a tarefa pelo seu ID.
                        string sql = "DELETE FROM Tarefas WHERE id = @tarefaId";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@tarefaId", tarefaId);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            // Remove o item do ListView se a exclusão no banco de dados for bem-sucedida.
                            listViewTarefas.Items.Remove(itemSelecionado);
                            MessageBox.Show("Tarefa excluída com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma tarefa encontrada com o ID especificado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir tarefa: " + ex.Message);
                }
            }
        }

        // Evento que ocorre quando o mouse se move sobre o ListView.
        private void ListViewTarefas_MouseMove(object sender, MouseEventArgs e)
        {
            // Realiza um "teste de clique" para encontrar o item sob o cursor.
            ListViewHitTestInfo info = listViewTarefas.HitTest(e.Location);

            // Se o cursor estiver sobre um item...
            if (info.Item != null)
            {
                // ...pega os dados da tarefa da propriedade Tag.
                TarefaInfo tarefaInfo = info.Item.Tag as TarefaInfo;
                if (tarefaInfo != null && !string.IsNullOrEmpty(tarefaInfo.Descricao))
                {
                    // Exibe a descrição completa da tarefa em um tooltip.
                    toolTipDescricao.SetToolTip(listViewTarefas, tarefaInfo.Descricao);
                }
                else
                {
                    // Limpa o tooltip se não houver descrição.
                    toolTipDescricao.SetToolTip(listViewTarefas, null);
                }
            }
            else
            {
                // Limpa o tooltip se o mouse não estiver sobre nenhum item.
                toolTipDescricao.SetToolTip(listViewTarefas, null);
            }
        }

        // Método utilitário para centralizar um controle.
        private void CentralizarPainel(Control painel)
        {
            painel.Left = (this.ClientSize.Width - painel.Width) / 2;
            painel.Top = (this.ClientSize.Height - painel.Height) / 2;
        }

        // Método utilitário para criar cantos arredondados em um botão.
        private void ArredondarBotao(Button btn, int raio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(btn.Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(btn.Width - raio, btn.Height - raio, raio, raio, 0, 90);
            path.AddArc(0, btn.Height - raio, raio, raio, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }

        // Método utilitário para criar cantos arredondados em qualquer controle.
        private void ArredondarControle(Control controle, int raio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, raio, raio), 180, 90);
            path.AddArc(new Rectangle(controle.Width - raio, 0, raio, raio), 270, 90);
            path.AddArc(new Rectangle(controle.Width - raio, controle.Height - raio, raio, raio), 0, 90);
            path.AddArc(new Rectangle(0, controle.Height - raio, raio, raio), 90, 90);
            path.CloseFigure();
            controle.Region = new Region(path);
        }

        // Evento que ocorre quando o controle é carregado.
        private void TarefasUserControl_Load(object sender, EventArgs e)
        {
            // Carrega as tarefas do banco de dados na inicialização.
            CarregarTarefas();

            // Define a cor de fundo do controle.
            this.BackColor = ColorTranslator.FromHtml("#FFFCF6");

            // Aplica o arredondamento aos controles do formulário.
            ArredondarBotao(btnSalvar, 10);
            ArredondarBotao(btnExcluir, 10);
            ArredondarControle(txtTitulo, 10);
            ArredondarControle(txtDescricao, 10);
            ArredondarControle(dtpDataEntrega, 10);
            ArredondarControle(cmbStatus, 10);
            ArredondarControle(cmbPrioridade, 10);
            ArredondarControle(listViewTarefas, 10);
        }

        // Evento gerado pelo designer, sem implementação.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Evento gerado pelo designer, sem implementação.
        private void TarefasUserControl_SizeChanged(object sender, EventArgs e)
        {
        }

        // Obtém a lista de tarefas diretamente dos itens visíveis no ListView.
        public List<TarefaInfo> ObterTarefas(int usuarioId)
        {
            var tarefas = new List<TarefaInfo>();
            foreach (ListViewItem item in listViewTarefas.Items)
            {
                if (item.Tag is TarefaInfo info && info.UsuarioId == usuarioId)
                {
                    tarefas.Add(info);
                }
            }
            return tarefas;
        }

        // Busca uma lista de tarefas atualizada diretamente do banco de dados.
        public List<TarefaInfo> BuscarTarefasBanco()
        {
            var tarefas = new List<TarefaInfo>();
            using (MySqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM Tarefas WHERE usuario_id = @usuarioId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@usuarioId", this.UsuarioId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarefas.Add(new TarefaInfo
                        {
                            Id = reader.GetInt64("id"),
                            Titulo = reader.GetString("titulo"),
                            Descricao = reader.GetString("descricao"),
                            Status = reader.GetString("status"),
                            Prioridade = reader.GetString("prioridade"),
                            DataEntrega = reader.GetDateTime("data_entrega")
                        });
                    }
                }
                conn.Close();
            }
            return tarefas;
        }

        // Retorna a lista de todas as tarefas atualmente visíveis no ListView.
        public List<TarefaInfo> ObterTarefasVisiveis()
        {
            var tarefas = new List<TarefaInfo>();
            foreach (ListViewItem item in listViewTarefas.Items)
            {
                if (item.Tag is TarefaInfo info)
                    tarefas.Add(info);
            }
            return tarefas;
        }

    }
}