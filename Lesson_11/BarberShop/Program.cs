namespace BarberShop
{
    #region Task
    //Розглянемо перукарню, в якій працює один перукар, є одне крісло для стрижки
    //і кілька крісел у приймальні для відвідувачів, які чекають на свою чергу.Якщо у перукарні немає відвідувачів,
    //перукар засинає прямо на своєму робочому місці.Відвідувач, що з'явився, повинен його розбудити,
    //у результаті перукар приступає до роботи.Якщо в процесі стрижки з'являються нові відвідувачі,
    //вони повинні або почекати своєї черги, або залишити перукарню, якщо у приймальні немає вільного крісла для очікування.
    //Завдання полягає в тому, щоб коректно запрограмувати поведінку перукаря та відвідувачів.
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            BarberShop shop = new BarberShop(3); 
            Thread barberThread = new Thread(new ThreadStart(shop.Barber));
            barberThread.Start(); 

            Random rand = new Random();
            int customerId = 1;
            while (true)
            {
                Thread.Sleep(rand.Next(1000, 4000)); // Random  arrival time for new customers
                int id = customerId++;
                new Thread(() => shop.Customer(id)).Start(); 
            }
        }
    }
}
