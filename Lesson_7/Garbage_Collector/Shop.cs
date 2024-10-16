using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collector
{
    internal class Shop : IDisposable
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }

        private bool disposed = false;

        public Shop(string title, string type, string adress)
        {
            Title = title;
            Type = type;
            Adress = adress;
        }
        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The shop {Title} was disposed");
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

        ~Shop() 
        {
            Dispose(false);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The shop {Title} was destoyed");
            Console.ResetColor();
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Adress: " + Adress);
            Console.WriteLine("---------------------------------");
        }
    }


}
