using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Forms;

namespace Tcc
{
    public partial class DashboardFrm : Form
    {
        private int usuarioId;
        private RotinasUserControl rotinasControl;
        private TarefasUserControl tarefasControl;
        private RelatorioUserControl relatorioControl;
        private Notificacao notificacaoControl;

        public DashboardFrm(int idUsuario)
        {
            InitializeComponent();
            this.usuarioId = idUsuario;
            this.Shown += DashboardFrm_Shown;

            tarefasControl = new TarefasUserControl(usuarioId);
            tarefasControl.CarregarTarefas();
            tarefasControl.Dock = DockStyle.Fill;

            rotinasControl = new RotinasUserControl(tarefasControl);
            rotinasControl.Dock = DockStyle.Fill;

            notificacaoControl = new Notificacao();
            notificacaoControl.Dock = DockStyle.Fill;
        }

        private void DashboardFrm_Load(object sender, EventArgs e)
        {
            // ÍCONES DOS BOTÕES DO MENU

            btnTarefas.Image = Properties.Resources.Tarefas_png;
            btnTarefas.ImageAlign = ContentAlignment.MiddleLeft;
            btnTarefas.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRotina.Image = Properties.Resources.Calendario_png;
            btnRotina.ImageAlign = ContentAlignment.MiddleLeft;
            btnRotina.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRelatorios.Image = Properties.Resources.Relatorio_png;
            btnRelatorios.ImageAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnNotificacao.Image = Properties.Resources.Notificacao_png;
            btnNotificacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnNotificacao.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnSair.Image = Properties.Resources.Sair_png;
            btnSair.ImageAlign = ContentAlignment.MiddleLeft;
            btnSair.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private void DashboardFrm_Shown(object sender, EventArgs e)
        {
            var tarefas = tarefasControl.ObterTarefasVisiveis();

            var tarefasProximas = tarefas
                .OrderBy(t => t.DataEntrega)
                .Select(t => $"{t.Titulo} - para {t.DataEntrega:dd/MM HH:mm}")
                .ToList();

            // Mostra uma notificação por vez
            foreach (var tarefa in tarefasProximas)
            {
                var popup = new NotificacoesPopupForm(tarefa);
                popup.StartPosition = FormStartPosition.Manual;
                popup.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - popup.Width - 20, 40);
                popup.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(2500);
            }
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        { 
           
            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(tarefasControl);
            tarefasControl.Dock = DockStyle.Fill;

            tarefasControl.CarregarTarefas();
        }

        private void btnRotina_Click(object sender, EventArgs e)
        {
            var tarefas = tarefasControl.BuscarTarefasBanco();
            rotinasControl.CarregarRotinasDeTarefas(tarefas);

            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(rotinasControl);
            rotinasControl.Dock = DockStyle.Fill;
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            if (relatorioControl == null)
                relatorioControl = new RelatorioUserControl(usuarioId);

            relatorioControl.AtualizarRelatorioDoBanco(usuarioId);

            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(relatorioControl);
            relatorioControl.Dock = DockStyle.Fill;
        }

        private void btnNotificacao_Click(object sender, EventArgs e)
        {
            var tarefas = tarefasControl.BuscarTarefasBanco();
            notificacaoControl.GerarNotificacoesDasTarefas(tarefas);

            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(notificacaoControl);
            notificacaoControl.Dock = DockStyle.Fill;
            notificacaoControl.Visible = true;
            notificacaoControl.BringToFront();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sempre recarrega as rotinas ao entrar na aba
        }
    }
}