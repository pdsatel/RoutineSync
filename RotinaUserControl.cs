using System;
using System.Drawing.Drawing2D;
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
        private void AplicarEstiloControles()
        {
            this.BackColor = ColorTranslator.FromHtml("#FFFCF6");

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.White;
                    txt.ForeColor = ColorTranslator.FromHtml("#333333");
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.BackColor = Color.White;
                    cmb.ForeColor = ColorTranslator.FromHtml("#333333");
                    cmb.FlatStyle = FlatStyle.Flat;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.CalendarForeColor = Color.Black;
                    dtp.CalendarMonthBackground = Color.White;
                    dtp.CalendarTitleBackColor = ColorTranslator.FromHtml("#202E39");
                    dtp.CalendarTitleForeColor = Color.White;
                    dtp.BackColor = Color.White;
                    dtp.ForeColor = ColorTranslator.FromHtml("#333333");
                }
                else if (ctrl is ListBox lb)
                {
                    lb.BackColor = Color.White;
                    lb.ForeColor = ColorTranslator.FromHtml("#333333");
                    lb.Font = new Font("Segoe UI", 10);
                }
            }

            // Além disso, se você quiser, pode aplicar cores nos seus botões:
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#202E39"); // azul suave
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#4A90E2");
                }
            }
        }









        private void RotinasUserControl_Load(object sender, EventArgs e)
        {
            // Ajuste inicial do texto e itens
            labelTitulo.Text = "Título:";
            labelDescricao.Text = "Descrição:";
            labelHorario.Text = "Horário:";
            labelDiaSemana.Text = "Dia da Semana:";

            comboBoxDiaSemana.Items.Clear();
            comboBoxDiaSemana.Items.AddRange(new object[] { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" });   

            OrganizarLayout();
            AplicarEstiloControles();
        }

        private void RotinaUserControl_SizeChanged(object sender, EventArgs e)
        {
            OrganizarLayout();
        }

        private void OrganizarLayout()
        {

            int margem = 20;
            int larguraPainel = (this.ClientSize.Width / 3); // painel ocupa 1/3 da largura
            int alturaPainel = this.ClientSize.Height - 3 * margem - btnSalvar.Height;

            

            // Define tamanho e posição do painelInputs
            panelInputs.SetBounds(margem, margem, larguraPainel, alturaPainel);

            // Posiciona os controles dentro do painelInputs com margens internas
            int padding = 10;
            int labelAltura = 23;
            int campoAltura = 31;
            int larguraCampo = panelInputs.Width - 2 * padding;

            labelTitulo.SetBounds(padding, padding, larguraCampo, labelAltura);
            textBoxTitulo.SetBounds(padding, labelTitulo.Bottom + 2, larguraCampo, campoAltura);

            labelDescricao.SetBounds(padding, textBoxTitulo.Bottom + 10, larguraCampo, labelAltura);
            textBoxDescricao.SetBounds(padding, labelDescricao.Bottom + 2, larguraCampo, campoAltura);

            labelHorario.SetBounds(padding, textBoxDescricao.Bottom + 10, larguraCampo, labelAltura);
            dateTimePickerHorario.SetBounds(padding, labelHorario.Bottom + 2, larguraCampo, campoAltura);

            labelDiaSemana.SetBounds(padding, dateTimePickerHorario.Bottom + 10, larguraCampo, labelAltura);
            comboBoxDiaSemana.SetBounds(padding, labelDiaSemana.Bottom + 2, larguraCampo, campoAltura);

            // ListBox ocupa o espaço restante do lado direito do painel
            int larguraListBox = this.ClientSize.Width - panelInputs.Right - 2 * margem;
            int alturaListBox = alturaPainel;
            listBoxRotinas.SetBounds(panelInputs.Right + margem, margem, larguraListBox, alturaListBox);

            // Botões alinhados abaixo do painelInputs, com espaçamento entre eles
            int btnLargura = 100;
            int btnAltura = 35;
            int btnEspaco = 10;
            int btnTop = panelInputs.Bottom + margem;

            btnSalvar.SetBounds(panelInputs.Left, btnTop, btnLargura, btnAltura);
            btnEditar.SetBounds(btnSalvar.Right + btnEspaco, btnTop, btnLargura, btnAltura);
            btnExcluir.SetBounds(btnEditar.Right + btnEspaco, btnTop, btnLargura, btnAltura);
            btnLimpar.SetBounds(btnExcluir.Right + btnEspaco, btnTop, btnLargura, btnAltura);


            ArredondarControle(panelInputs, 20);
            ArredondarControle(listBoxRotinas, 20);
        }

        private void ArredondarControle(Control controle, int raio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, raio, raio), 180, 90);
            path.AddArc(new Rectangle(controle.Width - raio, 0, raio, raio), 270, 90);
            path.AddArc(new Rectangle(controle.Width - raio, controle.Height - raio, raio, raio), 0, 90);
            path.AddArc(new Rectangle(0, controle.Height - raio, raio, raio), 90, 90);
            path.CloseFigure();

            controle.Region = new Region(path);
        }


       




        private void CentralizarPainel(Control painel)
        {
            painel.Left = (this.ClientSize.Width - painel.Width) / 2;
            painel.Top = 40; // distância do topo
        }


        
    }
}
