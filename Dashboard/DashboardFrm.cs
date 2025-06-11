    using
        System;
    using System.Globalization;
    using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;



    namespace Tcc
    {
        public partial class DashboardFrm : Form


        {
        
            private int usuarioId;
            private RotinasUserControl rotinasControl;
            private TarefasUserControl tarefasControl;
            public DashboardFrm(int idUsuario)
            {   
                InitializeComponent();
                this.usuarioId = idUsuario;

               tarefasControl = new TarefasUserControl(usuarioId); 
               tarefasControl.CarregarTarefas();
               tarefasControl.Dock = DockStyle.Fill;



               rotinasControl = new RotinasUserControl(tarefasControl);
               rotinasControl.Dock = DockStyle.Fill;

             

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

                btnSaude.Image = Properties.Resources.Coração_png;
                btnSaude.ImageAlign = ContentAlignment.MiddleLeft;
                btnSaude.TextImageRelation = TextImageRelation.ImageBeforeText;

                btnRelatorios.Image = Properties.Resources.Relatorio_png;
                btnRelatorios.ImageAlign = ContentAlignment.MiddleLeft;
                btnRelatorios.TextImageRelation = TextImageRelation.ImageBeforeText;

                btnIA.Image = Properties.Resources.IA_png;
                btnIA.ImageAlign = ContentAlignment.MiddleLeft;
                btnIA.TextImageRelation = TextImageRelation.ImageBeforeText;

                btnSair.Image = Properties.Resources.Sair_png; 
                btnSair.ImageAlign = ContentAlignment.MiddleLeft;
                btnSair.TextImageRelation = TextImageRelation.ImageBeforeText;


                
            }


            private void btnTarefas_Click(object sender, EventArgs e)
            {
               panelConteudo.Controls.Clear();
               panelConteudo.Controls.Add(tarefasControl);  
               tarefasControl.Dock = DockStyle.Fill;
           
                }

            private void btnRotina_Click(object sender, EventArgs e)
            {
                var tarefas = tarefasControl.BuscarTarefasBanco(); // pega as tarefas do usuário
                 rotinasControl.CarregarRotinasDeTarefas(tarefas); // passa para o outro controle

            MessageBox.Show("Rotinas carregadas!");


            panelConteudo.Controls.Clear();
                panelConteudo.Controls.Add(rotinasControl);
                rotinasControl.Dock= DockStyle.Fill;
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
            private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sempre recarrega as rotinas ao entrar na aba
            
        }
    }
    }
