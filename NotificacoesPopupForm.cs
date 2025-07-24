using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms;


namespace Tcc
{
    public partial class NotificacoesPopupForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private System.Windows.Forms.Timer autoCloseTimer;
        private System.Windows.Forms.Timer fadeOutTimer;
        private System.Windows.Forms.Timer slideInTimer;


        private int targetLeft;

        public NotificacoesPopupForm(string notificacao, int segundos = 2)
        {
            InitializeComponent();
            this.TopMost = true;
            this.Opacity = 0; // começa invisível

            // 🎨 Paleta de cores
            Color corPrimaria = ColorTranslator.FromHtml("#202E39");
            Color corSecundaria = ColorTranslator.FromHtml("#FFFCF6");
            Color corTexto = ColorTranslator.FromHtml("#333333");

            this.BackColor = corSecundaria;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // 🔧 Posicionamento inicial: fora da tela
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(screenWidth, screenHeight - 160);
            targetLeft = screenWidth - this.Width - 20;

            // 📝 Título e lista
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Tarefa próxima!";
                lblTitulo.ForeColor = corPrimaria;
                lblTitulo.BackColor = corSecundaria;
            }

            if (listBoxNotificacoes != null)
            {
                listBoxNotificacoes.BackColor = corSecundaria;
                listBoxNotificacoes.ForeColor = corTexto;
                listBoxNotificacoes.Items.Clear();
                listBoxNotificacoes.Items.Add(notificacao);
            }

            // 🕒 Slide-in animado
            slideInTimer = new System.Windows.Forms.Timer();
            slideInTimer.Interval = 15;
            slideInTimer.Tick += (s, e) =>
            {
                if (this.Left > targetLeft)
                {
                    this.Left -= 20;
                    if (this.Opacity < 1)
                        this.Opacity += 0.1;
                }
                else
                {
                    this.Left = targetLeft;
                    this.Opacity = 1;
                    slideInTimer.Stop();
                }
            };
            slideInTimer.Start();

            // ⏱️ Auto-fechamento e fade-out
            autoCloseTimer = new System.Windows.Forms.Timer();
            autoCloseTimer.Interval = segundos * 1000;
            autoCloseTimer.Tick += (s, e) =>
            {
                autoCloseTimer.Stop();
                fadeOutTimer.Start();
            };

            fadeOutTimer = new System.Windows.Forms.Timer();
            fadeOutTimer.Interval = 50;
            fadeOutTimer.Tick += (s, e) =>
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.05;
                else
                {
                    fadeOutTimer.Stop();
                    this.Close();
                }
            };

            autoCloseTimer.Start();
        }
    }
}
