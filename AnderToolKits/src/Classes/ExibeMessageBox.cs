using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolKits_Template.src.Classes
{
    class ExibeMessageBox
    {
        public static void Erro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Confirmacao(string mensagem, string titulo)
        {
            DialogResult dr = MessageBox.Show(mensagem, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return dr;
        }
    }
}
