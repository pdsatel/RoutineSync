using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Importa a biblioteca LINQ para manipulação avançada de listas.
using System.Windows.Forms;
using Tcc;

namespace Tcc
{
    // Define um UserControl chamado Notificacao, projetado para exibir uma lista de alertas ou notificações.
    public partial class Notificacao : UserControl
    {
        // Uma lista privada para armazenar os dados de todas as notificações.
        // A classe 'NotificacaoInfo' (não mostrada aqui) provavelmente contém propriedades como Titulo, Mensagem, Data e Lida.
        private List<NotificacaoInfo> notificacoes = new List<NotificacaoInfo>();

        // Construtor do UserControl.
        public Notificacao()
        {
            InitializeComponent(); // Inicializa os componentes visuais desenhados no designer.
        }

        // Método público para adicionar uma nova notificação.
        public void AdicionarNotificacao(string titulo, string mensagem, DateTime data)
        {
            // Cria um novo objeto com as informações da notificação.
            var info = new NotificacaoInfo
            {
                Titulo = titulo,
                Mensagem = mensagem,
                Data = data,
                Lida = false // Novas notificações são marcadas como "não lidas" por padrão.
            };

            notificacoes.Insert(0, info); // Insere a nova notificação no início da lista de dados.
            ExibirNotificacao(info);      // Chama o método para criar a representação visual desta notificação.
        }

        // Método para gerar uma lista de notificações com base em uma lista de tarefas.
        public void GerarNotificacoesDasTarefas(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            flowPanelNotificacoes.Controls.Clear(); // Limpa todas as notificações visuais existentes.
            notificacoes.Clear();                   // Limpa a lista de dados interna.

            DateTime agora = DateTime.Now;
            DateTime limite = agora.AddHours(24); // Define um limite para pegar tarefas que vencem nas próximas 24 horas.

            // Usa LINQ para filtrar e ordenar as tarefas relevantes para notificação.
            var recentes = tarefas
                .Where(t => t.Status != null &&
                             !t.Status.Equals("Concluído", StringComparison.OrdinalIgnoreCase) && // Filtra tarefas que não estão concluídas.
                             t.DataEntrega >= agora &&      // Filtra tarefas cujo prazo ainda não passou.
                             t.DataEntrega <= limite)       // Filtra tarefas que vencem nas próximas 24 horas.
                .OrderByDescending(t => t.DataEntrega)      // Ordena as tarefas da mais recente para a mais antiga (embora a data seja futura).
                .ToList();

            // Itera sobre a lista de tarefas filtradas e cria uma notificação para cada uma.
            foreach (var tarefa in recentes)
            {
                AdicionarNotificacao(
                    tarefa.Titulo,
                    $"Entrega: {tarefa.DataEntrega:g}\n{tarefa.Descricao}", // Formata a mensagem com a data e a descrição.
                    tarefa.DataEntrega
                );
            }
        }

        // Método privado para criar e exibir a representação visual de uma única notificação.
        private void ExibirNotificacao(NotificacaoInfo info)
        {
            // Cria um painel que servirá como o "card" da notificação.
            var painel = new Panel
            {
                Width = flowPanelNotificacoes.ClientSize.Width - 20, // Define a largura para preencher o FlowLayoutPanel com uma margem.
                // A cor de fundo muda se a notificação foi lida ou não.
                BackColor = info.Lida ? Color.LightGray : Color.LightYellow,
                Margin = new Padding(0, 0, 0, 10) // Adiciona uma margem na parte inferior para espaçamento.
            };

            // Cria um Label para o título da notificação.
            var lblTitulo = new Label
            {
                Text = info.Titulo,
                Dock = DockStyle.Top, // Ancorado no topo do painel.
                AutoSize = true,      // Ajusta a altura automaticamente ao conteúdo.
                Font = new Font("Segoe UI", 10, FontStyle.Bold), // Fonte em negrito.
                Padding = new Padding(5)
            };

            // Cria um Label para a mensagem principal.
            var lblMsg = new Label
            {
                Text = info.Mensagem,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(painel.Width - 10, 0), // Define uma largura máxima para que o texto quebre a linha automaticamente.
                Padding = new Padding(5, 0, 5, 5)
            };

            // Cria um Label para a data.
            var lblData = new Label
            {
                Text = info.Data.ToString("g"), // Formata a data para um formato curto de data/hora.
                Dock = DockStyle.Top,
                AutoSize = true,
                ForeColor = Color.Gray, // Cor cinza para dar menos destaque.
                Padding = new Padding(5, 0, 5, 5)
            };

            // Adiciona os labels ao painel. A ordem é importante quando se usa DockStyle.Top.
            // A ordem inversa (Data, Mensagem, Título) garante que o Título fique no topo.
            painel.Controls.Add(lblData);
            painel.Controls.Add(lblMsg);
            painel.Controls.Add(lblTitulo);

            // Ajusta a altura do painel dinamicamente com base na altura somada dos labels.
            painel.Height = lblTitulo.Height + lblMsg.Height + lblData.Height + 15;

            // Adiciona o painel da notificação ao FlowLayoutPanel.
            flowPanelNotificacoes.Controls.Add(painel);
            // Move o painel recém-adicionado para a primeira posição (índice 0) para que a notificação mais nova apareça no topo.
            flowPanelNotificacoes.Controls.SetChildIndex(painel, 0);
        }

        // A classe 'NotificacaoInfo' não está definida aqui, mas seria algo como:
        // public class NotificacaoInfo {
        //     public string Titulo { get; set; }
        //     public string Mensagem { get; set; }
        //     public DateTime Data { get; set; }
        //     public bool Lida { get; set; }
        // }
    }
}