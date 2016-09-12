using System.Runtime.Serialization;
using System;

namespace Brooks.ennuiWare.CopyBreak.Engine
{
    /// <summary>
    /// Player class identifies player by name
    /// </summary>
    [DataContract][Serializable]
    public class Player
    {
        [DataMember]
        public string Name;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Player()
        {
            
        }
        /// <summary>
        /// Player constructor
        /// </summary>
        /// <param name="name">Name of player</param>
        public Player(string name)
        {
            Name = name;
        }
    }
}
