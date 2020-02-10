using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        public Board GameBoard { get; set; }
        public bool GameOver { get; set; }
        public Players CurrentPlayer { get; set; }
        public enum Players
        {
            X, O
        }

        public Game()
        {
            GameOver = false;
            CurrentPlayer = Players.X;
            GameBoard = new Board();
        }

        public void Loop()
        {
            while (!GameOver)
            {
                Console.WriteLine(GameBoard);
                Console.WriteLine();
                Console.WriteLine($"It is currently {CurrentPlayer}'s Turn");
                Console.Write("Pick a square: ");
                string input = Console.ReadLine();
                Console.Clear();
                if (GameBoard.TryUpdateSquare(input, CurrentPlayer))
                {
                    Console.WriteLine($"Excellent choice {CurrentPlayer}");

                }
                else
                {
                    Console.WriteLine($"Nice Try {CurrentPlayer}, but that is an invalid choice.");
                }

                if (IsPlayerAWinner(CurrentPlayer))
                {
                    Console.WriteLine($"{CurrentPlayer} WINS!!");
                    Console.WriteLine(GameBoard);
                    GameOver = true;
                }
                else
                {
                    Console.WriteLine();
                    SwitchUserTurn();
                }

            }
        }

        private bool IsPlayerAWinner(Players currentPlayer)
        {
            bool isAWinner = false;
            string playerMark = currentPlayer.ToString();
            // Diagonal 
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 0, 4, 8);
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 2, 4, 6);
            // Rows
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 0, 1, 2);
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 3, 4, 5);
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 6, 7, 8);
            // Cols
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 0, 3, 6);
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 1, 4, 7);
            isAWinner = isAWinner || GameBoard.Is3InARow(playerMark, 2, 5, 8);

            return isAWinner;
        }

        private void SwitchUserTurn()
        {
            if (CurrentPlayer == Players.X)
            {
                CurrentPlayer = Players.O;
            }
            else
            {
                CurrentPlayer = Players.X;
            }
        }
    }
}
