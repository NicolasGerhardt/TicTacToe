using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Board
    {
        public string[] Squares { get; private set; }

        public Board()
        {
            Squares = new string[] {
                "7", "8", "9",
                "4", "5", "6",
                "1", "2", "3"
            };
        }

        public bool TryUpdateSquare(string input, Game.Players player)
        {
            string digits1thru9Pattern = @"^[1-9]$";
            if (!Regex.IsMatch(input, digits1thru9Pattern)) return false;

            for (int i = 0; i < Squares.Length; i++)
            {
                if (Squares[i].Contains(input))
                {
                    Squares[i] = player.ToString();
                    return true;
                }
            }

            return false;
        }



        public bool Is3InARow(string mark, int v1, int v2, int v3)
        {
            if (Squares[v1].Contains(mark) && Squares[v2].Contains(mark) && Squares[v3].Contains(mark)) return true;
            return false;
        }

        public override string ToString()
        {
            string output = string.Empty;
            output += $"\t[{Squares[0]}][{Squares[1]}][{Squares[2]}]\n";
            output += $"\t[{Squares[3]}][{Squares[4]}][{Squares[5]}]\n";
            output += $"\t[{Squares[6]}][{Squares[7]}][{Squares[8]}]";
            return output;
        }
    }
}
