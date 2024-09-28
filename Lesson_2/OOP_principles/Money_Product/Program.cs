namespace Money_Product
{
    #region Завдання 1 (ООП)
    //Запрограмуйте клас Money(об'єкт класу оперує однією валютою) для роботи з грошима. 
    //У класі мають бути передбачені: поле для зберігання цілої частини грошей (долари, євро, гривні тощо) і поле для зберігання копійок (центи, євроценти, копійки тощо)
    //Реалізувати методи виведення суми на екран, задання значень частин (цілої частини грошей та копійок). 

    //На базі класу Money створити клас Product для роботи з продуктом або товаром.
    //Реалізувати метод, який дозволяє зменшити ціну на задане число.

    //Для кожного з класів реалізувати необхідні методи і поля. 
    //Додати iнкапсуляцiю до полiв та методiв якщо треба.
    #endregion
    internal class Program
    {

        static void Main(string[] args)
        {
            // Encoding for diiferent types of currency(name or mark) or product names
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            try
            {
                // Set currency on start
                Money.SetCurrency("$", "¢");

                // Just new product
                Product product = new Product("PS5", 699, 99);
                product.Display();

                // Decreace price
                product.DecreasePrice(2, 70);
                product.Display();

                //Set new price
                product.SetPrice(9, 120);
                product.Display();

                // Example for trying to set zero or below zero price
                product.DecreasePrice(16, 20);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
