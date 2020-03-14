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

namespace AnderToolKits.src.Telas
{
    public partial class PegaDado : Form
    {
        public PegaDado(string mensagem)
        {
            InitializeComponent();
            lblMensagem.Text = mensagem;
        }

        public string dadoInformado;

        private void btnOk_OnClick(object sender, EventArgs e)
        {
            dadoInformado = lblInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
