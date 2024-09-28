using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Musical_Instrument
{
    public abstract class MusicalInstrument
    {
        protected string Name { get; }
        protected string Description { get; }
        protected string HistoryInfo { get; }

        public MusicalInstrument(string name, string description, string history)
        {
            Name = name;
            Description = description;
            HistoryInfo = history;
        }

        public abstract void Sound();

        public virtual void Show()
        {
            Console.WriteLine($"Instrument: {Name}");
        }

        public virtual void Desc()
        {
            Console.WriteLine($"Description: {Description}");
        }

        public virtual void History()
        {
            Console.WriteLine($"History: {HistoryInfo}");
        }
    }
}
