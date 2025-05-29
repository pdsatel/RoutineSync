namespace Tcc
{
    partial class DashboardFrm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Label labelTitulo;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnTarefas;
        private System.Windows.Forms.Button btnRotina;
        private System.Windows.Forms.Button btnSaude;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.Button btnIA;
        private System.Windows.Forms.Button btnSair;

        private System.Windows.Forms.Panel panelConteudo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTopo = new Panel();
            labelTitulo = new Label();
            panelMenu = new Panel();
            btnIA = new Button();
            btnRelatorios = new Button();
            btnSaude = new Button();
            btnRotina = new Button();
            btnTarefas = new Button();
            btnSair = new Button();
            panelConteudo = new Panel();
            panelTopo.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopo
            // 
            panelTopo.BackColor = Color.FromArgb(32, 46, 57);
            panelTopo.Controls.Add(labelTitulo);
            panelTopo.Dock = DockStyle.Top;
            panelTopo.Location = new Point(0, 0);
            panelTopo.Margin = new Padding(10);
            panelTopo.Name = "panelTopo";
            panelTopo.Size = new Size(1250, 95);
            panelTopo.TabIndex = 2;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(25, 19);
            labelTitulo.Margin = new Padding(4, 0, 4, 0);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(475, 46);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "RoutineSync Dashboard";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(44, 62, 80);
            panelMenu.Controls.Add(btnIA);
            panelMenu.Controls.Add(btnRelatorios);
            panelMenu.Controls.Add(btnSaude);
            panelMenu.Controls.Add(btnRotina);
            panelMenu.Controls.Add(btnTarefas);
            panelMenu.Controls.Add(btnSair);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 95);
            panelMenu.Margin = new Padding(4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(225, 655);
            panelMenu.TabIndex = 1;
            // 
            // btnIA
            // 
            btnIA.BackColor = Color.FromArgb(44, 62, 80);
            btnIA.Dock = DockStyle.Top;
            btnIA.FlatAppearance.BorderSize = 0;
            btnIA.FlatStyle = FlatStyle.Flat;
            btnIA.Font = new Font("Microsoft Sans Serif", 12F);
            btnIA.ForeColor = Color.White;
            btnIA.Location = new Point(0, 307);
            btnIA.Margin = new Padding(0, 0, 0, 10);
            btnIA.Name = "btnIA";
            btnIA.Size = new Size(225, 77);
            btnIA.TabIndex = 0;
            btnIA.Height = 110;
            btnIA.Text = "Sugestões IA";
            btnIA.UseVisualStyleBackColor = false;
            btnIA.Click += btnIA_Click;
            // 
            // btnRelatorios
            // 
            btnRelatorios.BackColor = Color.FromArgb(44, 62, 80);
            btnRelatorios.Dock = DockStyle.Top;
            btnRelatorios.FlatAppearance.BorderSize = 0;
            btnRelatorios.FlatStyle = FlatStyle.Flat;
            btnRelatorios.Font = new Font("Microsoft Sans Serif", 12F);
            btnRelatorios.ForeColor = Color.White;
            btnRelatorios.Location = new Point(0, 224);
            btnRelatorios.Margin = new Padding(0, 0, 0, 10);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(225, 83);
            btnRelatorios.TabIndex = 1;
            btnRelatorios.Height = 110;
            btnRelatorios.Text = " Relatórios";
            btnRelatorios.UseVisualStyleBackColor = false;
            btnRelatorios.Click += btnRelatorios_Click;
            // 
            // btnSaude
            // 
            btnSaude.BackColor = Color.FromArgb(44, 62, 80);
            btnSaude.Dock = DockStyle.Top;
            btnSaude.FlatAppearance.BorderSize = 0;
            btnSaude.FlatStyle = FlatStyle.Flat;
            btnSaude.Font = new Font("Microsoft Sans Serif", 12F);
            btnSaude.ForeColor = Color.White;
            btnSaude.Location = new Point(0, 149);
            btnSaude.Margin = new Padding(0, 0, 0, 10);
            btnSaude.Name = "btnSaude";
            btnSaude.Size = new Size(225, 75);
            btnSaude.TabIndex = 2;
            btnSaude.Height = 110;
            btnSaude.Text = "Saúde";
            btnSaude.UseVisualStyleBackColor = false;
            btnSaude.Click += btnSaude_Click;
            // 
            // btnRotina
            // 
            btnRotina.BackColor = Color.FromArgb(44, 62, 80);
            btnRotina.Dock = DockStyle.Top;
            btnRotina.FlatAppearance.BorderSize = 0;
            btnRotina.FlatStyle = FlatStyle.Flat;
            btnRotina.Font = new Font("Microsoft Sans Serif", 12F);
            btnRotina.ForeColor = Color.White;
            btnRotina.Location = new Point(0, 77);
            btnRotina.Margin = new Padding(0, 0, 0, 10);
            btnRotina.Name = "btnRotina";
            btnRotina.Size = new Size(225, 72);
            btnRotina.TabIndex = 3;
            btnRotina.Height = 110;
            btnRotina.Text = "Rotina";
            btnRotina.UseVisualStyleBackColor = false;
            btnRotina.Click += btnRotina_Click;
            // 
            // btnTarefas
            // 
            btnTarefas.BackColor = Color.FromArgb(44, 62, 80);
            btnTarefas.Dock = DockStyle.Top;
            btnTarefas.FlatAppearance.BorderSize = 0;
            btnTarefas.FlatStyle = FlatStyle.Flat;
            btnTarefas.Font = new Font("Microsoft Sans Serif", 12F);
            btnTarefas.ForeColor = Color.White;
            btnTarefas.Location = new Point(0, 0);
            btnTarefas.Margin = new Padding(0, 0, 0, 10);
            btnTarefas.Name = "btnTarefas";
            btnTarefas.Size = new Size(225, 77);
            btnTarefas.TabIndex = 4;
            btnTarefas.Height = 110;
            btnTarefas.Text = "Tarefas";
            btnTarefas.UseVisualStyleBackColor = false;
            btnTarefas.Click += btnTarefas_Click;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.FromArgb(44, 62, 80);
            btnSair.Dock = DockStyle.Bottom;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Microsoft Sans Serif", 12F);
            btnSair.ForeColor = Color.White;
            btnSair.Location = new Point(0, 593);
            btnSair.Margin = new Padding(0, 0, 0, 10);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(225, 62);
            btnSair.TabIndex = 5;
            btnSair.Height = 110;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += btnSair_Click;
            // 
            // panelConteudo
            // 
            panelConteudo.BackColor = Color.White;
            panelConteudo.Dock = DockStyle.Fill;
            panelConteudo.Font = new Font("Microsoft Sans Serif", 10F);
            panelConteudo.Location = new Point(225, 95);
            panelConteudo.Margin = new Padding(4);
            panelConteudo.Name = "panelConteudo";
            panelConteudo.Size = new Size(1025, 655);
            panelConteudo.TabIndex = 0;
            panelConteudo.Paint += panelConteudo_Paint;
            // 
            // DashboardFrm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 750);
            Controls.Add(panelConteudo);
            Controls.Add(panelMenu);
            Controls.Add(panelTopo);
            Margin = new Padding(4);
            Name = "DashboardFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += DashboardFrm_Load;
            panelTopo.ResumeLayout(false);
            panelTopo.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
