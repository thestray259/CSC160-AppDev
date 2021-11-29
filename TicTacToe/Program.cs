using System;

namespace TicTacToe
{
    class Program
    {
        static int flag = 0; 
        static void Main(string[] args)
        {                        
            bool done = false;
            //bool wasATie = false;
            Console.WriteLine(); 
            do
            {
                // display game board
                Board.DisplayBoard(); 

                // game code here 
                int intChosenRow;
                int intChosenCol;
                bool validInput = false;
                do
                {
                    if (Player.turn == 0 || Player.turn % 2 == 0)
                    {
                        // player1 
                        Console.WriteLine("{0} enter Row (0-2): ", Player.aryPlayerNames[0]);
                        bool validRow = int.TryParse(Console.ReadLine(), out intChosenRow);

                        Console.WriteLine("{0} enter Column (0-2): ", Player.aryPlayerNames[0]);
                        bool validCol = int.TryParse(Console.ReadLine(), out intChosenCol);

                        // check if valid 
                        if (intChosenRow < 0 || intChosenRow > 2 || intChosenCol < 0 || intChosenCol > 2)
                        {
                            Console.WriteLine("Invalid. Try again. "); 
                        }
                        else if ((Board.aryBoard[intChosenRow, intChosenCol] == Player.aryPlayerSymbols[0]) || (Board.aryBoard[intChosenRow, intChosenCol] == Player.aryPlayerSymbols[1]))
                        {
                            Console.WriteLine("Spot taken. Try again.");
                        }
                        else if (Board.aryBoard[intChosenRow, intChosenCol] != Player.aryPlayerSymbols[0] || Board.aryBoard[intChosenRow, intChosenCol] != Player.aryPlayerSymbols[1])
                        {
                            if (intChosenRow >= 1 || intChosenRow <= 3 || intChosenCol >= 1 || intChosenCol <= 3)
                            {
                                // set game piece and go to next turn. 
                                Board.aryBoard[intChosenRow, intChosenCol] = Player.aryPlayerSymbols[0];

                                Player.turn++;
                                validInput = true;
                            }
                            else if (intChosenRow < 0 || intChosenRow > 2 || intChosenCol < 0 || intChosenCol > 2)
                            {
                                // invalid 
                                Console.WriteLine("Invalid. Try again. ");
                            }
                        }
                    }
                    else
                    {
                        // player2
                        Console.WriteLine("{0} enter Row (0-2): ", Player.aryPlayerNames[1]);
                        bool validRow = int.TryParse(Console.ReadLine(), out intChosenRow);

                        Console.WriteLine("{0} enter Column (0-2): ", Player.aryPlayerNames[1]);
                        bool validCol = int.TryParse(Console.ReadLine(), out intChosenCol);

                        // check if valid 
                        if (intChosenRow < 0 || intChosenRow > 2 || intChosenCol < 0 || intChosenCol > 2)
                        {
                            Console.WriteLine("Invalid. Try again. ");
                        }
                        else if ((Board.aryBoard[intChosenRow, intChosenCol] == Player.aryPlayerSymbols[0]) || (Board.aryBoard[intChosenRow, intChosenCol] == Player.aryPlayerSymbols[1]))
                        {
                            Console.WriteLine("Spot taken. Try again.");
                        }
                        else if (Board.aryBoard[intChosenRow, intChosenCol] != Player.aryPlayerSymbols[0] || Board.aryBoard[intChosenRow, intChosenCol] != Player.aryPlayerSymbols[1])
                        {
                            if (intChosenRow >= 1 || intChosenRow <= 3 || intChosenCol >= 1 || intChosenCol <= 3)
                            {
                                // set game piece and go to next turn. 
                                Board.aryBoard[intChosenRow, intChosenCol] = Player.aryPlayerSymbols[1];

                                Player.turn++;
                                validInput = true;
                            }
                            else if (intChosenRow < 0 || intChosenRow > 2 || intChosenCol < 0 || intChosenCol > 2)
                            {
                                // invalid 
                                Console.WriteLine("Invalid. Try again. ");
                            } 
                        }
                    }

                }
                while (!validInput);

                // if tie, say game was a tie 
                // else, winner is...
                flag = Player.CheckWin();
                if (flag == 1 || flag == -1) done = true; 

            } 
            while (!done);

            Board.DisplayBoard(); 

            if (flag == 1) Console.WriteLine("Player {0} won!", Player.FindWinner());
            else if (flag == -1) Console.WriteLine("Tie. No one wins :(");
            else Console.WriteLine("Error"); 
        }
    }
}
