using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public static class DisplayHelper
    {
        public static void DisplayConversions(DecimalNumber decimalNumber)
        {
            Console.WriteLine("Decimal Number: " + decimalNumber.Number);
            Console.WriteLine("Binary: " + decimalNumber.ToBinary());
            Console.WriteLine("Octal: " + decimalNumber.ToOctal());
            Console.WriteLine("Hexadecimal: " + decimalNumber.ToHexadecimal());
        }
    }
}
