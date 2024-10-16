using System.Numerics;

namespace Garbage_Collector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunPlays();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            RunShops();

            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        static void RunPlays()
        {
            using (Manager<Play> playManager = new Manager<Play>())
            {
                Play play1 = new Play("Hamlet", "William Shakespeare", "Tragic", 1623);
                Play play2 = new Play("Pygmalion", "George Bernard Shaw", "Comedy", 1913);

                playManager.AddItem(play1);
                playManager.AddItem(play2);

                playManager.DisplayItems(p => p.DisplayInfo());

                Play newPlay = new Play("Romeo and Juliet", "William Shakespeare", "Tragic", 1597);
                playManager.UpdateItem(p => p.Title == "Hamlet", newPlay);

                playManager.DisplayItems(p => p.DisplayInfo());

                playManager.DeleteItem(p => p.Title == "Pygmalion");

                playManager.DisplayItems(p => p.DisplayInfo());


            } 

        }

        static void RunShops()
        {
            using (Manager<Shop> shopManager = new Manager<Shop>())
            {
                Shop shop1 = new Shop("Comfy", "Electonics", "Heroyiv Kharkiv Avenue 295, Kharkiv");
                Shop shop2 = new Shop("Epicentre", "Household goods", "vul. Neskorenykh 9-A, Kharkiv");

                shopManager.AddItem(shop1);
                shopManager.AddItem(shop2);

                shopManager.DisplayItems(p => p.DisplayInfo());

                Shop newShop = new Shop("Citrus", "Electonics", "Heroyiv Kharkiv Avenue 295, Kharkiv");
                shopManager.UpdateItem(p => p.Title == "Comfy", newShop);

                shopManager.DisplayItems(p => p.DisplayInfo());

                shopManager.DeleteItem(p => p.Title == "Pygmalion");

                shopManager.DisplayItems(p => p.DisplayInfo());


            }

        }

    }
}
