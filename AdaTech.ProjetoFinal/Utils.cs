using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdaTech.ProjetoFinal
{
    internal class Utils
    {
        public static void PrintLittlePerson(int errors)
        {
            switch (errors)
            {
                case 0:
                    Console.WriteLine(@"
 ________________________
|                        |
|                        |
|                         
|                         
|                         
|                         
|                         
|                         
|                         
|                         
|                         
|                         
|                         
|                         ");
                    break;

                case 1:
                    Console.WriteLine(@"
 ________________________
|                        |
|                        |
|                        _
|                      /. .\  
|                      \ - /
|                         
|                         
|                         
|                         
|                         
|                         
|                        
|                        
|                         ");
                    break;

                case 2:
                    Console.WriteLine(@"
 ________________________
|                        |
|                        |
|                        _
|                      /. .\  
|                    \ \ - /
|                     \__|
|                         
|                         
|                         
|                         
|                         
|                        
|                        
|                         ");
                    break;

                case 3:
                    Console.WriteLine(@"
 ________________________
|                        |
|                        |
|                        _
|                      /. .\  
|                    \ \ - / /
|                     \__|__/
|                         
|                         
|                         
|                         
|                         
|                        
|                        
|                         ");
                    break;

                case 4:
                    Console.WriteLine(@"
 ________________________
|                        |
|                        |
|                        _
|                      /. .\  
|                    \ \ - / /
|                     \__|__/
|                        |  
|                        |  
|                        |
|                       / 
|                     _/  
|                        
|                        
|                         ");
                    break;

                case 5:
                    Console.WriteLine(@"
 ________________________
|                        |
|                        |
|                        _
|                      /. .\  
|                    \ \ - / /
|                     \__|__/
|                        |  
|                        |  
|                        |
|                       / \
|                     _/   \_
|                        
|                        
|                         ");
                    break;

                default:
                    Console.WriteLine(@"
 ________________________
|                        |
|                        |
|                        _
|                      /x x\
|                      \ ^ /
|                       _|_
|                      / | \
|                     /  |  \
|                        |
|                       / \
|                     _/   \_
|                        
|                        
|                        ");
                    break;

            }
        }

        public static void GameOver(string word)
        {
            RevealWord(word);

            Console.WriteLine();
            Console.WriteLine(@"
███████╗██╗███╗░░░███╗  ██████╗░███████╗  ░░░░░██╗░█████╗░░██████╗░░█████╗░
██╔════╝██║████╗░████║  ██╔══██╗██╔════╝  ░░░░░██║██╔══██╗██╔════╝░██╔══██╗
█████╗░░██║██╔████╔██║  ██║░░██║█████╗░░  ░░░░░██║██║░░██║██║░░██╗░██║░░██║
██╔══╝░░██║██║╚██╔╝██║  ██║░░██║██╔══╝░░  ██╗░░██║██║░░██║██║░░╚██╗██║░░██║
██║░░░░░██║██║░╚═╝░██║  ██████╔╝███████╗  ╚█████╔╝╚█████╔╝╚██████╔╝╚█████╔╝
╚═╝░░░░░╚═╝╚═╝░░░░░╚═╝  ╚═════╝░╚══════╝  ░╚════╝░░╚════╝░░╚═════╝░░╚════╝░");

            GoOn();
        }

        public static void Victory(string word, string letters, int errors, int attempts)
        {
            Console.Clear();
            Console.WriteLine(@"
██████╗░░█████╗░██████╗░░█████╗░██████╗░███████╗███╗░░██╗░██████╗██╗██╗██╗
██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝████╗░██║██╔════╝██║██║██║
██████╔╝███████║██████╔╝███████║██████╦╝█████╗░░██╔██╗██║╚█████╗░██║██║██║
██╔═══╝░██╔══██║██╔══██╗██╔══██║██╔══██╗██╔══╝░░██║╚████║░╚═══██╗╚═╝╚═╝╚═╝
██║░░░░░██║░░██║██║░░██║██║░░██║██████╦╝███████╗██║░╚███║██████╔╝██╗██╗██╗
╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░╚═╝╚═╝╚═╝");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Você descobriu a palavra em {attempts} tentativas!");
            Console.WriteLine($"Quantidade de erros: {errors}");
            Console.WriteLine("Tentou as letras:");
            foreach (char letter in letters) Console.Write($"{letter} ");
            Console.WriteLine();
            Console.WriteLine();
            RevealWord(word);
        }

        public static void RevealWord(string word)
        {
            Console.WriteLine($"E a palavra era... {word.ToUpper()}!");
            GoOn();
        }

        public static void GoOn(string question = null)
        {
            Console.WriteLine();
            Console.WriteLine(question == null ? "Aperte qualquer tecla para continuar..." : $"{question}");
            Console.ReadLine();
            Console.Clear();
        }

        public static bool ReadYesOrNo(string question)
        {
            Console.WriteLine();
            Console.WriteLine($"{question}? (s/n)");

            while (true)
            {
                string input = Console.ReadLine()?.ToLower();

                if (Regex.IsMatch(input, "^(s(im)?|n(ao|ão)|n(ao)?o?)$")) return input.StartsWith("s");

                Console.WriteLine("Entrada inválida.");
                Console.WriteLine($"{question} ? (s / n)");
                Console.WriteLine();
            }
        }

        public static int ReadOption(int min, int max)
        {
            bool valid = false;
            int number = 0;

            while (!valid)
            {
                Console.WriteLine();
                Console.WriteLine("Digite uma opção: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number >= min && number <= max) valid = true;
                    else
                    {
                        Console.WriteLine($"Digite um número entre {min} e {max}");
                    }
                }
                else Console.WriteLine("Digite um número válido");
            }

            return number;
        }

        public static char ReadChar()
        {
            bool valid = false;
            char c = 'X';

            while(!valid)
            {
                Console.WriteLine();
                Console.WriteLine("Digite uma letra: ");
                string input = Console.ReadLine();

                if (input.Length == 1 && char.TryParse(input, out c) && char.IsLetter(c))
                    valid = true;
                else Console.WriteLine("Entrada inválida. Por favor digite apenas um caractere.");
            }

            return c;
        }
    }
}
