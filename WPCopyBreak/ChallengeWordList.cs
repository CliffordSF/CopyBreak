using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.IO;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// ChallengeWord class
    /// </summary>
    
    public class ChallengeWords
    {
        private const string ChallengeFileName = "challengewords.txt";
        public const int ChallengeWordBonus = 100;
        private readonly Queue<String> challengeWordQueue;
        

        /// <summary>
        /// Constructor opens file and passes contents to a queue
        /// </summary>
        public ChallengeWords()
        {
#pragma warning disable CS0117 // 'File' does not contain a definition for 'ReadAllLines'
            challengeWordQueue = new Queue<string>(File.ReadAllLines(ChallengeFileName, Encoding.UTF8));
#pragma warning restore CS0117 // 'File' does not contain a definition for 'ReadAllLines'
        }

        /// <summary>
        /// Selects Challenge Word for the game and moves word to end of list
        /// </summary>
        /// <returns></returns>
        public string GetNextChallengeWord()
        {
            String nextChallengeWord = challengeWordQueue.Dequeue();
            challengeWordQueue.Enqueue(nextChallengeWord);
            return nextChallengeWord; 
        }

        /// <summary>
        /// Save the reordered Challenge Word list back to disk
        /// </summary>
        public void Save()
        {
#pragma warning disable CS0117 // 'File' does not contain a definition for 'WriteAllLines'
            File.WriteAllLines(ChallengeFileName, challengeWordQueue, Encoding.UTF8);
#pragma warning restore CS0117 // 'File' does not contain a definition for 'WriteAllLines'
        }
        
    }
}


