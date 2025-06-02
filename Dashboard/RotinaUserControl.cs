using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CalendarNet;

namespace Tcc
{
    public partial class RotinaUserControl : UserControl
    {
        private int usuarioId;
        private List<Rotina> rotinas = new List<Rotina>();
        private int proximoId = 1;
        private Rotina rotinaSelecionada = null;

        public RotinaUserControl(int idUsuario)
        {
            InitializeComponent();
            usuarioId = idUsuario;
            InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {
            // Inicialização extra
            CarregarRotinas();

        }

        private void AtualizarEventosNoCalendario(List<Rotina> rotinas)
        {
            calendar.Events.Clear(); // limpa eventos antigos

            foreach (var rotina in rotinas)
            {
                var evento = new CalendarNet.CalendarEvent
                {
                    Date = rotina.DataHora.Date,           // data do evento
                    Text = rotina.Titulo,                   // título exibido
                    EventColor = Color.Blue,                // cor do evento (pode personalizar)
                    EnableTime = true,                      // habilita horário
                    StartTime = rotina.DataHora.TimeOfDay  // horário do evento
                };

                calendar.Events.Add(evento);
            }

            calendar.Refresh(); // atualiza a interface do calendário
        }


        private void CarregarRotinas()
        {
            // Exemplo: carregar rotinas do banco e popular a lista
            // Por enquanto, lista em memória vazia
            AtualizarListaRotinas();
        }

        private void AtualizarListaRotinas()
        {
            listBoxRotinas.Items.Clear();
            foreach (var r in rotinas)
            {
                listBoxRotinas.Items.Add($"{r.DiaSemana} - {r.Titulo} às {r.Horario.ToShortTimeString()}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitulo.Text))
            {
                MessageBox.Show("Preencha o título.");
                return;
            }
            if (comboBoxDiaSemana.SelectedItem == null)
            {
                MessageBox.Show("Selecione o dia da semana.");
                return;
            }

            Rotina novaRotina = new Rotina
            {
                Id = proximoId++,
                Titulo = textBoxTitulo.Text,
                Descricao = textBoxDescricao.Text,
                Horario = dateTimePickerHorario.Value,
                DiaSemana = comboBoxDiaSemana.SelectedItem.ToString()
            };

            rotinas.Add(novaRotina);
            AtualizarListaRotinas();
            LimparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (rotinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma rotina para editar.");
                return;
            }

            rotinaSelecionada.Titulo = textBoxTitulo.Text;
            rotinaSelecionada.Descricao = textBoxDescricao.Text;
            rotinaSelecionada.Horario = dateTimePickerHorario.Value;
            rotinaSelecionada.DiaSemana = comboBoxDiaSemana.SelectedItem?.ToString() ?? rotinaSelecionada.DiaSemana;

            AtualizarListaRotinas();
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (rotinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma rotina para excluir.");
                return;
            }

            var result = MessageBox.Show($"Deseja excluir a rotina \"{rotinaSelecionada.Titulo}\"?", "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                rotinas.Remove(rotinaSelecionada);
                AtualizarListaRotinas();
                LimparCampos();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxTitulo.Clear();
            textBoxDescricao.Clear();
            comboBoxDiaSemana.SelectedIndex = -1;
            dateTimePickerHorario.Value = DateTime.Now;
            rotinaSelecionada = null;
            listBoxRotinas.ClearSelected();
        }

        private void listBoxRotinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = listBoxRotinas.SelectedIndex;
            if (idx >= 0 && idx < rotinas.Count)
            {
                rotinaSelecionada = rotinas[idx];
                textBoxTitulo.Text = rotinaSelecionada.Titulo;
                textBoxDescricao.Text = rotinaSelecionada.Descricao;
                dateTimePickerHorario.Value = rotinaSelecionada.Horario;
                comboBoxDiaSemana.SelectedItem = rotinaSelecionada.DiaSemana;
            }
            else
            {
                rotinaSelecionada = null;
            }
        }

        private void RotinasUserControl_Load(object sender, EventArgs e)
        {
            comboBoxDiaSemana.Items.Clear();
            comboBoxDiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" });
        }
    }

    public class Rotina
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Horario { get; set; }
        public string DiaSemana { get; set; }
    }
}
