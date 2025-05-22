using System;
using System.Windows.Forms;

namespace Tcc
{
    public partial class DashboardFrm : Form


    {
        private int usuarioId;
        public DashboardFrm(int idUsuario)
        {   
            InitializeComponent();
            this.usuarioId = idUsuario;

           
        }

        private void DashboardFrm_Load(object sender, EventArgs e)
        {
            
            // Pode carregar painel inicial aqui, se quiser
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
           panelConteudo.Controls.Clear();
           TarefasUserControl tarefasControl = new TarefasUserControl(usuarioId);
           tarefasControl.Dock = DockStyle.Fill;
           panelConteudo.Controls.Add(tarefasControl);
            }

        private void btnRotina_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abroir painel de Rotina");
        }

        private void btnSaude_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir painel de Saúde");
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir painel de Relatórios");
        }

        private void btnIA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Abrir painel de Sugestões IA");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
