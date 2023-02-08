using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class WorstFit : IStrategy
    {
        public string DisplayName()
        {
            return "WorstFit";
        }

        public Block FindBlock(List<Block> memory, int size)
        {
            var blocks = memory.Where(t => t.Busy == false);
            int maxCapacity = blocks.Max(m => m.Capacity);
            Block block = blocks.FirstOrDefault(t => t.Capacity == maxCapacity);
            return block;
           

        }
    }
}
