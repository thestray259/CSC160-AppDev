using System;
using System.Collections.Generic;
using MasterMindLibrary;

namespace MasterMind
{
    class Program
    {
        static List<Peg> pegList = new List<Peg>()
        {
            new Peg(ConsoleColor.White, ConsoleColor.Red),
            new Peg(ConsoleColor.White, ConsoleColor.Blue),
            new Peg(ConsoleColor.Black, ConsoleColor.Green),
            new Peg(ConsoleColor.Black, ConsoleColor.Yellow),
            new Peg(ConsoleColor.Black, ConsoleColor.Cyan),
            new Peg(ConsoleColor.White, ConsoleColor.Magenta),
            new Peg(ConsoleColor.White, ConsoleColor.DarkGray),
            new Peg(ConsoleColor.White, ConsoleColor.DarkRed)
        };

        static void Main(string[] args)
        {
            List<Attempt> allAttempts = new List<Attempt>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Mastermind!");
            Console.ResetColor();

            //ask for difficulty
            Console.WriteLine("Choose Difficulty: "); 
            int difficulty = MMLib.GetConsoleMenu(new List<string> { "Easy - 4 Colors ", "Medium - 6 Colors ", "Hard - 8 Colors " });

            //ask for maxTurns of turns to guess it
            int maxTurns = MMLib.GetConsoleInt("How Many Attempts (1-50)? ", 1, 50);

            //store the maxPegs based on difficulty
            int maxPegs = (difficulty * 2) + 2;

            //Generate an answer
            List<int> answer = MMLib.GenerateAnswer(maxPegs); 

            //show cheat? 
            MMLib.Cheat(answer, pegList);

            //loop while !gameWon && maxTurns != 0
            //  get user attempt
            //  Check the attempt for a correct guess
            //  add the attempt to the attempt list
            //  determin if the game has been won or not
            //  reduce the maxTurns

            bool gameWon = false; 
            do
            {
                Attempt attempt = GetAttemptFromUser(maxPegs, allAttempts, maxTurns);
                CheckAttempt(attempt, answer);

                // add attempt to attempt list 
                //attempt.AttemptList.Add(attempt); 
                allAttempts.Add(attempt); 

                if (attempt.AttemptList == answer) gameWon = true;

                maxTurns--; 
            }
            while (!gameWon && maxTurns != 0);

            //If won, display Game Won!
            //If lost, show game loss
            //show the correct answer

            if (gameWon == true)
            {
                Console.WriteLine(""); 
                Console.WriteLine("Game Won! "); 
            }
            else if (gameWon == false)
            {
                Console.WriteLine(""); 
                Console.WriteLine("Game Lost :(");
                MMLib.ShowAnswer(answer, pegList, ""); 
            }
        }

        static Attempt GetAttemptFromUser(int maxPegs, List<Attempt> allAttempts, int maxTurns)
        {
            //Create a new Attempt
            //Get color options based on maxPegs
            //Loop of # of pegs they need to choose
            //      clear console
            //      Display # of attempts left
            //      Show all previous attempts
            //      Show pegs they have chosen already in this attempt
            //      Ask them to pick a peg color from a menu of options
            //      Add the chosen peg to the Attempt.AttemptList
            //Return the attempt when done

            Attempt attempt = new Attempt();
            // get color options based on maxPegs 
            Console.WriteLine("Color Options: ");
            //Console.WriteLine(colorOptions); 

            for (int i = 0; i < maxPegs; i++)
            {
                Console.Clear();

                Console.WriteLine("Number of Attempts Left: " + maxTurns);

                if (allAttempts.Count <= 0) Console.WriteLine("Previous Attemps: None Yet");
                else Console.WriteLine("Previous Attemps: ");
                for (int k = 0; k < allAttempts.Count; k++)
                {
                    Console.WriteLine(allAttempts[k]); 
                }

                MMLib.ShowChosenPegs(attempt, pegList); 

                // ask to pick peg from a menu of options 
                Console.WriteLine("Choose A Color From The Following Options: "); 
                List<string> colorOptions = MMLib.GetColorOptions(maxPegs, pegList);
                for (int j = 0; j < colorOptions.Count; j++)
                {
                    Console.WriteLine(j + " - " + colorOptions[j]);
                }

                // add chosen peg to attempt.Attemptlist
                int peg = MMLib.GetConsoleInt("Choose A Color From The Options. ", 0, maxPegs);
                attempt.AttemptList.Add(peg);
            }

            return attempt;
        }


        static void CheckAttempt(Attempt attempt, List<int> answer)
        {
            //Check the attempt.AttemptList to see if they got a match to the answer
            //If a peg is correct, increment the attempt.CorrectAnswerCount

            if (attempt.AttemptList == answer)
            {
                attempt.CorrectAnswerCount++;
                Console.WriteLine(attempt.CorrectAnswerCount);
            }
        }
    }
}
