using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacGame
{
    public class GameGenerator
    {
        private const int rows = 3;
        private const int cols = 3;

        private string player1;
        private string player2;

        public GameGenerator(string player1, string player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
        }

        public string Player1
        {
            get { return player1; }
            set 
            {
                if (value.Length <= 0)
                {
                    value = "player1";
                }
                player1 = value; 
            }
        }

        public string Player2
        {
            get { return player2; }
            set
            {
                if (value.Length <= 0)
                {
                    value = "player2";
                }
                player2 = value; 
            }
        }

        int turns = 0;
        int count = 0;

        public int playerOneWinCounter = 0;
        public int playerTwoWinCounter = 0;

        int gameCount = 1;

        public void GenerateGrid()
        {
            char[,] matrix = new char[rows, cols];

            bool isWinn = false;
            //bool isDraw = false;

            char symbol = ' ';
            bool isDraw = false;

            Print(matrix, isWinn, isDraw, symbol);

            while (isWinn == false)
            {
                if (turns == 0)
                {
                    symbol = 'X';
                }
                else if (turns == 1)
                {
                    symbol = 'O';
                }

                //Player1's turn
                if (turns == 0)
                {
                    ChooseSpot(matrix, symbol);

                    isWinn = IsWinning(matrix, symbol);
                    isDraw = IsDraw(matrix, symbol);

                    Print(matrix, isWinn, isDraw, symbol);

                    if (isWinn || isDraw)
                        break;
                }
                //Player2's turn
                else if (turns == 1)
                {
                    ChooseSpot(matrix, symbol);

                    isWinn = IsWinning(matrix, symbol);
                    isDraw = IsDraw(matrix, symbol);

                    Print(matrix, isWinn, isDraw, symbol);

                    if (isWinn || isDraw)
                        break;
                }
            }

            //The current game count we are playing right now
            gameCount++;
        }

        private void ChooseSpot(char[,] matrix, char symbol)
        {
            Console.WriteLine("|7|8|9|\n|4|5|6|\n|1|2|3|\n");

            if (symbol == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"It's {this.Player1}'s turn: ");
            }
            else if (symbol == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"It's {this.Player2}'s turn: ");
            }

            Console.Write("Pick a spot: ");
            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect number, try again!");
                Console.ReadLine();
            }

            do
            {
                if (choice == 1)
                {
                    if (matrix[2, 0] != 'X'
                        && matrix[2, 0] != 'O')
                    {
                        matrix[2, 0] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }
                else if (choice == 2)
                {
                    if (matrix[2, 1] != 'X'
                        && matrix[2, 1] != 'O')
                    {
                        matrix[2, 1] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }

                }
                else if (choice == 3)
                {
                    if (matrix[2, 2] != 'X'
                        && matrix[2, 2] != 'O')
                    {
                        matrix[2, 2] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }
                else if (choice == 4)
                {
                    if (matrix[1, 0] != 'X'
                        && matrix[1, 0] != 'O')
                    {
                        matrix[1, 0] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }
                else if (choice == 5)
                {
                    if (matrix[1, 1] != 'X'
                       && matrix[1, 1] != 'O')
                    {
                        matrix[1, 1] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }
                else if (choice == 6)
                {
                    if (matrix[1, 2] != 'X'
                        && matrix[1, 2] != 'O')
                    {
                        matrix[1, 2] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }
                else if (choice == 7)
                {
                    if (matrix[0, 0] != 'X'
                        && matrix[0, 0] != 'O')
                    {
                        matrix[0, 0] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }
                else if (choice == 8)
                {
                    if (matrix[0, 1] != 'X'
                       && matrix[0, 1] != 'O')
                    {
                        matrix[0, 1] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }
                else if (choice == 9)
                {
                    if (matrix[0, 2] != 'X'
                    && matrix[0, 2] != 'O')
                    {
                        matrix[0, 2] = symbol;

                        if (turns == 0)
                            turns++;
                        else if (turns == 1)
                            turns--;

                        count++;
                    }
                }

            } while (choice <= 0 && choice >= 10);
        }

        private bool IsWinning(char[,] matrix, char symbol)
        {
            //diagonals... possible win scenarios
            if (matrix[0, 0] == symbol
            && matrix[1, 1] == symbol
            && matrix[2, 2] == symbol)
                return true;

            else if (matrix[2, 0] == symbol
            && matrix[1, 1] == symbol
            && matrix[0, 2] == symbol)
                return true;


            //Rows... possible win scenarios
            //First row
            else if (matrix[0, 0] == symbol
            && matrix[0, 1] == symbol
            && matrix[0, 2] == symbol)
                return true;

            //Second row
            else if (matrix[1, 0] == symbol
            && matrix[1, 1] == symbol
            && matrix[1, 2] == symbol)
                return true;

            //And third row
            else if (matrix[2, 0] == symbol
            && matrix[2, 1] == symbol
            && matrix[2, 2] == symbol)
                return true;

            //Cols...possible win scenarios
            //First column
            else if (matrix[0, 0] == symbol
            && matrix[1, 0] == symbol
            && matrix[2, 0] == symbol)
                return true;

            //Second column
            else if (matrix[0, 1] == symbol
            && matrix[1, 1] == symbol
            && matrix[2, 1] == symbol)
                return true;

            //Third column
            else if (matrix[0, 2] == symbol
            && matrix[1, 2] == symbol
            && matrix[2, 2] == symbol)
                return true;

            return false;
        }

        private bool IsDraw(char[,] matrix, char symbol)
        {
            if (count >= 9)
            {
                if (!IsWinning(matrix, symbol))
                    return true;
            }

            return false;
        }

        void Decision(char symbol)
        {
            if (symbol == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{this.Player1}] wins!");
                playerOneWinCounter++;
            }
            else if (symbol == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[{this.Player2}] wins!");
                playerTwoWinCounter++;
            }
        }

        private void Print(char[,] matrix, bool isWinn, bool isDraw, char symbol)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"GAME {gameCount}!\n");

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"|{matrix[row, col]}|");
                }
                Console.WriteLine();
            }

            if (isWinn)
            {
                Decision(symbol);
                count = 0;
                Console.ReadLine();
            }
            else if (isDraw)
            {
                Console.WriteLine("Draw!");
                count = 0;
                Console.ReadLine();
            }

            Console.WriteLine($"\n{this.Player1}: {playerOneWinCounter}         {this.Player2}: {playerTwoWinCounter}\n");
        }

        public override string ToString()
        {
            string winner = "";

            if (playerOneWinCounter > playerTwoWinCounter)
            {
                winner = this.Player1;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (playerOneWinCounter < playerTwoWinCounter)
            {
                winner = this.Player2;
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                winner = "No one, it's Draw!";
                Console.ForegroundColor = ConsoleColor.Magenta;
            }

            return $"\n[{this.Player1}] has scored: {playerOneWinCounter}!\n[{this.Player2}] has scored: {playerTwoWinCounter}!\n\nAnd the winner is: [{winner}] :)";
        }
    }
}
