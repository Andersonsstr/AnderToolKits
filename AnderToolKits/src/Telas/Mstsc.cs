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

namespace ToolKits_Template.src.Telas
{
    public partial class Mstsc : Form
    {
        public Mstsc()
        {
            InitializeComponent();
        }

        private void btnOk_OnClick(object sender, EventArgs e)
        {
            Process rdcProcess = new Process();

            string executable = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            if (executable != null)
            {
                rdcProcess.StartInfo.FileName = executable;
                rdcProcess.StartInfo.Arguments = "/v " + txtEndereco.Text; 
                rdcProcess.Start();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
