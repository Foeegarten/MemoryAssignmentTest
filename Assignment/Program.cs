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
            Memory memory = new Memory(1000,new BestFit());
            memory.Allocate(100,0);
            memory.Allocate(200, 1);
            memory.Deallocate(0);
            Console.WriteLine(memory.Info());
            Console.ReadKey();
        }
    }
}
