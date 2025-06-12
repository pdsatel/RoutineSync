using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tcc
{
    public partial class TarefasUserControl : UserControl
    {
        private ListView listViewTarefas;
        private TextBox txtTitulo;
        private TextBox txtDescricao;
        private DateTimePicker dtpDataEntrega;
        private ComboBox cmbStatus;
        private ComboBox cmbPrioridade;
      
        public int UsuarioId;
        private ToolTip toolTipDescricao = new ToolTip();
       

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
        public TarefasUserControl(int idUsuario)
        {
            InitializeComponent();
            InicializarComponentesPersonalizados();

            UsuarioId = idUsuario;
        }

        private void InicializarComponentesPersonalizados()
        {
            this.Load += TarefasUserControl_Load;

            // ListView
            listViewTarefas = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                
                Location = new Point(10, 10),
                Size = new Size(800, 850)
            };
            listViewTarefas.Columns.Add("Título", 200);
            listViewTarefas.Columns.Add("Data Entrega", 120);
            listViewTarefas.Columns.Add("Status", 100);
            listViewTarefas.Columns.Add("Prioridade", 100);
            listViewTarefas.Columns.Add("Descrição", 250);
            Controls.Add(listViewTarefas);

            listViewTarefas.MouseMove += ListViewTarefas_MouseMove;
            listViewTarefas.OwnerDraw = true;
            listViewTarefas.DrawColumnHeader += (s, e) => e.DrawDefault = true;
            listViewTarefas.DrawSubItem += ListViewTarefas_DrawSubItem;

            // Posição inicial para os componentes ao lado direito
            int startX = 830;
            int currentY = 10;
            int espacamentoVertical = 30;
            int larguraCampo = 350;

            // Título
            var lblTitulo = new Label()
            {
                Text = "Título",
                Location = new Point(startX, currentY),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(32, 46, 57)
            };
            Controls.Add(lblTitulo);

            currentY += espacamentoVertical;
            txtTitulo = new TextBox()
            {
                Location = new Point(startX, currentY),
                Width = larguraCampo,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(51, 51, 51),
                BackColor = Color.White
            };
            Controls.Add(txtTitulo);

            currentY += espacamentoVertical + 10;

            // Descrição
            var lblDescricao = new Label()
            {
                Text = "Descrição",
                Location = new Point(startX, currentY),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(32, 46, 57)
            };
            Controls.Add(lblDescricao);

            currentY += espacamentoVertical;
            txtDescricao = new TextBox()
            {
                Location = new Point(startX, currentY),
                Width = larguraCampo,
                Height = 140,
                Multiline = true,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(51, 51, 51),
                BackColor = Color.White
            };
            Controls.Add(txtDescricao);

            currentY += txtDescricao.Height + 10;

            // Data de Entrega
            var lblDataEntrega = new Label()
            {
                Text = "Data de Entrega",
                Location = new Point(startX, currentY),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(32, 46, 57)
            };
            Controls.Add(lblDataEntrega);

            currentY += espacamentoVertical;
            dtpDataEntrega = new DateTimePicker()
            {
                Location = new Point(startX, currentY),
                Font = new Font("Segoe UI", 11),
                Width = 200,
                CalendarForeColor = Color.Black,
                CalendarMonthBackground = Color.White,
                CalendarTitleBackColor = Color.FromArgb(32, 46, 57),
                CalendarTitleForeColor = Color.White,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 51, 51)
            };
            Controls.Add(dtpDataEntrega);

            currentY += espacamentoVertical + 10;

            // Status
            var lblStatus = new Label()
            {
                Text = "Status",
                Location = new Point(startX, currentY),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(32, 46, 57)
            };
            Controls.Add(lblStatus);

            currentY += espacamentoVertical;
            cmbStatus = new ComboBox()
            {
                Location = new Point(startX, currentY),
                Width = 230,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 51, 51),
                FlatStyle = FlatStyle.Flat
            };
            cmbStatus.Items.AddRange(new string[] { "Pendente", "Em andamento", "Concluído" });
            cmbStatus.SelectedIndex = 0;
            Controls.Add(cmbStatus);

            currentY += espacamentoVertical + 10;

            // Prioridade
            var lblPrioridade = new Label()
            {
                Text = "Prioridade",
                Location = new Point(startX, currentY),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(32, 46, 57)
            };
            Controls.Add(lblPrioridade);

            currentY += espacamentoVertical;
            cmbPrioridade = new ComboBox()
            {
                Location = new Point(startX, currentY),
                Width = 230,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(51, 51, 51),
                FlatStyle = FlatStyle.Flat
            };
            cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
            cmbPrioridade.SelectedIndex = 1;
            Controls.Add(cmbPrioridade);

            currentY += espacamentoVertical + 20;

            // Botões (todos padronizados)
            btnSalvar = new Button()
            {
                Text = "Salvar",
                Location = new Point(startX, currentY),
                Width = 140,
                Height = 45,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(32, 46, 57),
                FlatStyle = FlatStyle.Flat
            };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnExcluir = new Button()
            {
                Text = "Excluir",
                Location = new Point(startX + 160, currentY),
                Width = 140,
                Height = 45,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(244, 67, 54), // Vermelho para excluir
                FlatStyle = FlatStyle.Flat
            };
            btnExcluir.Click += btnExcluir_Click;
            Controls.Add(btnExcluir);

            currentY += 60;

            btnAtualizar = new Button()
            {
                Text = "Atualizar",
                Location = new Point(startX, currentY),
                Width = 140,
                Height = 45,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(32, 46, 57),
                FlatStyle = FlatStyle.Flat
            };
            btnAtualizar.Click += BtnAtualizar_Click;
            Controls.Add(btnAtualizar);

           
        }
        public void CarregarTarefas()
        {
            listViewTarefas.Items.Clear();

            try
            {
                using (MySqlConnection conn = Conexao.ObterConexao())
                {
                    string sql = "SELECT id, titulo,descricao, data_entrega, status, prioridade FROM Tarefas WHERE usuario_id = @usuarioId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", UsuarioId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long tarefaId = reader.GetInt64("id");
                            string titulo = reader.GetString("titulo");
                            DateTime dataEntrega = reader.GetDateTime("data_entrega");
                            string status = reader.GetString("status");
                            string prioridade = reader.GetString("prioridade");
                            string descricao = reader.GetString("descricao");
                            string resumo = descricao.Length > 50 ? descricao.Substring(0, 50) + "..." : descricao;

                            var item = new ListViewItem(titulo);
                            item.SubItems.Add(dataEntrega.ToShortDateString());
                            item.SubItems.Add(status);
                            item.SubItems.Add(prioridade);
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


                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tarefas: " + ex.Message);
            }
        }

        private void ListViewTarefas_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            int prioridadeColIndex = 3; // 0: Título, 1: Data Entrega, 2: Status, 3: Prioridade, 4: Descrição

            if (e.ColumnIndex == prioridadeColIndex)
            {
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





        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarTarefas();
        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            DateTime dataEntrega = dtpDataEntrega.Value;
            string status = cmbStatus.SelectedItem.ToString();
            string prioridade = cmbPrioridade.SelectedItem.ToString();
            string resumo = descricao.Length > 50 ? descricao.Substring(0, 50) + "..." : descricao;

            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("O Titulo da tarefa não pode estar vazio.");
                return;
            }

            long tarefaId = 0;

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
                    cmd.Parameters.AddWithValue("@data_entrega", dataEntrega.Date);
                    cmd.Parameters.AddWithValue("@status", status.ToLower());
                    cmd.Parameters.AddWithValue("@prioridade", prioridade);
                    cmd.ExecuteNonQuery();

                  
                   

                    tarefaId = cmd.LastInsertedId;
                    var item = new ListViewItem(titulo);
                    item.SubItems.Add(dataEntrega.ToShortDateString());
                    item.SubItems.Add(status);
                    item.SubItems.Add(prioridade);
                    item.SubItems.Add(resumo);
                    item.Tag = new TarefaInfo { Id = tarefaId, Descricao = descricao };

                    listViewTarefas.Items.Add(item);
                }
                txtTitulo.Clear();
                txtDescricao.Clear();
                dtpDataEntrega.Value = DateTime.Now;
                cmbStatus.SelectedIndex = 0;
                cmbPrioridade.SelectedIndex = 1;

                MessageBox.Show("Tarefa salva com sucesso!");



               

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar tarefa: " + ex.Message);
            }


        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (listViewTarefas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione uma tarefa para excluir.");
                return;
            }
            var itemSelecionado = listViewTarefas.SelectedItems[0];
            TarefaInfo info = itemSelecionado.Tag as TarefaInfo;
            long tarefaId = info.Id;

            var resultado = MessageBox.Show("Tem certeza que deseja excluir esta tarefa?", "Confirmação", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = Conexao.ObterConexao())
                    {
                        string sql = "DELETE FROM Tarefas WHERE id = @tarefaId";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@tarefaId", tarefaId);
                       
                        int linhasAfetadas = cmd.ExecuteNonQuery();


                        if (linhasAfetadas == 0)
                        {
                            
                            MessageBox.Show("Nenhuma tarefa encontrada com o ID especificado.");
                            return;
                        }
                        else
                        {
                            listViewTarefas.Items.Remove(itemSelecionado);
                            MessageBox.Show("Tarefa excluída com sucesso!");
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir tarefa: " + ex.Message);
                }
            }

        }
        private void ListViewTarefas_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewTarefas.HitTest(e.Location);

            if (info.Item != null)
            {
                TarefaInfo tarefaInfo = info.Item.Tag as TarefaInfo;
                if (tarefaInfo != null && !string.IsNullOrEmpty(tarefaInfo.Descricao))
                {
                    toolTipDescricao.SetToolTip(listViewTarefas, tarefaInfo.Descricao);
                }
                else
                {
                    toolTipDescricao.SetToolTip(listViewTarefas, null);
                }
            }
            else
            {
                toolTipDescricao.SetToolTip(listViewTarefas, null);
            }
        }
        private void CentralizarPainel(Control painel)
        {
            painel.Left = (this.ClientSize.Width - painel.Width) / 2;
            painel.Top = (this.ClientSize.Height - painel.Height) / 2;
        }
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
        private void TarefasUserControl_Load(object sender, EventArgs e)


        {
            this.SizeChanged += TarefasUserControl_SizeChanged;

            CarregarTarefas();

            // Centraliza o próprio UserControl
            CentralizarPainel(this);

            // Define cor de fundo geral
            this.BackColor = ColorTranslator.FromHtml("#FFFCF6");

            // Aplica fonte e cor aos controles existentes
            // Estilo para os controles TextBox, ComboBox, DateTimePicker, ListView
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.ForeColor = ColorTranslator.FromHtml("#333333");
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    
                }

                if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = ColorTranslator.FromHtml("#333333");
                    cmb.FlatStyle = FlatStyle.Flat;
                }

                if (ctrl is DateTimePicker dtp)
                {
                    dtp.CalendarForeColor = Color.Black;
                    dtp.CalendarMonthBackground = Color.White;
                    dtp.CalendarTitleBackColor = ColorTranslator.FromHtml("#202E39");
                    dtp.CalendarTitleForeColor = Color.White;
                    dtp.BackColor = Color.White;
                    dtp.ForeColor = ColorTranslator.FromHtml("#333333");
                }

                if (ctrl is ListView lv)
                {
                    lv.BackColor = Color.White;
                    lv.ForeColor = ColorTranslator.FromHtml("#333333");
                    lv.Font = new Font("Segoe UI", 10);
                    lv.FullRowSelect = true;
                }
            }
            ArredondarBotao(btnSalvar, 10);
            ArredondarBotao(btnExcluir, 10);    
            ArredondarControle(txtTitulo, 10);
            ArredondarControle(txtDescricao, 10);   
            ArredondarControle(dtpDataEntrega, 10); 
            ArredondarControle(cmbStatus, 10);
            ArredondarControle(cmbPrioridade, 10);  
            ArredondarControle(listViewTarefas, 10);
            ArredondarBotao(btnAtualizar, 10);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void TarefasUserControl_SizeChanged(object sender, EventArgs e)
        {
            

        }
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
            }
            return tarefas;
        }

    }
}

