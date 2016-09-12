using System;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// Creates a new card    
    /// </summary>
    [Serializable]
    public class Card
    {
        /// <summary>
        /// Letter of the card
        /// </summary>
        public readonly Letter Letter; // Card letter using the Letter enum defined in Characters.cs

        /// <summary>
        /// Card constructor
        /// </summary>
        /// <param name="letter">The letter of the card</param>
        public Card(Letter letter) // Takes a Letter enum called letter
        {
            Letter = letter;
        }


        /// <summary>
        /// Overrides ToString() to convert a Letter to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Letter.ToString();
        }
        /// <summary>
        /// Default Card constructor / no parameters
        /// </summary>
        public Card()
        {
            
        }
    }
}
