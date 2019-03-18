using System;
using System.IO;

namespace GerarArquivo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var emprestimoServices = new DependenceInjection().EmprestimoServices();
            var caminhoPadrao = $"c:\\emprestimos";
            if (!Directory.Exists(caminhoPadrao)) Directory.CreateDirectory(caminhoPadrao);
            var nomeArquivo = $"{caminhoPadrao}\\emprestimos{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt";
            using (var writer = new StreamWriter(nomeArquivo))
            {
                emprestimoServices.GerarAquivo().ForEach(x => writer.WriteLine(x));
                writer.Close();
            }

            Console.WriteLine("Arquivo gerado com sucesso!!");
            Console.WriteLine($"Seu arquivo esta em '{caminhoPadrao}'");
            Console.ReadKey();
        }
    }
}