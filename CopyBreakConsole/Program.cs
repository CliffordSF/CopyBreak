using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brooks.ennuiWare.CopyBreak.Engine;
using System.Threading;


namespace Brooks.ennuiWare.CopyBreak.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {

            string copyBreakLetter = "";
            int sourceStackChoice = 0;
            int destinationStackChoice;
            string cardIdentity;
            Card rcard;
            string InputName = "Cliff"; //USING A DEFAULT BECUASE THIS ISN'T REQUESTED IN TERMINAL PRG -- FIX
         

            Console.WriteLine("Welcome to CopyBreak.");
            Game game = new Game("Blue", InputName, "foo");

            game.Start();

            do
            {
                DrawHand(game.Hand);

                // ask user where to move from
                Console.WriteLine("Please enter the source stack (or 0 to end game, b to bank a word, or t to end a turn): ");
                String choice = Console.ReadLine();
                if (choice == "t" || choice == "T")
                {
                    game.Turn();
                }
                else if (choice == "b" || choice == "B")
                {
                    Console.WriteLine("Please enter the line number of the word to bank: ");
                    string wordToBank = Console.ReadLine();
                    int wordToBankInt = Convert.ToInt32(wordToBank);

                    //convert wordToBankInt to a string
                    bool wasChallengeWord;
                    if (game.Turn(wordToBankInt, out wasChallengeWord))
                    {
                        Console.Write("Your current score is: {0}.", game.CurrentScore);
                        Thread.Sleep(3000);
                        Console.WriteLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a valid word!", wordToBank);
                        Console.WriteLine();
                    }

                }
                else
                {
                    //Check to see if the selected card is CopyBreak
                    sourceStackChoice = Convert.ToInt32(choice) - 1;
                    cardIdentity = game.Hand.Columns[sourceStackChoice].Word; // Checked and this returns letter

                    if (cardIdentity == "CopyBreak")
                    {
                        Console.WriteLine("What letter do you want the CopyBreak card to represent?");
                        ConsoleKeyInfo copyBreakReplacementLetter = Console.ReadKey();
                        Console.WriteLine();
                        Letter replacementCardLetter = (Letter)Enum.Parse(typeof(Letter), copyBreakReplacementLetter.KeyChar.ToString(), true);
                        Stack.CopyBreakLetter = replacementCardLetter;

                    }

                    if (sourceStackChoice == -1)
                    {
                        break;
                    }

                    // ask user where to move to
                    Console.WriteLine("Please enter the destination stack or type 0 to end the game: ");
                    destinationStackChoice = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (destinationStackChoice == -1)
                    {
                        break;
                    }

                    //if ((destinationFlag == destinationStackChoice) || (destinationFlag == 9))
                    //{

                    //    game.Move(sourceStackChoice, destinationStackChoice, dictionary);
                    //}
                    //else
                    //    Console.WriteLine("You can only work on one word per turn. End turn.");
                    if (!game.Move(sourceStackChoice, destinationStackChoice))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid move. Combination is not in dictionary or you are trying to work on more than one word per turn.");
                    }
                }
            } while (true);

            Console.WriteLine("Goodbye");
            Console.WriteLine();
        }      
                       
        /// <summary>
        /// Refreshes hand by replacing cards
        /// </summary>
        /// <param name="game"> Reference to Game object</param>
        private static void DrawHand(Hand hand)
        {
            Console.WriteLine();

            for (int columnNumber = 0; columnNumber < 7; columnNumber++)
            {
                Stack column = hand.Columns[columnNumber];

                Console.Write((columnNumber + 1) + ": ");
                foreach (Card card in column)
                {
                    Console.Write(card.Letter);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

}
}



        