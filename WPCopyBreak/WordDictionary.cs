using System;
using System.Text;
using System.IO;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// Opens file and puts lines in an array calleed allLines
    /// </summary>
    public class WordDictionary
    {
        private readonly string[] allLines;

        /// <summary>
        /// Open file and pass contests to allLines array
        /// </summary>
        /// <param name="path"> Path of file to open</param>
        public WordDictionary(String path)
        {
#pragma warning disable CS0117 // 'File' does not contain a definition for 'ReadAllLines'
            allLines = File.ReadAllLines(path, Encoding.UTF8);
#pragma warning restore CS0117 // 'File' does not contain a definition for 'ReadAllLines'
            for (int i = 0; i < allLines.Length; i++)
            {
               allLines[i] = allLines[i].ToUpper(); // Make terms uppercase
             }
        }
        /// <summary>
        /// Checks to see if word is in dictionary before banking
        /// </summary>
        /// <param name="word"> Word to check</param>
        /// <returns></returns>
        public bool IsValidWord(String word)
        {
            word = word.ToUpper();
            for (int i = 0; i < allLines.Length; i++)
            {
                if (word == allLines[i]) 
                {
                    return true;
                }
            }
            //Console.WriteLine("{0} is not a valid word.", word);
            return false;
        }

        /// <summary>
        ///  Checks dictionary to see if move is valid
        /// </summary>
        /// <param name="partialWord"> Characters to combine</param>
        /// <returns></returns>
        public bool IsValidCombination(String partialWord)
        {
            partialWord = partialWord.ToUpper();
            for (int i = 0; i < allLines.Length; i++)
            {
                if (allLines[i].Contains (partialWord))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
