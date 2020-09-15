using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.Title = "TicTacToe Game";
            Console.SetWindowSize(70, 30);

            Menu();

            int optionPick = 0;

            do
            {
                try
                {
                    Console.Write("Pick an option: ");
                    optionPick = int.Parse(Console.ReadLine());
                    
                    if (optionPick == 2)
                    {
                        EndScreen();
                        return;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect, please pick a number (1 or 2)!");
                }
            } while (optionPick <= 0 || optionPick >= 3);


            bool wishToPlayAgain = false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("What's your name, player1?-->");
            string playerOneName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("What's your name, player2?-->");
            string playerTwoName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{playerOneName} is X!");
            Console.WriteLine($"{playerTwoName} is O!");

            GameGenerator gameGenerator = new GameGenerator(playerOneName, playerTwoName);

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("How many games do you want to play?-->");

                int gameCounter = int.Parse(Console.ReadLine());
                int i = 1;

                while (i <= gameCounter)
                {
                    gameGenerator.GenerateGrid();
                    i++;
                }

                Console.WriteLine(gameGenerator.ToString());

                //asking the players if they want to do another game
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Do you want to continue? (y/n): ");
                char choice = char.Parse(Console.ReadLine().ToLower());

                if (choice == 'y')
                    wishToPlayAgain = true;
                else if (choice == 'n')
                    wishToPlayAgain = false;

            } while (wishToPlayAgain);

            EndScreen();
        }

        static void EndScreen()
        {
            //making the background white with black text
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("Thanks for playing!\n");

            Console.ReadLine();
        }

        static void Menu()
        {
            Console.WriteLine("#######################");
            Console.WriteLine("# Welcome to my game! #");
            Console.WriteLine("#######################");
            Console.WriteLine("\n1. Start");
            Console.WriteLine("2. Exit\n");
        }
    }
}
