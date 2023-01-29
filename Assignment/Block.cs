using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Block
    {
        public int capacity;
        public int Id;
        public bool MainBlock;
        public bool Busy;
        public int Content;
        public Block(int capacity, int id, bool mainBlock,bool busy)
        {
            this.capacity = capacity;
            Id = id;
            MainBlock = mainBlock;
            Busy = busy;
        }
    }
}
