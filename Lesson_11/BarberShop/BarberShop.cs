using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop
{
    using System;
    using System.Threading;

    internal class BarberShop
    {
        private int numberOfChairs;
        private SemaphoreSlim waitingCustomers; 
        private SemaphoreSlim barberReady;      
        private SemaphoreSlim customerReady;    
        private SemaphoreSlim mutex;            // Mutual exclusion for accessing shared variables
        private int freeSeats;
        private bool barberSleeping = false;    // Indicates if the barber is sleeping

        public BarberShop(int chairs)
        {
            numberOfChairs = chairs;
            freeSeats = chairs;
            waitingCustomers = new SemaphoreSlim(0, chairs);
            barberReady = new SemaphoreSlim(0, 1);
            customerReady = new SemaphoreSlim(0, 1);
            mutex = new SemaphoreSlim(1, 1);
        }

        public void Barber()
        {
            while (true)
            {
                // Barber tries to acquire a waiting customer
                if (waitingCustomers.Wait(1000))
                {
                    mutex.Wait();            // Acquire exclusive access
                    barberSleeping = false;  // Barber wakes up
                    freeSeats++;             
                    barberReady.Release();   // Barber is ready to cut hair
                    mutex.Release();
                    customerReady.Wait();    
                    CutHair();
                }
                else
                {
                    // No customers(( barber goes to sleep
                    mutex.Wait();
                    if (!barberSleeping)
                    {
                        Console.WriteLine("Barber goes to sleep");
                        barberSleeping = true;
                    }
                    mutex.Release();
                }
            }
        }

        public void Customer(int id)
        {
            mutex.Wait(); // Acquire exclusive access
            if (freeSeats > 0)
            {
                freeSeats--;
                Console.WriteLine($"Customer {id} is waiting. Free seats: {freeSeats}");
                if (barberSleeping)
                {
                    Console.WriteLine($"Customer {id} wakes up the barber");
                }
                waitingCustomers.Release(); // Notify the barber of a waiting customer
                mutex.Release();
                barberReady.Wait();
                Console.WriteLine($"Customer {id} is getting a haircut");
                customerReady.Release(); // Notify the barber that the customer is ready
            }
            else
            {
                // No free chairs(( leave the barbershop
                Console.WriteLine($"Customer {id} leaves, no free seats");
                mutex.Release();
            }
        }

        private void CutHair()
        {
            Console.WriteLine("Barber is does klac-klac");
            Thread.Sleep(1000); // Some time for needs for cutting
            Console.WriteLine("Barber finished cutting hair");
        }
    }
}
