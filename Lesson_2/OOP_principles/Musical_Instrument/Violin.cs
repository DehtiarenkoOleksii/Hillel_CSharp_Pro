using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Instrument
{
public class Violin : StringInstrument
{
    public Violin()
        : base(
            "Violin",
            "A small string instrument played with a bow",
            "The violin originated in the 16th century in Italy")
    {
    }

    public override void Sound()
    {
        Console.WriteLine("Sound: The violin makes a high pitched sound");
    }
}

}
