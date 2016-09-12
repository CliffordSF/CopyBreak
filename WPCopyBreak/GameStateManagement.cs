using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

//THIS IS VERY BROKEN>>>REMOVED THE DataContractSerializer LINES BELOW
namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// Manages the serialization and deserialization of a game
    /// </summary>
    public class GameStateManagement
    {
        //private static readonly DataContractSerializer GameSerializer = new DataContractSerializer(typeof(Game));
       // private static readonly DataContractSerializer HighScoreSerializer = new DataContractSerializer(typeof(HighScore));
        private const String HighscoreFilename = "highscore.xml";

        /// <summary>
        /// Saves the current game in process to disk
        /// </summary>
        /// <param name="game">Current game</param>
        /// <param name="filename">Constant reference to high score file</param>
        public static void SaveGame(Game game, string filename)
        {
            using (XmlWriter writer = XmlWriter.Create(filename)) // Create an XmlWriter file to store game state data as XML
            {
                GameSerializer.WriteObject(writer, game); // Serialize game data
            }
        }
        /// <summary>
        /// Load a saved game from disk
        /// </summary>
        /// <param name="filename">Name of file to load</param>
        /// <returns>Reloads selected game</returns>
        public static Game LoadGame(string filename)
        {
            using (XmlReader reader = XmlReader.Create(filename))
            {
                Game game = (Game) GameSerializer.ReadObject(reader);
                game.ReloadDictionary();
                return game;
            }
        }
        /// <summary>
        /// Writes high score to file
        /// </summary>
        /// <param name="highScore">Score to be written to disk</param>
        public static void SaveHighscore(HighScore highScore)
        {
            using (XmlWriter writer = XmlWriter.Create(HighscoreFilename)) // Create an XmlWriter file to store game state data as XML
            {
                HighScoreSerializer.WriteObject(writer, highScore); // Serialize high score
            }
        }
    }
}
