using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Block
    {
        public int Capacity { get; set; }   
        public int Id { get; set; }
        public bool Busy { get; set; }
        public int Adress { get; set; }
        public int EndAdress
        {
            get
            {
                return Capacity + Adress-1;
            }
        }
        public Block(int capacity, int id,bool busy,int Adress)
        {
            Capacity = capacity;
            Id = id;
            Busy = busy;
            this.Adress = Adress;
        }
    }
}
