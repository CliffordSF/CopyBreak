using System.Collections.Generic;
using System.IO;
using System.Text;
//using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    
    public class HighScore
    {
        //public static bool Exists(string highScoreFileName)
        //{
        //    return;
        //}
       
        public const string highScoreFileName = "highscorelist.xml";
    
        public List<FinalScore> highScoreList;// = new List<FinalScore>();
       
        /// <summary>
        /// Default constructor reads highscorelist from file if exists and adds new final score
        /// </summary>
        public HighScore(FinalScore finalScore)
        {
#pragma warning disable CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)
            BinaryFormatter formatter = new BinaryFormatter(); //Create binary formatter
#pragma warning restore CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)
            highScoreList = new List<FinalScore>();
            
            if (File.Exists(highScoreFileName))
            {
                Stream input = File.OpenRead(highScoreFileName);
                HighScore newHighScore = (HighScore)formatter.Deserialize(input);
                highScoreList = newHighScore.highScoreList;
                input.Close();
            }
        }
            //AddToHighScoreList(finalScore);
        
        /// <summary>
        /// Adds score to the high score list, sort the list, (and delete post 10)
        /// </summary>
        /// <param name="final">The game's final score</param>
        public void AddToHighScoreList(FinalScore final)
        {
            highScoreList.Add(final);
            if (highScoreList.Count < 2)
            {
                return;
            }
            // ONCE you get this working, you should be able to remove this if statement
            if (highScoreList[0] == null)
            {
                highScoreList.RemoveAt(0);
            }
            highScoreList.Sort((f1, f2) => f1.GameScore.CompareTo(f2.GameScore));
        }

        /// <summary>
        /// Retrieves highest score attained
        /// </summary>
        /// <returns>Returns highest FinalScore</returns>
        public int ReturnHighScore(FinalScore currentGameFinalScore)
        {
            if (highScoreList.Count == 0)
            {
                AddToHighScoreList(currentGameFinalScore);
            }
            int highestScore = (int) highScoreList[highScoreList.Count - 1].GameScore;
            return highestScore; 
        }
        public void SaveHighScoreList(HighScore highScores)
        {
#pragma warning disable CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)
            BinaryFormatter formatter = new BinaryFormatter();
#pragma warning restore CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'BinaryFormatter' could not be found (are you missing a using directive or an assembly reference?)

            if (File.Exists(highScoreFileName))
            {
                //BinaryFormatter formatter = new BinaryFormatter();
                Stream output = File.Create(highScoreFileName);
                formatter.Serialize(output, highScores);
                output.Close();
            }
            else
            {
                using (Stream output = File.Create(highScoreFileName))
                {
                    formatter.Serialize(output, highScores);
                    //output.Close();
                }
            }
        }

    }
}

 