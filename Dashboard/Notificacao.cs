using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tcc;

namespace RoutineSync
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
                if (tarefa.Status != null && !tarefa.Status.ToLower().Contains("conclu"))
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
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = info.Lida ? Color.LightGray : Color.LightYellow,
                Padding = new Padding(5)
            };

            var lblTitulo = new Label
            {
                Text = info.Titulo,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 20
            };
            var lblMsg = new Label
            {
                Text = info.Mensagem,
                Dock = DockStyle.Top,
                Height = 20
            };
            var lblData = new Label
            {
                Text = info.Data.ToString("g"),
                Dock = DockStyle.Top,
                Height = 20,
                ForeColor = Color.Gray
            };

            painel.Controls.Add(lblData);
            painel.Controls.Add(lblMsg);
            painel.Controls.Add(lblTitulo);

            painel.Click += (s, e) => {
                info.Lida = true;
                painel.BackColor = Color.LightGray;
            };

            // Supondo que você tenha um FlowLayoutPanel chamado flowPanelNotificacoes
            flowPanelNotificacoes.Controls.Add(painel);
            flowPanelNotificacoes.Controls.SetChildIndex(painel, 0); // mais recente no topo
        }
    }
}