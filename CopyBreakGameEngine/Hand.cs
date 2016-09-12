using System.Runtime.Serialization;

namespace Brooks.ennuiWare.CopyBreak.Engine 
{
    /// <summary>
    ///  Creates a columns [] array of stacks (7)
    /// </summary>
    [DataContract]
    public class Hand
    {
        [DataMember]
        public Stack[] Columns = new Stack[7];
        
        /// <summary>
        /// Constructor creates a hand; an array of 7 columns called Columns[i] and each column has a stack
        /// </summary>
        public Hand()
        {
            for (int i = 0; i < 7; i++)
            {
                Columns[i] = new Stack();
            }

        }

    }
}

