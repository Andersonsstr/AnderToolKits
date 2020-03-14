using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
        public void ImprimeInfoBasicas()
        {
            string arquitetura = Environment.Is64BitOperatingSystem ? " 64 bits" : " 32 bits";

            lblSO.Text = RuntimeInformation.OSDescription + arquitetura;
            lblHostname.Text = Environment.MachineName;

            if(Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length > 0)
            {
                foreach (IPAddress endereco in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (!endereco.ToString().Contains(":")){
                        lblIP.Text = endereco.ToString();
                        break;
                    };
                }
            }
            else
            {
                lblIP.Text = "IP não localizado.";
            }
        }

        public Main()
        {
            InitializeComponent();
            ImprimeInfoBasicas();
        }

        private void btnMstsc_Click(object sender, EventArgs e)
        {
            PegaDado mstsc = new PegaDado("Informe o IP/Hostname para iniciar o acesso");
            mstsc.ShowDialog();

            if (mstsc.DialogResult == DialogResult.OK)
            {
                Processo.Executa("mstsc", "-v " + mstsc.dadoInformado, true);
            }
        }
        private void btnPing_Click(object sender, EventArgs e)
        {
            PegaDado pegaDado = new PegaDado("Informe o IP/Hostname para verificar");
            pegaDado.ShowDialog();

            if (pegaDado.DialogResult == DialogResult.OK)
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pegaDado.dadoInformado);

                if (pingReply.Status == IPStatus.Success)
                {
                    MessageBox.Show("Máquina Online!");
                }
                else
                {
                    MessageBox.Show("Máquina Offline!");
                }
            }
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
            Processo.Executa("explorer", "C:", true);
        }

        private void btnChrome(object sender, EventArgs e)
        {
            Processo.Executa("chrome", "www.google.com.br", false);
        }

        private void btnLimparTemporariosWindows_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBoxConfirmacao("Deseja mesmo limpar os arquivos temporários de sistema e usuário", "Alerta");
           
            if(dr == DialogResult.OK)
            {
                LimpaTemporarios.FazerLimpeza();
                MessageBox.Show("Limpeza efetuada com sucesso!");
            }
        }  
        
        public DialogResult MessageBoxConfirmacao(string mensagem, string titulo)
        {
            DialogResult dr = MessageBox.Show(mensagem, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return dr;
        }
    }
}
