using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class BestFit : IStrategy
    {
        public string DisplayName()
        {
            return "BestFit";
        }

        public Block FindBlock(List<Block> memory, int size)
        {
            Block block = null;
            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i].Capacity >= size)
                {
                    if (block == null)
                    {
                        block = memory[i];

                    }
                    else if (block.Capacity > memory[i].Capacity)
                    {
                        block = memory[i];
                    }
                }

            }
           return block;

        }
    }
}
