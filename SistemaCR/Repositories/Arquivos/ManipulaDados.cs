using System;
using System.IO;
using System.Collections.Generic;

namespace SistemaCR.Repositories
{
    static class ManipulaDados
    {
        public static List<string[]> carregarDados(string caminhoArquivo)
        {
            List<string[]> notas = new List<string[]>();

            if(File.Exists(caminhoArquivo))
            {
                try
                {
                    using (StreamReader sr = File.OpenText(caminhoArquivo))
                    {
                        while(!sr.EndOfStream)
                        {
                            string [] nota = sr.ReadLine().Split(',');
                            notas.Add(nota); 
                        }
                    }
                }

                catch(IOException erro)
                {
                    Console.WriteLine("Erro na leitura do arquivo " + erro.Message);
                }
                
                return notas;
            }

            else
            {
                Console.WriteLine("Arquivo nao encontrado!");
                return null;
            }
        }
    }
}