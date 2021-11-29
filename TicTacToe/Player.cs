using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        // Player names 
        static public string[] aryPlayerNames = { "{Player 1}", "{Player 2}" };

        // Symbols associated with players
        static public char[] aryPlayerSymbols = { 'X', 'O' };

        // Whose turn 
        static public int turn = 0;

        static public string FindWinner()
        {
            if (Player.turn == 0 || Player.turn % 2 == 0)
            {
                return aryPlayerNames[1];
            }
            else return aryPlayerNames[0]; 
        }

        // win conditions 
        public static int CheckWin()
        {
            // horizontal 
            /*            if (Board.aryBoard[0, 0] == Board.aryBoard[0, 1] && Board.aryBoard[0, 1] == Board.aryBoard[0, 2])
                        {
                            return 1; 
                        }
                        else if (Board.aryBoard[1, 0] == Board.aryBoard[1, 1] && Board.aryBoard[1, 1] == Board.aryBoard[1, 2])
                        {
                            return 1;
                        }
                        else if (Board.aryBoard[2, 0] == Board.aryBoard[2, 1] && Board.aryBoard[2, 1] == Board.aryBoard[2, 2])
                        {
                            return 1;
                        }

                        // vertical 
                        else if (Board.aryBoard[0, 0] == Board.aryBoard[1, 0] && Board.aryBoard[1, 0] == Board.aryBoard[2, 0])
                        {
                            return 1; 
                        }
                        else if (Board.aryBoard[0, 1] == Board.aryBoard[1, 1] && Board.aryBoard[1, 1] == Board.aryBoard[2, 1])
                        {
                            return 1;
                        }
                        else if (Board.aryBoard[0, 2] == Board.aryBoard[1, 2] && Board.aryBoard[1, 2] == Board.aryBoard[2, 2])
                        {
                            return 1;
                        }

                        // diagonal 
                        else if (Board.aryBoard[0, 0] == Board.aryBoard[1, 1] && Board.aryBoard[1, 1] == Board.aryBoard[2, 2])
                        {
                            return 1; 
                        }
                        else if (Board.aryBoard[0, 2] == Board.aryBoard[1, 1] && Board.aryBoard[1, 1] == Board.aryBoard[2, 0])
                        {
                            return 1; 
                        }

                        // check for draw 
                        else if (Player.turn >= 8)
                        {
                            return -1; 
                        }
                        else
                        {
                            return 0; 
                        }*/


            // 2nd win condition try 
            // X horizontal 
            if (Board.aryBoard[0, 0] == aryPlayerSymbols[0] && Board.aryBoard[0, 1] == aryPlayerSymbols[0] && Board.aryBoard[0, 2] == aryPlayerSymbols[0])
            {
                return 1;
            }
            else if (Board.aryBoard[1, 0] == aryPlayerSymbols[0] && Board.aryBoard[1, 1] == aryPlayerSymbols[0] && Board.aryBoard[1, 2] == aryPlayerSymbols[0])
            {
                return 1;
            }
            else if (Board.aryBoard[2, 0] == aryPlayerSymbols[0] && Board.aryBoard[2, 1] == aryPlayerSymbols[0] && Board.aryBoard[2, 2] == aryPlayerSymbols[0])
            {
                return 1;
            }

            // X verical 
            else if (Board.aryBoard[0, 0] == aryPlayerSymbols[0] && Board.aryBoard[1, 0] == aryPlayerSymbols[0] && Board.aryBoard[2, 0] == aryPlayerSymbols[0])
            {
                return 1;
            }
            else if (Board.aryBoard[0, 1] == aryPlayerSymbols[0] && Board.aryBoard[1, 1] == aryPlayerSymbols[0] && Board.aryBoard[2, 1] == aryPlayerSymbols[0])
            {
                return 1;
            }
            else if (Board.aryBoard[0, 2] == aryPlayerSymbols[0] && Board.aryBoard[1, 2] == aryPlayerSymbols[0] && Board.aryBoard[2, 2] == aryPlayerSymbols[0])
            {
                return 1;
            }

            // X diagonal 
            else if (Board.aryBoard[0, 0] == aryPlayerSymbols[0] && Board.aryBoard[1, 1] == aryPlayerSymbols[0] && Board.aryBoard[2, 2] == aryPlayerSymbols[0])
            {
                return 1;
            }
            else if (Board.aryBoard[0, 2] == aryPlayerSymbols[0] && Board.aryBoard[1, 1] == aryPlayerSymbols[0] && Board.aryBoard[2, 0] == aryPlayerSymbols[0])
            {
                return 1;
            }

            // O horizontal 
            if (Board.aryBoard[0, 0] == aryPlayerSymbols[1] && Board.aryBoard[0, 1] == aryPlayerSymbols[1] && Board.aryBoard[0, 2] == aryPlayerSymbols[1])
            {
                return 1;
            }
            else if (Board.aryBoard[1, 0] == aryPlayerSymbols[1] && Board.aryBoard[1, 1] == aryPlayerSymbols[1] && Board.aryBoard[1, 2] == aryPlayerSymbols[1])
            {
                return 1;
            }
            else if (Board.aryBoard[2, 0] == aryPlayerSymbols[1] && Board.aryBoard[2, 1] == aryPlayerSymbols[1] && Board.aryBoard[2, 2] == aryPlayerSymbols[1])
            {
                return 1;
            }

            // O vertical 
            else if (Board.aryBoard[0, 0] == aryPlayerSymbols[1] && Board.aryBoard[1, 0] == aryPlayerSymbols[1] && Board.aryBoard[2, 0] == aryPlayerSymbols[1])
            {
                return 1;
            }
            else if (Board.aryBoard[0, 1] == aryPlayerSymbols[1] && Board.aryBoard[1, 1] == aryPlayerSymbols[1] && Board.aryBoard[2, 1] == aryPlayerSymbols[1])
            {
                return 1;
            }
            else if (Board.aryBoard[0, 2] == aryPlayerSymbols[1] && Board.aryBoard[1, 2] == aryPlayerSymbols[1] && Board.aryBoard[2, 2] == aryPlayerSymbols[1])
            {
                return 1;
            }

            // O diagonal 
            else if (Board.aryBoard[0, 0] == aryPlayerSymbols[1] && Board.aryBoard[1, 1] == aryPlayerSymbols[1] && Board.aryBoard[2, 2] == aryPlayerSymbols[1])
            {
                return 1;
            }
            else if (Board.aryBoard[0, 2] == aryPlayerSymbols[1] && Board.aryBoard[1, 1] == aryPlayerSymbols[1] && Board.aryBoard[2, 0] == aryPlayerSymbols[1])
            {
                return 1;
            }

            // tie 
            else if ((Board.aryBoard[0, 0] == aryPlayerSymbols[0] || Board.aryBoard[0, 0] == aryPlayerSymbols[1]) && (Board.aryBoard[0, 1] == aryPlayerSymbols[0] || Board.aryBoard[0, 1] == aryPlayerSymbols[1]) && (Board.aryBoard[0, 2] == aryPlayerSymbols[0] || Board.aryBoard[0, 2] == aryPlayerSymbols[1]) &&
                     (Board.aryBoard[1, 0] == aryPlayerSymbols[0] || Board.aryBoard[1, 0] == aryPlayerSymbols[1]) && (Board.aryBoard[1, 1] == aryPlayerSymbols[0] || Board.aryBoard[1, 1] == aryPlayerSymbols[1]) && (Board.aryBoard[1, 2] == aryPlayerSymbols[0] || Board.aryBoard[1, 2] == aryPlayerSymbols[1]) &&
                     (Board.aryBoard[2, 0] == aryPlayerSymbols[0] || Board.aryBoard[2, 0] == aryPlayerSymbols[1]) && (Board.aryBoard[2, 1] == aryPlayerSymbols[0] || Board.aryBoard[2, 1] == aryPlayerSymbols[1]) && (Board.aryBoard[2, 2] == aryPlayerSymbols[0] || Board.aryBoard[2, 2] == aryPlayerSymbols[1]))
            {
                return -1;
            }

            // continue 
            else
            {
                return 0;
            }
        }
    }
}
