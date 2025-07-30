// Importa as bibliotecas necessárias.
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Forms;
using Tcc.Dashboard; // Importa os UserControls da pasta Dashboard.

namespace Tcc
{
    // Define a classe para o formulário do Dashboard, que serve como a tela principal após o login.
    public partial class DashboardFrm : Form
    {
        // Campos privados para armazenar o ID do usuário logado e as instâncias dos UserControls.
        // UserControls são componentes reutilizáveis que representam diferentes seções do dashboard.
        private int usuarioId;
        private RotinasUserControl rotinasControl;       // Controle para gerenciar rotinas.
        private TarefasUserControl tarefasControl;       // Controle para gerenciar tarefas.
        private RelatorioUserControl relatorioControl;   // Controle para exibir relatórios.
        private Notificacao notificacaoControl;       // Controle para notificações (embora pareça não ser usado no painel principal).
        private PerfilUserControl perfilControl;         // Controle para exibir e editar o perfil do usuário.

        // Construtor do Dashboard. Recebe o ID do usuário que fez o login.
        public DashboardFrm(int idUsuario)
        {
            InitializeComponent(); // Inicializa os componentes do formulário desenhados na interface gráfica.
            this.usuarioId = idUsuario; // Armazena o ID do usuário para uso em todo o formulário.
            this.Shown += DashboardFrm_Shown; // Associa um evento para ser executado quando o formulário é totalmente exibido.

            // Instancia os UserControls, passando o ID do usuário quando necessário para carregar dados específicos.
            // Isso pré-carrega os controles, tornando a troca entre eles mais rápida.
            tarefasControl = new TarefasUserControl(usuarioId);
            tarefasControl.CarregarTarefas(); // Carrega as tarefas do usuário imediatamente.
            tarefasControl.Dock = DockStyle.Fill; // Faz o controle ocupar todo o espaço do painel onde será inserido.

            // O controle de rotinas recebe uma referência ao controle de tarefas, permitindo a comunicação entre eles.
            rotinasControl = new RotinasUserControl(tarefasControl);
            rotinasControl.Dock = DockStyle.Fill;

            notificacaoControl = new Notificacao();
            notificacaoControl.Dock = DockStyle.Fill;

            perfilControl = new PerfilUserControl(usuarioId);
        }

        // Evento que ocorre ao carregar o formulário (antes de ser exibido).
        private void DashboardFrm_Load(object sender, EventArgs e)
        {
            // CONFIGURAÇÃO DOS ÍCONES DOS BOTÕES DO MENU LATERAL
            // Para cada botão, a imagem é carregada dos Recursos (Properties.Resources),
            // alinhada à esquerda do texto.

            btnTarefas.Image = Properties.Resources.Tarefas_png;
            btnTarefas.ImageAlign = ContentAlignment.MiddleLeft;
            btnTarefas.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRotina.Image = Properties.Resources.gerenciar;
            btnRotina.ImageAlign = ContentAlignment.MiddleLeft;
            btnRotina.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnRelatorios.Image = Properties.Resources.Relatorio_png;
            btnRelatorios.ImageAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnPerfil.Image = Properties.Resources.perfil_png;
            btnPerfil.ImageAlign = ContentAlignment.MiddleLeft;
            btnPerfil.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnSair.Image = Properties.Resources.Sair_png;
            btnSair.ImageAlign = ContentAlignment.MiddleLeft;
            btnSair.TextImageRelation = TextImageRelation.ImageBeforeText;

            // Carrega o UserControl do perfil como a tela inicial padrão do dashboard.
            CarregarUserControl(perfilControl);
        }

        // Evento que ocorre na primeira vez que o formulário é exibido.
        private void DashboardFrm_Shown(object sender, EventArgs e)
        {
            // Lógica para exibir notificações "toast" para tarefas próximas.
            var tarefas = tarefasControl.ObterTarefasVisiveis();

            // Seleciona e formata as tarefas, ordenando-as pela data de entrega mais próxima.
            var tarefasProximas = tarefas
                .OrderBy(t => t.DataEntrega)
                .Select(t => $"{t.Titulo} - para {t.DataEntrega:dd/MM HH:mm}")
                .ToList();

            // Itera sobre a lista de tarefas próximas e exibe um pop-up para cada uma.
            foreach (var tarefa in tarefasProximas)
            {
                var popup = new NotificacoesPopupForm(tarefa);
                popup.StartPosition = FormStartPosition.Manual; // Posição manual.
                // Posiciona o pop-up no canto inferior direito da área de trabalho.
                popup.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - popup.Width - 20, 40);
                popup.Show(); // Exibe o pop-up.
                Application.DoEvents(); // Processa eventos da interface para que ela não congele.
                System.Threading.Thread.Sleep(2500); // Pausa por 2.5 segundos antes de mostrar a próxima notificação.
            }
        }

        // Método auxiliar para carregar um UserControl no painel de conteúdo principal.
        private void CarregarUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill; // Garante que o controle preencha o painel.
            panelConteudo.Controls.Clear();    // Limpa o painel de qualquer controle anterior.
            panelConteudo.Controls.Add(userControl); // Adiciona o novo controle ao painel.
        }

        // Evento de clique do botão "Tarefas".
        private void btnTarefas_Click(object sender, EventArgs e)
        {
            tarefasControl.CarregarTarefas(); // Recarrega os dados das tarefas para garantir que estejam atualizados.
            CarregarUserControl(tarefasControl); // Exibe o controle de tarefas.
        }

        // Evento de clique do botão "Perfil".
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            // Não precisa recarregar dados aqui, a menos que haja uma ação específica.
            CarregarUserControl(perfilControl); // Exibe o controle do perfil.
        }

        // Evento de clique do botão "Rotina".
        private void btnRotina_Click(object sender, EventArgs e)
        {
            rotinasControl.AtualizarRotinas(); // Recarrega os dados das rotinas.
            CarregarUserControl(rotinasControl); // Exibe o controle de rotinas.
        }

        // Evento de clique do botão "Relatórios".
        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            // "Lazy loading": O controle de relatório só é criado na primeira vez que é acessado.
            if (relatorioControl == null)
                relatorioControl = new RelatorioUserControl(usuarioId);

            relatorioControl.AtualizarRelatorioDoBanco(usuarioId); // Atualiza os dados do relatório.
            CarregarUserControl(relatorioControl); // Exibe o controle de relatórios.
        }

        // Evento de clique do botão "Sair".
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário do dashboard, o que geralmente encerra a sessão ou a aplicação.
        }

        // Evento de pintura do painel de conteúdo (gerado pelo designer, sem implementação aqui).
        private void panelConteudo_Paint(object sender, PaintEventArgs e)
        {
            // Nenhuma ação necessária.
        }

        // Evento de mudança de aba (gerado pelo designer, sem implementação aqui).
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica pode ser adicionada aqui se um TabControl for usado no futuro.
        }
    }
}