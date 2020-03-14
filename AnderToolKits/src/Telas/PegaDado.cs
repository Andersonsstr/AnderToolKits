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
using ToolKits_Template.src.Classes;

namespace AnderToolKits.src.Telas
{
    public partial class PegaDado : Form
    {
        string erro;

        public PegaDado(string mensagem, string erro)
        {
            InitializeComponent();
            lblMensagem.Text = mensagem;
            this.erro = erro;
        }

        public string dadoInformado;

        private void btnOk_OnClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(erro))
            {
                dadoInformado = lblInput.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if(!String.IsNullOrEmpty(lblInput.Text))
            {
                dadoInformado = lblInput.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ExibeMessageBox.Erro(erro);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PegaDado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }

        private void lblInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}
