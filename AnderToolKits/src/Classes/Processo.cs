using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolKits_Template.src.Classes
{
    class Processo
    {
        public static void Executa(string executavel, string argumentos, bool system32)
        {
            try
            {
                Process processo = new Process();
                executavel = system32? Environment.ExpandEnvironmentVariables("%SystemRoot%\\system32\\" + executavel + ".exe") : executavel + ".exe";
                if (executavel != null)
                {
                    processo.StartInfo.FileName = executavel;
                    processo.StartInfo.Arguments = argumentos;
                    processo.Start();
                }
            }
            catch (Exception ex)
            {
                ExibeMessageBox.Erro(ex.Message);
            }
        }

        private static void Finaliza(string nomeDoProcesso)
        {
            nomeDoProcesso = nomeDoProcesso.ToLower();
            foreach (Process P in Process.GetProcesses())
            {
                if (P.ProcessName.ToLower().StartsWith(nomeDoProcesso))
                    P.Kill();
            }
        }
    }
}
