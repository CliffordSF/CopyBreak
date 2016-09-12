using System;
using System.Runtime.Serialization;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// Creates a final score object that includes player name, score, and date
    /// </summary>
    [DataContract] [Serializable]
    public class FinalScore
    {
        public DateTime gameDate;
        public readonly int GameScore;
        public Player Gplayer;
        /// <summary>
        /// Default constructor for FinalScore
        /// </summary>
        public FinalScore()
        {
            
        }

        /// <summary>
        /// Constructor for FinalScore
        /// </summary>
        /// <param name="gplayer">Name of player</param>
        /// <param name="score">Score at end of game</param>
        public FinalScore(Player gplayer, int score)
        {
            GameScore = score;
            gameDate = DateTime.Now;
            Gplayer = gplayer;
            //GamePlayer = GameScore.ToString() + "  " + Gplayer.Name.ToString() +"/T" +  + "/T" + GameDate;
        }
    }
}
