using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class MyArray : IOutput, IMath
    {
        private int[] array;
        public MyArray(int[] array)
        {
            this.array = array;
        }

        // Task_1
        public void Show() 
        {
            foreach (var item in this.array)
            {
                Console.Write(item + " ");
            }
        }
        public void Show(string info) 
        {
            Console.WriteLine($"\nAdd info: {info}");
            Show();
        }

        // Task_2
        public int Max()
        {
            return this.array.Max();
        }

        public int Min()
        {
            return this.array.Min();
        }

        public float Avg()
        {
            return (float)this.array.Average();
        }

        public bool Search(int valueToSearch)
        {
            return array.Contains(valueToSearch);
        }

        // Task_3
        public void SortAsc()
        {
            Array.Sort(array);
        }
        public void SortDesc()
        {
            Array.Sort(array);
            Array.Reverse(array);
        }
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }
}
