using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolKits_Template.src.Telas;

namespace ToolKits_Template
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnMstsc_Click(object sender, EventArgs e)
        {
            Mstsc mstsc = new Mstsc();
            mstsc.ShowDialog();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            ExecutaProcesso("calc", "");
        }

        private void btnCMD_Click(object sender, EventArgs e)
        {
            ExecutaProcesso("cmd", "");
        }

        private void btnPainelControle_Click(object sender, EventArgs e)
        {
            ExecutaProcesso("control", "");
        }

        private void btnExplorer_Click(object sender, EventArgs e)
        {
            ExecutaProcesso("explorer", "");
        }

        private void btnChrome(object sender, EventArgs e)
        {
            ExecutaProcesso("chrome", "");
        }

        public void ExecutaProcesso(string processo, string argumentos)
        {
            try
            {
                Process rdcProcess = new Process();

                string executable = Environment.ExpandEnvironmentVariables("%SystemRoot%\\system32\\" + processo + ".exe");
                if (executable != null)
                {
                    rdcProcess.StartInfo.FileName = executable;
                    rdcProcess.StartInfo.Arguments = "";
                    rdcProcess.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AbreAplicacao(string arquivo)
        {

        }
    }
}
