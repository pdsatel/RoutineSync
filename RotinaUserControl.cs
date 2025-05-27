using System;
using System.Windows.Forms;

namespace Tcc
{
    public partial class RotinaUserControl : UserControl
    {
        private int usuarioId;

        public RotinaUserControl(int idUsuario)
        {
            InitializeComponent();
            usuarioId = idUsuario;
            InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {
            // Carregar rotinas do banco e popular a lista
            CarregarRotinas();
        }

        private void CarregarRotinas()
        {
            // Lógica para consultar o banco e exibir rotinas
            // Exemplo fictício:
            // var lista = RotinaDAO.ObterPorUsuario(usuarioId);
            // listBoxRotinas.Items.Clear();
            // foreach (var r in lista) listBoxRotinas.Items.Add(r);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validar campos
            // Salvar rotina no banco
            // Atualizar lista
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Carregar dados da rotina selecionada nos campos
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Confirmar exclusão
            // Deletar do banco
            // Atualizar lista
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar todos os campos do formulário
        }
        private void RotinasUserControl_Load(object sender, EventArgs e)
        {
            CentralizarPainel(panelInputs);

            // Estilização adicional (se desejar)
            this.BackColor = ColorTranslator.FromHtml("#FFFCF6");

            foreach (Control ctrl in this.Controls)
            {
                ctrl.Font = new Font("Segoe UI", 11);
                if (ctrl is Button btn)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#202E39");
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }

                if (ctrl is Label lbl)
                    lbl.ForeColor = ColorTranslator.FromHtml("#333333");
            }
        }


        private void CentralizarPainel(Control painel)
        {
            painel.Left = (this.ClientSize.Width - painel.Width) / 2;
            painel.Top = 30; // distância do topo
        }


        private void RotinaUserControl_SizeChanged(object sender, EventArgs e)
        {
            CentralizarPainel(Parent);

        }
    }
}
