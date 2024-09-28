using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Instrument
{
    public class Ukulele : StringInstrument
    {
        public Ukulele()
            : base(
                "Ukulele",
                "A small, guitar-like instrument with four nylon strings",
                "The ukulele originated in the 19th century in Hawaii and became popular worldwide.")
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Sound: Ukulele produces a light, cheerful sound");
        }
    }
}
