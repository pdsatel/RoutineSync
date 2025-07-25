namespace Tcc.Dashboard
{
    partial class PerfilUserControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelResumo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.Label lblResumo;
        private System.Windows.Forms.Label lblTarefasTotal;
        private System.Windows.Forms.Label lblTarefasConcluidas;
        private System.Windows.Forms.Label lblTarefasPendentes;
        private System.Windows.Forms.Label lblPrioridadeMaisUsada;
        private System.Windows.Forms.Label lblNascimento;
        private System.Windows.Forms.Label lblNacionalidade;
        private System.Windows.Forms.Label lblProfissao;
        private System.Windows.Forms.Label lblTelefone;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelResumo = new System.Windows.Forms.Panel();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblNascimento = new System.Windows.Forms.Label();
            this.lblNacionalidade = new System.Windows.Forms.Label();
            this.lblProfissao = new System.Windows.Forms.Label();
            this.lblCadastro = new System.Windows.Forms.Label();

            this.lblResumo = new System.Windows.Forms.Label();
            this.lblTarefasTotal = new System.Windows.Forms.Label();
            this.lblTarefasConcluidas = new System.Windows.Forms.Label();
            this.lblTarefasPendentes = new System.Windows.Forms.Label();
            this.lblPrioridadeMaisUsada = new System.Windows.Forms.Label();

            this.SuspendLayout();
            this.Size = new System.Drawing.Size(800, 600);
            this.BackColor = System.Drawing.Color.White;

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(32, 46, 57);
            this.panelHeader.Size = new System.Drawing.Size(800, 160);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;

            // lblTitulo
            this.lblTitulo.Text = "Perfil do Usuário";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 10);
            this.lblTitulo.AutoSize = true;

            // lblNome
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNome.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNome.Location = new System.Drawing.Point(30, 50);
            this.lblNome.AutoSize = true;

            // lblEmail
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEmail.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblEmail.Location = new System.Drawing.Point(30, 75);
            this.lblEmail.AutoSize = true;

            // lblTelefone
            this.lblTelefone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTelefone.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTelefone.Location = new System.Drawing.Point(30, 100);
            this.lblTelefone.AutoSize = true;

            // lblCadastro
            this.lblCadastro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCadastro.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCadastro.Location = new System.Drawing.Point(30, 125);
            this.lblCadastro.AutoSize = true;

            // lblNascimento
            this.lblNascimento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNascimento.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNascimento.Location = new System.Drawing.Point(400, 50);
            this.lblNascimento.AutoSize = true;

            // lblNacionalidade
            this.lblNacionalidade.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNacionalidade.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNacionalidade.Location = new System.Drawing.Point(400, 75);
            this.lblNacionalidade.AutoSize = true;

            // lblProfissao
            this.lblProfissao.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProfissao.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblProfissao.Location = new System.Drawing.Point(400, 100);
            this.lblProfissao.AutoSize = true;

            // panelResumo
            this.panelResumo.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelResumo.Size = new System.Drawing.Size(760, 350);
            this.panelResumo.Location = new System.Drawing.Point(20, 180);
            this.panelResumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblResumo
            this.lblResumo.Text = "Resumo de Tarefas";
            this.lblResumo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblResumo.ForeColor = System.Drawing.Color.White;
            this.lblResumo.Location = new System.Drawing.Point(30, 20);
            this.lblResumo.AutoSize = true;

            // lblTarefasTotal
            this.lblTarefasTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTarefasTotal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTarefasTotal.Location = new System.Drawing.Point(30, 70);
            this.lblTarefasTotal.AutoSize = true;

            // lblTarefasConcluidas
            this.lblTarefasConcluidas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTarefasConcluidas.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblTarefasConcluidas.Location = new System.Drawing.Point(30, 110);
            this.lblTarefasConcluidas.AutoSize = true;

            // lblTarefasPendentes
            this.lblTarefasPendentes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTarefasPendentes.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTarefasPendentes.Location = new System.Drawing.Point(30, 150);
            this.lblTarefasPendentes.AutoSize = true;

            // lblPrioridadeMaisUsada
            this.lblPrioridadeMaisUsada.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPrioridadeMaisUsada.ForeColor = System.Drawing.Color.Gold;
            this.lblPrioridadeMaisUsada.Location = new System.Drawing.Point(30, 190);
            this.lblPrioridadeMaisUsada.AutoSize = true;

            // Adicionando ao painel
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblNome);
            this.panelHeader.Controls.Add(this.lblEmail);
            this.panelHeader.Controls.Add(this.lblTelefone);
            this.panelHeader.Controls.Add(this.lblCadastro);
            this.panelHeader.Controls.Add(this.lblNascimento);
            this.panelHeader.Controls.Add(this.lblNacionalidade);
            this.panelHeader.Controls.Add(this.lblProfissao);

            this.panelResumo.Controls.Add(this.lblResumo);
            this.panelResumo.Controls.Add(this.lblTarefasTotal);
            this.panelResumo.Controls.Add(this.lblTarefasConcluidas);
            this.panelResumo.Controls.Add(this.lblTarefasPendentes);
            this.panelResumo.Controls.Add(this.lblPrioridadeMaisUsada);

            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelResumo);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
