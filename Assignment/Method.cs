using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Method
    {

        private Method() { }
        private static Method instance = null;
        public static Method Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Method();
                }
                return instance;
            }
        }
        public static bool FirsFit(List<Block> memory,int size, int id)
        {
            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i].capacity >= size && memory[i].Busy!=true)
                {
                    if (memory[i].MainBlock == true)
                    {
                        Block block = new Block(size, memory.Count + 1, false,true);
                        memory.Add(block);
                        Block mainBlock = memory.FirstOrDefault(t => t.MainBlock == true);
                        mainBlock.capacity -= size;
                        return true;
                    }
                    else
                    {
                        memory[i].Content = size;
                        memory[i].Busy = true;
                        memory[i].Id = id;
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool WorstFit(List<Block> memory, int size, int id)
        {
            Block block = memory.FirstOrDefault(t => t.capacity == memory.Max(m => m.capacity)&&t.Busy==false);
            if (block.MainBlock == true)
            {
                Block newBlock = new Block(size, memory.Count + 1, false, true);
                memory.Add(newBlock);
                Block mainBlock = memory.FirstOrDefault(t => t.MainBlock == true);
                mainBlock.capacity -= size;
                return true;
            }
            else
            {
                block.Busy = true;
                block.Content = size;
                block.Id = id;
                return true;
            }
            return false;
            
        }
        public static bool BestFit(List<Block> memory,int size,int id)
        {
            Block block=null;
            for (int i = 0; i < memory.Count; i++)
            {
                int bestId = -1;
                if (memory[i].capacity >= size)
                {
                    if (block == null)
                    {
                        bestId = i;
                        block = memory[i];

                    }
                    else if (memory[bestId].capacity > memory[i].capacity)
                    {
                        bestId = i;
                        block = memory[i];
                    }
                }

            }
            if (block != null)
            {
                block.Busy = true;
                block.Content = size;
                block.Id = id;
                return true;
            }
            else
            {
                return false;
            }
            
        }
       
    }

}
