using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Memory
    {
        private List<Block> memory;
        private IStrategy strategy;
        public Memory(int memorySize,IStrategy strategy )
        {
            this.strategy = strategy;
            memory = new List<Block>();
            Block block = new Block(memorySize, memory.Count + 1,false,0);
            memory.Add(block);
            
        }
        public string Info()
        {
            string info = $"{strategy.DisplayName()}";
            info += "\n Allocated Blocks\n";
            var busyBlock = memory.Where(t => t.Busy == true);
            var selected = busyBlock.Select(t => $"{t.Id};{t.Adress};{t.EndAdress}");
             info += string.Join("\n", selected);
            var freeBlock = memory.Where(t => t.Busy == false);
            var selectedFree = freeBlock.Select(t => $"{t.Adress};{t.EndAdress}");
            info += "\n Free Blocks\n";
            info += string.Join("\n", selectedFree);
            info += $"\n Fragmentation";
            info += $"\n {Fragmentation()}";
            return info;
        }
        public double Fragmentation()
        {
            var freeBlock = memory.Where(t => t.Busy == false);
            double fragmentation;
            int max = freeBlock.Max(t => t.Capacity);
            int sum = freeBlock.Sum(t => t.Capacity);
            fragmentation = 1 - (max*1.0 / sum);
            return fragmentation;
        }
        public void Allocate(int size,int id )
        {
            Block block =strategy.FindBlock(memory, size);
            if(block.Capacity == size)
            {
                block.Busy = true;
                block.Id = id;
            }
            else
            {
                block.Capacity -= size;
                Block newBlock = new Block(size, id, true,block.Adress);
                block.Adress += size;
                memory.Insert(memory.FindIndex(t=>t.Id==block.Id),newBlock);
            }
        }
        public void Deallocate(int id)
        {
            Block block = memory.FirstOrDefault(t => t.Id == id);
            block.Busy = false;
            int blockId = memory.FindIndex(t => t.Equals(block));
            if (blockId != 0)
            {
                if (memory[blockId - 1].Busy == false)
                {
                    block.Capacity += memory[blockId - 1].Capacity;
                    memory.RemoveAt(blockId - 1);
                }
                if (memory[blockId + 1].Busy == false)
                {
                    block.Capacity += memory[blockId - 1].Capacity;
                    memory.RemoveAt(blockId + 1);
                }
            }
            else if(blockId == memory.Count - 1)
            {
                if (memory[blockId - 1].Busy == false)
                {
                    block.Capacity += memory[blockId - 1].Capacity;
                    memory.RemoveAt(blockId - 1);
                }

            }
            else
            {
                if (memory[blockId + 1].Busy == false)
                {
                    block.Capacity += memory[blockId - 1].Capacity;
                    memory.RemoveAt(blockId + 1);
                }
            }
          
        }

        public void Compact()
        {
            var tempMemory = memory;
            for (int i = 0; i < memory.Count; i++)
            {
                if (tempMemory[i].Busy == false)
                {
                    var block = memory[i];
                    block.Adress = memory[memory.Count - 1].Adress;
                    if (block.Id != memory.Count - 1)
                        memory[i + 1].Id--;
                    memory.Remove(block);
                    memory.Add(block);
                }
            }
        }
    }
}
// компакт = все свободные ячейки в конец
// деалокейт = находит ячейку, освобождает ее, но если соседние свободные то они сливаются