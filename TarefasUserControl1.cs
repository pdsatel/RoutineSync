using System;
using System.Drawing;
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
        private Button btnSalvar;
        private Button btnExcluir;

        public TarefasUserControl()
        {
            InitializeComponent();
            InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {
            // ListView
            listViewTarefas = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(10, 10),
                Size = new Size(600, 400)
            };
            listViewTarefas.Columns.Add("Título", 200);
            listViewTarefas.Columns.Add("Data Entrega", 120);
            listViewTarefas.Columns.Add("Status", 100);
            listViewTarefas.Columns.Add("Prioridade", 100);
            Controls.Add(listViewTarefas);

            // Título
            var lblTitulo = new Label() { Text = "Título", Location = new Point(620, 10), AutoSize = true };
            Controls.Add(lblTitulo);
            txtTitulo = new TextBox() { Location = new Point(620, 30), Width = 250 };
            Controls.Add(txtTitulo);

            // Descrição
            var lblDescricao = new Label() { Text = "Descrição", Location = new Point(620, 60), AutoSize = true };
            Controls.Add(lblDescricao);
            txtDescricao = new TextBox() { Location = new Point(620, 80), Width = 250, Height = 80, Multiline = true };
            Controls.Add(txtDescricao);

            // Data de Entrega
            var lblDataEntrega = new Label() { Text = "Data de Entrega", Location = new Point(620, 170), AutoSize = true };
            Controls.Add(lblDataEntrega);
            dtpDataEntrega = new DateTimePicker() { Location = new Point(620, 190) };
            Controls.Add(dtpDataEntrega);

            // Status
            var lblStatus = new Label() { Text = "Status", Location = new Point(620, 220), AutoSize = true };
            Controls.Add(lblStatus);
            cmbStatus = new ComboBox() { Location = new Point(620, 240), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new string[] { "Pendente", "Em andamento", "Concluído" });
            cmbStatus.SelectedIndex = 0;
            Controls.Add(cmbStatus);

            // Prioridade
            var lblPrioridade = new Label() { Text = "Prioridade", Location = new Point(620, 270), AutoSize = true };
            Controls.Add(lblPrioridade);
            cmbPrioridade = new ComboBox() { Location = new Point(620, 290), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
            cmbPrioridade.SelectedIndex = 1;
            Controls.Add(cmbPrioridade);

            // Botões
            btnSalvar = new Button() { Text = "Salvar", Location = new Point(620, 340), Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnExcluir = new Button() { Text = "Excluir", Location = new Point(740, 340), Width = 100 };
            // Você pode adicionar o evento de exclusão depois
            Controls.Add(btnExcluir);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            DateTime dataEntrega = dtpDataEntrega.Value;
            string status = cmbStatus.SelectedItem.ToString();
            string prioridade = cmbPrioridade.SelectedItem.ToString();

            int usuarioID = 1; // Id fixo para teste, ajuste conforme necessidade

            try
            {
                using (MySqlConnection conn = Conexao.ObterConexao())
                {
                    string sql = @"INSERT INTO Tarefas (usuario_id, titulo, descricao, data_entrega, status, prioridade)
                                   VALUES (@usuarioId, @titulo, @descricao, @data_entrega, @status, @prioridade)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioID);
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@data_entrega", dataEntrega.Date);
                    cmd.Parameters.AddWithValue("@status", status.ToLower());
                    cmd.Parameters.AddWithValue("@prioridade", prioridade);
                    cmd.ExecuteNonQuery();
                    long tarefaId = cmd.LastInsertedId;
                }

                var item = new ListViewItem(titulo);
                item.SubItems.Add(dataEntrega.ToShortDateString());
                item.SubItems.Add(status);
                item.SubItems.Add(prioridade);
                listViewTarefas.Items.Add(item);


                MessageBox.Show("Tarefa salva com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar tarefa: " + ex.Message);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void TarefasUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
