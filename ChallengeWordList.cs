using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brooks.ennuiWare.CopyBreak.Engine
{

public class ChallengeWordList
{
        public string ChallengeWord = "";
        public string[] AllcwLines;
        //public string[] TempArray;
        
        /// <summary>
        /// Open file and pass contests to  allcwLines array
        /// </summary>
        /// <param name="path"> Path to location of file to open</param>
        public ChallengeWordList(String path)
        {
            AllcwLines = File.ReadAllLines(path, Encoding.UTF8);
            for (int i = 0; i < AllcwLines.Length; i++)
            {
                AllcwLines[i] = AllcwLines[i].ToUpper();
            }
        }
        /// <summary>
        /// Selects the Challenge Word for the game and moves word to end of list
        /// </summary>
        /// <returns></returns>
        public string selectChallengeWord()
        {
            ChallengeWord = AllcwLines[0];
            for (int i = 0; i < AllcwLines.Length; i++)
            {
                AllcwLines[i] = AllcwLines[i + 1];
            }
            AllcwLines[AllcwLines.Length - 1] = ChallengeWord;
            return ChallengeWord;
        }
        /// <summary>
        /// Checks to see if word is in dictionary before banking
        /// </summary>
        /// <param name="word"> Word to check</param>
        /// <returns></returns>
        /// 
    }
}


