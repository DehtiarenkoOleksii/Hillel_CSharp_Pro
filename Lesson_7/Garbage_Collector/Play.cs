using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collector
{
    internal class Play : IDisposable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Style { get; set; }
        public int Year { get; set; }

        private bool disposed = false;
        public Play(string title, string author, string style, int year)
        {
            Title = title;
            Author = author;
            Style = style;
            Year = year;
        }

        public void Dispose()
        {
            Dispose(true);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The play {Title} was disposed");
            Console.ResetColor();
            // comment == destructor, uncomment == only dispose
            //GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Звільняємо керовані ресурси
            }
            // звільняємо некеровані об'єкти
            disposed = true;
        }
        ~Play()
        {
            Dispose(false);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The play {Title} was destoyed");
            Console.ResetColor();
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Style: " + Style);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("---------------------------------");
        }
    }
}
