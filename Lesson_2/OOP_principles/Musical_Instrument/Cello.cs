using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Instrument
{
    public class Cello : StringInstrument
    {
        public Cello()
            : base(
                "Cello",
                "A large string instrument played sitting down",
                "The cello is used in orchestras")
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Sound: The cello makes a low, rich sound");
        }
    }

}
