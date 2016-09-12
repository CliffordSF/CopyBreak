using System;
using System.Collections.Generic;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// Creates a list of randomly ordered cards
    /// </summary>
    
    class Deck : List<Card>
    {
        private readonly Random random;

        /// <summary>
        /// Create a new deck of cards
        /// </summary>
        public Deck()
        {
            random = new Random();
            foreach (Letter letter in Constants.CardDistribution.Keys) // Selected each letter key in the CardDistribution dictionary
            {
                int letterFrequency = Constants.CardDistribution[letter]; //Using the key, it returns the letter frequency
                for (int i = 0; i < letterFrequency; i++)
                {
                    int randomPosition = random.Next(Count + 1);//Selects a random position based on the number of cards +1 (no zero)
                    Insert(randomPosition, new Card(letter));// Inserts a new card at the random position
                }
            }
        }
     }
}


