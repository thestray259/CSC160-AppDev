using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        // grid, default value for char is space
        static public char[,] aryBoard = new char[3, 3];
        

        static public void DisplayBoard()
        {
            Console.WriteLine(" ");
            Console.WriteLine("-----------");
            for (int row = 0; row < aryBoard.GetLength(0); row++)
            {
                for (int col = 0; col < aryBoard.GetLength(1); col++)
                {
                    Console.Write(" {0} ", aryBoard[row, col]);
                    Console.Write("|");
                }
                Console.WriteLine();

                Console.Write("-----------");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
