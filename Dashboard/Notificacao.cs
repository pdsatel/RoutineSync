using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tcc;

namespace Tcc
{
    public partial class Notificacao : UserControl
    {
        private List<NotificacaoInfo> notificacoes = new List<NotificacaoInfo>();

        public Notificacao()
        {
            InitializeComponent();

            AdicionarNotificacao("Teste", "Mensagem de teste", DateTime.Now);
        }

        // Método para adicionar notificação na lista e exibir
        public void AdicionarNotificacao(string titulo, string mensagem, DateTime data)
        {
            var info = new NotificacaoInfo
            {
                Titulo = titulo,
                Mensagem = mensagem,
                Data = data,
                Lida = false
            };

            notificacoes.Insert(0, info);
            ExibirNotificacao(info);
        }

        public void GerarNotificacoesDasTarefas(List<TarefasUserControl.TarefaInfo> tarefas)
        {
            flowPanelNotificacoes.Controls.Clear();
            int count = 0;

            foreach (var tarefa in tarefas)
            {
                // Filtro ajustado (notifica tudo exceto "Concluído")
                if (tarefa.Status != null && !tarefa.Status.Equals("Concluído", StringComparison.OrdinalIgnoreCase))
                {
                    AdicionarNotificacao(
                        tarefa.Titulo,
                        $"Entrega: {tarefa.DataEntrega:g}\n{tarefa.Descricao}",
                        tarefa.DataEntrega
                    );
                    count++;
                }
            }
            MessageBox.Show($"Notificações criadas: {count}");
        }

        // Exibe uma notificação visualmente (simples, pode melhorar depois)
        private void ExibirNotificacao(NotificacaoInfo info)
        {
            var painel = new Panel
            {
                Width = flowPanelNotificacoes.ClientSize.Width - 20,
                BackColor = info.Lida ? Color.LightGray : Color.LightYellow,
                Margin = new Padding(0, 0, 0, 10)
            };

            var lblTitulo = new Label
            {
                Text = info.Titulo,
                Dock = DockStyle.Top,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Padding = new Padding(5)
            };

            var lblMsg = new Label
            {
                Text = info.Mensagem,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(painel.Width - 10, 0),
                Padding = new Padding(5, 0, 5, 5)
            };

            var lblData = new Label
            {
                Text = info.Data.ToString("g"),
                Dock = DockStyle.Top,
                AutoSize = true,
                ForeColor = Color.Gray,
                Padding = new Padding(5, 0, 5, 5)
            };

            painel.Controls.Add(lblData);
            painel.Controls.Add(lblMsg);
            painel.Controls.Add(lblTitulo);

            // Ajuste dinâmico da altura
            painel.Height = lblTitulo.Height + lblMsg.Height + lblData.Height + 15;

            flowPanelNotificacoes.Controls.Add(painel);
            flowPanelNotificacoes.Controls.SetChildIndex(painel, 0);
        }

        // Supondo que você tenha um FlowLayoutPanel chamado flowPanelNotificacoes
        // mais recente no topo
        }
    }
