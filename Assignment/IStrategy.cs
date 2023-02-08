using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public interface IStrategy
    {
        Block FindBlock(List<Block> memory, int size);
        string DisplayName();
    }
}
