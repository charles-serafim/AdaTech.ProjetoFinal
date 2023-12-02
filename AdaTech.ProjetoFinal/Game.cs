using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdaTech.ProjetoFinal
{
    internal class Game : Utils
    {
        static WordList wordList = new WordList();
        public void Execute()
        {
            ShowInstructions();

            bool repeat = true;
            while (repeat)
            {
                StartGame();
                repeat = ReadYesOrNo("Jogar novamente");
            }

            GoOn("Aperte qualquer tecla para encerrar...");
        }

        // Método que introduz as regras do jogo
        private static void ShowInstructions()
        {
            Console.Clear();

            Console.WriteLine(@"
   _                                                    _   
 /x x\                                                /x x\ 
 \ ^ /    ███████╗░█████╗░██████╗░░█████╗░░█████╗░    \ ^ / 
  _|_     ██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗     _|_  
 / | \    █████╗░░██║░░██║██████╔╝██║░░╚═╝███████║    / | \ 
/  |  \   ██╔══╝░░██║░░██║██╔══██╗██║░░██╗██╔══██║   /  |  \
   |      ██║░░░░░╚█████╔╝██║░░██║╚█████╔╝██║░░██║      |   
  / \     ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝     / \  
_/   \_                                              _/   \_

");

            Console.WriteLine("Este é o Jogo da Forca!");
            Console.WriteLine();

            Console.WriteLine("REGRAS");
            Console.WriteLine("1. Tente adivinhar a palavra");
            Console.WriteLine("2. Chute uma letra");
            Console.WriteLine("3. Se a letra existir na palavra, ela será exibida nas posições correspondentes");
            Console.WriteLine("4. Se a letra não existir, o total de erros aumentará e uma parte a mais do boneco será colocada na forca");
            Console.WriteLine("5. O jogo termina quando a palavra é adivinhada corretamente");
            Console.WriteLine("6. Ou quando a quantidade máxima de tentativas é atingida");
            Console.WriteLine("7. Isso significa que seu boneco foi enforcado!!! MORREU!!! GAME OVER!!!");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para começar...");
            Console.ReadLine();
        }

        // Método que realiza cada iteração da execução do jogo
        private static void StartGame()
        {
            Console.Clear();

            string[] word = wordList.ChooseWord();
            string letters = "";
            int errors = 0;
            int attempts = 0;

            Run(word, letters, errors, attempts);
        }

        private static void Run(string[] word, string letters, int errors, int attempts)
        {
            char letter;
            bool victory = false;
            StringBuilder lettersBuilder = new StringBuilder(letters);

            while (errors < 7)
            {
                // encerra o jogo caso o jogador adivinhe a palavra
                if (victory)
                {
                    Victory(word[1], letters, errors, attempts);
                    break;
                }

                PrintGameScreen(word, letters, errors);

                // recebe entrada do usuário
                if (errors < 6)
                {
                    letter = ReadChar();

                    // adiciona a entrada do usuário à string que armazena o historico
                    if (!letters.Contains(char.ToUpper(letter)))
                    {
                        lettersBuilder.Append(char.ToUpper(letter));
                        letters = lettersBuilder.ToString();
                    }
                    else
                    {
                        PrintRepeatedLetterMessage(char.ToUpper(letter));
                        continue;
                    }

                    if (!VerifyLetter(word[3].ToUpper(), char.ToUpper(letter))) errors++;

                    victory = VerifyAllLetters(word[3].ToUpper(), letters);
                }
                // exibe tela de Game Over
                else
                {
                    GameOver(word[1]);
                    break;
                }

                Console.WriteLine(word[1]);
                Console.WriteLine(word[1].ToUpper());

                attempts++;
            }
        }

        private static void PrintGameScreen(string[] word, string letters, int errors)
        {
            Console.Clear();
            Console.WriteLine($"Categoria: {word[0]}");
            if(word[0] == "Palavra aleatória") Console.WriteLine($"Definição do dicionário: {word[2]}");

            Console.Write($"Tentativas: ");
            foreach (char letter in letters)
            {
                Console.Write($"{letter} ");
            }
            Console.WriteLine();

            PrintLittlePerson(errors);

            Console.Write("| ");
            foreach (char letter in word[3])
            {
                Console.Write(letters.Contains(char.ToUpper(letter)) ? $"{char.ToUpper(letter)} " : "_ ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Tentativas restantes: {6 - errors}");
        }

        private static void PrintRepeatedLetterMessage(char letter)
        {
            Console.Clear();
            Console.WriteLine($"Você já tentou a letra \"{letter}\"! Digite outra letra.");
            Console.ReadLine();
        }

        private static bool VerifyAllLetters(string word, string letters)
        {
            foreach (char letter in word)
            {
                if (!letters.Contains(letter)) return false;
            }
            return true;
        }

        private static bool VerifyLetter(string word, char letter)
        {
            if (!word.Contains(letter)) return false;
            return true;
        }
    }
}