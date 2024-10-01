using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface ISort
    {
        public void SortAsc();
        public void SortDesc();
        public void SortByParam(bool isAsc);

    }
}
