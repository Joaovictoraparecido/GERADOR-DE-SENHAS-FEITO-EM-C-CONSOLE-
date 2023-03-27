using System;
using System.IO;

namespace GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Digite o tamanho de caracteres que sua senha terá:");
                int length = int.Parse(Console.ReadLine());

                string senha = GerarSenha(length);
                Console.WriteLine($"Senha gerada: {senha}");

                Console.WriteLine("Deseja salvar a senha em um arquivo de texto? (s/n)");
                string resposta = Console.ReadLine();

                if (resposta.ToLower() == "s")
                {
                    SalvarSenha(senha);
                }

                Console.WriteLine("Deseja gerar outra senha? (s/n)");
                resposta = Console.ReadLine();

                if (resposta.ToLower() == "n")
                {
                    continuar = false;
                }
            }
        }

        static string GerarSenha(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void SalvarSenha(string senha)
        {
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(dirPath, "Senha.txt");

            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine($"Senha gerada: {senha}");
            }

            Console.WriteLine($"Senha salva em {filePath}");
        }
    }
}
