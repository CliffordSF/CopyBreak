using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace Brooks.ennuiWare.CopyBreak.Engine
{
    
    public class Stack : List<Card> //Class stack based on List<Card>
    {
        /// <summary>
        /// The letter the player selects for the CopyBreak card
        /// </summary>
        [DataMember]
        public static Letter? CopyBreakLetter { get; set; }

        /// <summary>
        ///Point value of selected stack
        /// </summary>
        public int StackValue
        {
            get
            {
                // You can do this:
                //foreach (Card card in this)
                //{
                //    int cardValue = (int)card.letter; //convert letter enum to integer value assigned
                //    stackTotal += cardValue;
                //}

                // or even better
                int stackTotal = this.Sum(card => Constants.CardValues[card.Letter]);
                stackTotal = (stackTotal) * Count;
                return stackTotal;
            }
        }
        public int StackSum
        {
            get
            {
                // You can do this:
                //foreach (Card card in this)
                //{
                //    int cardValue = (int)card.letter; //convert letter enum to integer value assigned
                //    stackTotal += cardValue;
                //}

                // or even better
                int stackTotal = this.Sum(card => Constants.CardValues[card.Letter]);
                //stackTotal = (stackTotal) * Count;
                return stackTotal;
            }
        }

        /// <summary>
        /// Returns the letters in the word/stack
        /// </summary>
        public string Word
        {
            get
            {
                // special case when the stack only contains the copybreak card
                if ((Count == 1) && (this[0].Letter == Letter.CopyBreak) && (!CopyBreakLetter.HasValue))
                {
                    return Letter.CopyBreak.ToString();
                }


                // otherwise go over each letter
                string wordSpellOut = "";
                foreach (Card card in this)
                {
                    String letterToAdd;
                    if (card.Letter == Letter.CopyBreak)
                    {
                        letterToAdd = CopyBreakLetter.ToString();
                    }
                    else
                    {
                        letterToAdd = card.Letter.ToString();
                       
                    }

                    wordSpellOut = (wordSpellOut + letterToAdd);
                }
                return wordSpellOut;
            }
        }

        public override string ToString()
        {
            return Word;
        }
        
    }
}


