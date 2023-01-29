using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Memory memory = new Memory(1000);
            memory.Allocate(100);
            foreach (var item in memory.memory)
            {
                Console.WriteLine($"{item.capacity}");
            }
            Console.ReadKey();
        }
    }
}
