using System.Collections.Generic;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// Constants used to establish card letter values and distribution of letters
    /// </summary>
    static class Constants
    {
        // Made static so there is no need to instantiate class to use dictionary
        /// <summary>
        /// Dictionary for card distribution
        /// </summary>
        public static readonly IDictionary<Letter, int> CardDistribution;
        /// <summary>
        /// Dictionary for card Letter values
        /// </summary>
        public static readonly IDictionary<Letter, int> CardValues;

        /// <summary>
        /// Constructor for letter value and distribution
        /// </summary>
        static Constants() 
        {
            CardDistribution = new Dictionary<Letter, int> 
            {
                {Letter.A,4},
                {Letter.B,1},
                {Letter.C,2},
                {Letter.D,2},
                {Letter.E,5},
                {Letter.F,1},
                {Letter.G,1},
                {Letter.H,2},
                {Letter.I,4},
                {Letter.J,1},
                {Letter.K,1},
                {Letter.L,2},
                {Letter.M,1},
                {Letter.N,3},
                {Letter.O,4},
                {Letter.P,2},
                {Letter.Q,1},
                {Letter.R,3},
                {Letter.S,2},
                {Letter.T,3},
                {Letter.U,1},
                {Letter.V,1},
                {Letter.W,1},
                {Letter.X,1},
                {Letter.Y,1},
                {Letter.Z,1},
                {Letter.CopyBreak,1}
            };


            CardValues = new Dictionary<Letter, int>
            {
                {Letter.CopyBreak,5},
                {Letter.A,0},
                {Letter.B,2},
                {Letter.C,1},
                {Letter.D,1},
                {Letter.E,0},
                {Letter.F,2},
                {Letter.G,1},
                {Letter.H,1},
                {Letter.I,0},
                {Letter.J,4},
                {Letter.K,3},
                {Letter.L,1},
                {Letter.M,2},
                {Letter.N,1},
                {Letter.O,0},
                {Letter.P,1},
                {Letter.Q,5},
                {Letter.R,1},
                {Letter.S,1},
                {Letter.T,1},
                {Letter.U,0},
                {Letter.V,3},
                {Letter.W,2},
                {Letter.X,4},
                {Letter.Y,3},
                {Letter.Z,4}
            };
        }
    }
}
