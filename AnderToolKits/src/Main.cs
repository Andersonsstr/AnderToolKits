using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnderToolKits.src.Classes;
using AnderToolKits.src.Telas;
using ToolKits_Template.src.Classes;

namespace AnderToolKits
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ImprimeInfoBasicas();
        }

        public void ImprimeInfoBasicas()
        {
            string arquitetura = Environment.Is64BitOperatingSystem ? " 64 bits" : " 32 bits";

            lblSO.Text = RuntimeInformation.OSDescription + arquitetura;
            lblHostname.Text = Environment.MachineName;
            lblIP.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
        }

        private void btnMstsc_Click(object sender, EventArgs e)
        {
            Mstsc mstsc = new Mstsc();
            mstsc.ShowDialog();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            Processo.Executa("calc", "", true);
        }

        private void btnCMD_Click(object sender, EventArgs e)
        {
            Processo.Executa("cmd", "", true);
        }

        private void btnPainelControle_Click(object sender, EventArgs e)
        {
            Processo.Executa("control", "", true);
        }

        private void btnExplorer_Click(object sender, EventArgs e)
        {
            Processo.Executa("explorer", "", true);
        }

        private void btnChrome(object sender, EventArgs e)
        {
            Processo.Executa("chrome", "", false);
        }

        private void btnLimparTemporariosWindows_Click(object sender, EventArgs e)
        {
            LimpaTemporarios.FazerLimpeza();
        }
    }
}
