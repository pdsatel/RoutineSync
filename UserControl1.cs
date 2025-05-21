using MySql.Data.MySqlClient;
using Tcc;

namespace Tcc;
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
        Controls.Add(new Label() { Text = "Título", Location = new Point(620, 10) });
        txtTitulo = new TextBox() { Location = new Point(620, 30), Width = 250 };
        Controls.Add(txtTitulo);

        // Descrição
        Controls.Add(new Label() { Text = "Descrição", Location = new Point(620, 60) });
        txtDescricao = new TextBox() { Location = new Point(620, 80), Width = 250, Height = 80, Multiline = true };
        Controls.Add(txtDescricao);

        // Data
        Controls.Add(new Label() { Text = "Data de Entrega", Location = new Point(620, 170) });
        dtpDataEntrega = new DateTimePicker() { Location = new Point(620, 190) };
        Controls.Add(dtpDataEntrega);

        // Status
        Controls.Add(new Label() { Text = "Status", Location = new Point(620, 220) });
        cmbStatus = new ComboBox() { Location = new Point(620, 240), Width = 150 };
        cmbStatus.Items.AddRange(new string[] { "Pendente", "Em andamento", "Concluído" });
        cmbStatus.SelectedIndex = 0;
        Controls.Add(cmbStatus);

        // Prioridade
        Controls.Add(new Label() { Text = "Prioridade", Location = new Point(620, 270) });
        cmbPrioridade = new ComboBox() { Location = new Point(620, 290), Width = 150 };
        cmbPrioridade.Items.AddRange(new string[] { "Baixa", "Média", "Alta" });
        cmbPrioridade.SelectedIndex = 1;
        Controls.Add(cmbPrioridade);

        // Botões
        btnSalvar = new Button() { Text = "Salvar", Location = new Point(620, 340), Width = 100 };
        btnSalvar.Click += BtnSalvar_Click;
        Controls.Add(btnSalvar);

        btnExcluir = new Button() { Text = "Excluir", Location = new Point(740, 340), Width = 100 };
        Controls.Add(btnExcluir);
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        // Lógica para salvar no banco e adicionar no ListView
        string titulo = txtTitulo.Text.Trim();
        string descricao = txtDescricao.Text.Trim();
        DateTime dataEntrega = dtpDataEntrega.Value;
        string status = cmbStatus.SelectedItem.ToString();
        string prioridade = cmbPrioridade.SelectedItem.ToString();

        int usuarioID = 1;

        using (MySqlConnection conn = Conexao.ObterConexao())

        {
            try
            {

                string sql = @"INSERT INTO Tarefas (UsuarioId, Titulo, Descricao, DataEntrega, Status, Prioridade)
                               VALUES (@UsuarioId, @Titulo, @Descricao, @DataEntrega, @Status, @Prioridade)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioID);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Descricao", descricao);
                cmd.Parameters.AddWithValue("@DataEntrega", dataEntrega);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Prioridade", prioridade);

                cmd.ExecuteNonQuery();

                ListViewItem item = new ListViewItem(titulo);
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
    }
}