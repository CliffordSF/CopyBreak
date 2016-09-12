using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    
    public class Game
    {
        private int turnFlag = 9;
      
        private int turnCheckDigit;
       
        private int turnCount;
      
        private Deck deck;
       
        private Letter copybreakLetter;
       
        public Hand Hand = new Hand();
        private WordDictionary dictionary;
       
        public string Color;
       
        public string PlayerName;
       
        public FinalScore FinalScore;
       
        public Player Player;
 
        public int Points;
     
        public string Word;
   
        public List<string> BankedWords = new List<string>();
       
        public string ChallengeWord;
       
        private bool hasChallengeWord;
       
        public bool gameInProgress = false;

        /// <summary>
        /// Creates a new game
        /// </summary>
        /// 
        public Game(string color, string playerName, string challengeWord)
        {
            PlayerName = playerName;
            Color = color;
            Player = new Player(playerName);
            CurrentScore = 0;
            deck = new Deck();
            Stack.CopyBreakLetter = null;
            ReloadDictionary();
            ChallengeWord = challengeWord;
        }
        
        
        /// <summary>
        /// Creates the initial hand of 7 cards
        /// </summary>
        public void Start()
        {
            for (int i = 0; i < 7; i++)
            {
                Card card = deck[0];
                Hand.Columns[i].Add(card);
                deck.RemoveAt(0);
            }
            gameInProgress = true;
        }

        //if turnflag = 9, go ahead and move...if not, invalid location, try again...turnflag reset to 9 when banked or turn set

        /// <summary>
        /// Moves the source stack and appends it to end of target stack
        /// </summary>
        /// <param name="source">The stack or card to move</param>
        /// <param name="target">The position you want to move the source stack to</param>
        /// <returns></returns>
        public bool Move(int source, int target)
        {
            if (source == target)
            {
                System.Diagnostics.Debug.WriteLine("Skipping move to itself from {0} to {1}", source, target);
                return false;
            }

            if (source < 0 || source > 6)
            {
                System.Diagnostics.Debug.WriteLine("Skipping move because source {0} is out of range", source);
                return false;
            }
            
            if (target< 0 || target > 6)
            {
                System.Diagnostics.Debug.WriteLine("Skipping move because target {0} is out of range", target);
                return false;
            }
            

            System.Diagnostics.Debug.WriteLine("Moving {0} to {1}", source, target);
            Stack targetStack = Hand.Columns[target];
            Stack sourceStack = Hand.Columns[source];
 
            //Check to see if combination is valid...occurs in a real word IsValidCombination
            String letterCombination = targetStack.Word + sourceStack.Word;
            if (turnFlag == 9)
            {
                turnCheckDigit = target;
            }

                if (dictionary.IsValidCombination(letterCombination) && turnCheckDigit == target)
                {
                targetStack.AddRange(sourceStack);
                sourceStack.Clear();
                turnFlag = target;
                return true;
                }
                return false;
        }
        //In the final version, you'll click the 


        /// <summary>
        /// Performs a turn by filling empty stacks with a single card.
        /// </summary>
        /// deck to denote the end of a turn non-word turn.
        public void Turn()
        {

            for (int i = 0; i < 7; i++)
            {
                if (deck.Count == 0)
                {
                    MessageBox.Show("There are no more cards in the deck. Complete and remove any remaining words and then select END GAME.");
                    return;
                }

                if (Hand.Columns[i].Count == 0)
                {
                    Hand.Columns[i].Add(deck[0]);
                    deck.RemoveAt(0);
                    turnCount++;
                    turnFlag = 9;
                }
            }
        }

        /// <summary>
        /// Performs a turn by "banking" a full word and refill that stack with a single card.
        /// </summary>
        /// <param name="source">The number of the stack to total and remove</param>
        /// <param name="wasChallengedWord">Outputs ChallengeWord</param>
        public bool Turn(int source, out bool wasChallengedWord)
        {
            source = source - 1;
            Stack wordToBank = Hand.Columns[source];
            string wordToBankString = wordToBank.Word.ToUpper();

            if (dictionary.IsValidWord(wordToBankString))
            {
                String word = wordToBank.Word;
                wasChallengedWord = String.Equals(word, ChallengeWord, StringComparison.InvariantCultureIgnoreCase);
                hasChallengeWord = hasChallengeWord || wasChallengedWord;
                int points = wordToBank.StackValue;
                CurrentScore += points;
                wordToBank.Clear();
                Turn();
                turnCount++;
                turnFlag = 9;

                BankedWords.Add(word + "  " + points);
                return true;
            }
            wasChallengedWord = false;
            return false;
        }

     
        public int CurrentScore 
        { 
            get; 
            set; 
        }

        public void SetCopybreakLetter(Letter replacementCardLetter)
        {
            copybreakLetter = replacementCardLetter;
        }
        public void ReloadDictionary()
        {
            dictionary = new WordDictionary("US.txt");
        }

        public void End()
        {
            gameInProgress = false;
            if (hasChallengeWord)
            {
                CurrentScore += ChallengeWords.ChallengeWordBonus;
            }
            if (Hand.Columns[0].Count == 0 && Hand.Columns[1].Count == 0 && Hand.Columns[2].Count == 0 &&
                Hand.Columns[3].Count == 0 && Hand.Columns[4].Count == 0 && Hand.Columns[5].Count == 0 &&
                Hand.Columns[6].Count == 0)
                {
                    CurrentScore = CurrentScore * 2;
                }
            //Why does this work? Doesn't this only check the first column for content? Is it because
            //each Columns is a stack (list), and when removed, the count chances so the first stack, or stack
            //0 is whatever is remaining and no longer location based?
            //ONLY works if there is a card in column zero
             if (Hand.Columns[0].Count > 0 || Hand.Columns[1].Count > 0 || Hand.Columns[2].Count > 0 || Hand.Columns[3].Count > 0 ||
                 Hand.Columns[4].Count > 0 || Hand.Columns[5].Count > 0 || Hand.Columns[6].Count > 0)
             {
                 SubtractUnusedLetters();
             }
            
        }

        public int SubtractUnusedLetters()
        {
            for (int i = 0; i < 7; i++)
            {
                if (Hand.Columns[i].Count > 0)
                {
                    Stack lettersToSubtract = Hand.Columns[i];
                    int negativeLetterPoints = lettersToSubtract.StackSum;
                    CurrentScore -= negativeLetterPoints;
                    negativeLetterPoints = 0;

                }
            }
            return 0;
        }
    }
}


//  public bool Turn(int source, out bool wasChallengedWord)
//{
//    source = source - 1;
//    Stack wordToBank = Hand.Columns[source];
//    string wordToBankString = wordToBank.Word.ToUpper();

//    if (dictionary.IsValidWord(wordToBankString))
//    {
//        String word = wordToBank.Word;
//        wasChallengedWord = String.Equals(word, ChallengeWord, StringComparison.InvariantCultureIgnoreCase);
//        hasChallengeWord = hasChallengeWord || wasChallengedWord;
//        int points = wordToBank.StackValue;
//        CurrentScore += points;
//        wordToBank.Clear();
//        Turn();
//        turnCount++;
//        turnFlag = 9;

//        BankedWords.Add(word + "  " + points);
//        return true;
//    }
