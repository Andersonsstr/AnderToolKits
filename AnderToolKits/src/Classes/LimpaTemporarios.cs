using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace AnderToolKits.src.Classes
{
    public static class LimpaTemporarios
    {       
        public static void FazerLimpeza()
        {
            string diretorioRaiz = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToLower().Replace("documents", "");
            RemoverArquivos(diretorioRaiz, @"AppData\Local\Temp", false);

            diretorioRaiz = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            RemoverArquivos(diretorioRaiz, @"\Temp", true);
        }      

        private static void RemoverArquivos(string diretorioRaiz, string caminho, bool limparDiretoriosFilhos)
        {
            string FullPath = diretorioRaiz + caminho + "\\";
            if (Directory.Exists(FullPath))
            {
                DirectoryInfo DInfo = new DirectoryInfo(FullPath);
                FileAttributes Attr = DInfo.Attributes;
                DInfo.Attributes = FileAttributes.Normal;

                foreach (string nomeDoArquivo in Directory.GetFiles(FullPath))
                {
                    ApagaArquivo(nomeDoArquivo);
                }

                if (limparDiretoriosFilhos)
                {
                    foreach (string diretorioFilho in Directory.GetDirectories(FullPath))
                    {
                        try { RemoverArquivos("", diretorioFilho, true); } catch { };
                        try { Directory.Delete(diretorioFilho); } catch { }
                    }
                }

                DInfo.Attributes = Attr;
            }
        }

        private static void ApagaArquivo(string FileName)
        {
            if (File.Exists(FileName))
            {
                try { File.Delete(FileName); } catch { }
            }
        }
    }
}