using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Memory
    {
        public List<Block> memory;
        
        public Memory(int memorySize)
        {
            memory = new List<Block>();
            Block block = new Block(memorySize, memory.Count + 1, true,false);
            memory.Add(block);
            
        }
        public void Allocate(int size,int id)
        {
            if (Method.FirsFit(memory, size,id) == false)
            {
                if (Method.BestFit(memory, size,id) == false)
                {
                    Method.WorstFit(memory, size, id);
                }
            }
        }
        public void Deallocate(int id)
        {
            Block block = memory.FirstOrDefault(t => t.Id == id);
            Block mainBlock = memory.FirstOrDefault(t => t.MainBlock == true);
            memory.Remove(block);
            mainBlock.capacity += block.capacity;
        }


    }
}
