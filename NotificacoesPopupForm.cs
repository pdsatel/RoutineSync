using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Tcc
{
    public partial class NotificacoesPopupForm : Form
    {
        // --- Bordas arredondadas ---
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private System.Windows.Forms.Timer autoCloseTimer;

        // --- Construtor para UMA notificação por vez (string) ---
        public NotificacoesPopupForm(string notificacao, int segundos = 3)
        {
            InitializeComponent();
            this.TopMost = true;

            // --- Paleta de cores padrão ---
            Color corPrimaria = ColorTranslator.FromHtml("#202E39");   // Fundo principal/título
            Color corSecundaria = ColorTranslator.FromHtml("#FFFCF6"); // Fundo popup/painéis
            Color corTexto = ColorTranslator.FromHtml("#333333");      // Texto principal
            Color corApoio = ColorTranslator.FromHtml("#4A90E2");      // Destaque/botões
            Color corSuporte = ColorTranslator.FromHtml("#7ED321");    // Suporte/botões secundários

            // --- Aplica cores ao popup ---
            this.BackColor = corSecundaria;

            // Aplica bordas arredondadas
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // lblTitulo (caso exista)
            if (lblTitulo != null)
            {
                lblTitulo.Text = "Tarefa próxima!";
                lblTitulo.ForeColor = corPrimaria;
                lblTitulo.BackColor = corSecundaria;
            }

            // listBoxNotificacoes (caso exista)
            if (listBoxNotificacoes != null)
            {
                listBoxNotificacoes.BackColor = corSecundaria;
                listBoxNotificacoes.ForeColor = corTexto;
                listBoxNotificacoes.Items.Clear();
                listBoxNotificacoes.Items.Add(notificacao);
            }

            // btnFechar (caso exista)
            

            // Timer para fechar o popup automaticamente
            autoCloseTimer = new System.Windows.Forms.Timer();
            autoCloseTimer.Interval = segundos * 1000;
            autoCloseTimer.Tick += (s, e) =>
            {
                autoCloseTimer.Stop();
                this.Close();
            };
            autoCloseTimer.Start();
        }
    }
}