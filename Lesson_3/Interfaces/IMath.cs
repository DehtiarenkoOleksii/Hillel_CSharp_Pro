using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IMath
    {
        public int Max();
        public int Min();
        public float Avg();
        bool Search(int valueToSearch);
    }
}
