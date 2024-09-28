using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Instrument
{
    public class Trombone : WindInstrument
    {
        public Trombone()
            : base(
                "Trombone",
                "A brass instrument with a telescoping slide mechanism",
                "The trombone appeared in the 15th century and was used extensively across Europe, declining in most places by the mid to late 17th century")
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Sound: Trombone produces a deep sound");
        }
    }
}
