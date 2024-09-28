using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Musical_Instrument
{
    public abstract class StringInstrument : MusicalInstrument
    {
        public StringInstrument(string name, string description, string history)
            : base(name, description, history)
        {
        }

        public override void Show()
        {
            Console.WriteLine($"String Instrument: {Name}");
        }
    }
}
