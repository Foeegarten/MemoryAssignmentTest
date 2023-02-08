using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class FirstFit : IStrategy
    {
        public string DisplayName()
        {
            return "FirstFit";
        }

        public Block FindBlock(List<Block> memory, int size)
        {

            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i].Capacity >= size && memory[i].Busy != true)
                {
                    return memory[i];
                }
            }
            return null;
        }
    }
}
