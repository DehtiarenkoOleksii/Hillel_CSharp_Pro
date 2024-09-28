using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Musical_Instrument
{
    public abstract class WindInstrument : MusicalInstrument
    {
        public WindInstrument(string name, string description, string history)
            : base(name, description, history)
        {
        }

        public override void Show()
        {
            Console.WriteLine($"Wind Instrument: {Name}");
        }
    }
}
