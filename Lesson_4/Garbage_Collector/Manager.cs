using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage_Collector
{
    public class Manager <T>: IDisposable where T : IDisposable
    {
        private List<T> items = new List<T>();
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The object {typeof(T).Name} was disposed");
            Console.ResetColor();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Звільняємо керовані ресурси
                foreach (var item in items)
                {
                    item.Dispose();
                }
                items.Clear();
            }
            // звільняємо некеровані об'єкти
            disposed = true;
        }

        ~Manager() 
        { 
            Dispose(false);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The object {typeof(T).Name} was destoyed");
            Console.ResetColor();
        }

        public void AddItem(T item)
        {
            items.Add(item);
            Console.WriteLine($"The object {typeof(T).Name} was added\n");
        }

        public void DisplayItems(Action<T> displayMethod)
        {

            foreach (var item in items)
            {
                displayMethod(item);
            }
        }

        public void UpdateItem(Predicate<T> match, T newItem)
        {
            int index = items.FindIndex(match);
            if (index != -1)
            {
                items[index].Dispose();
                items[index] = newItem;
                Console.WriteLine($"The object {typeof(T).Name} was updated");
            }
            else 
            {
                Console.WriteLine($"The object {typeof(T).Name} is absent");
            }
        }

        public void DeleteItem (Predicate<T> match) 
        {
            var item = items.Find(match);
            if (item != null) 
            {
                items.Remove(item);
                item.Dispose();
                Console.WriteLine($"The object {typeof(T).Name} was deleted");
            }
        }
    }
}
