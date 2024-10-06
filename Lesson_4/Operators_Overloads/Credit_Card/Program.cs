namespace Credit_Card
{
    #region   Task3 

    //Створiть та опишiть клас «Кредитна картка».
    //Додайте до вже створеного класу інформацію про суму грошей на картці.

    //Виконайте перевантаження
    //+ (для збільшення суми грошей на вказану кількість),
    //– (для зменшення суми грошей на вказану кількість),
    //== (перевірка на рівність CVC коду),
    //< і > (перевірка на меншу чи більшу кількість суми грошей),
    //!= і Equals.

    //Використовуйте механізм властивостей полів класу.
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard card1 = new CreditCard("Bob", 1000, 111);
            CreditCard card2 = new CreditCard("Tom", 2000, 222);
            CreditCard card3 = new CreditCard("Bill", 3000, 111);
            CreditCard card4 = new CreditCard("Will", 500, 333);

            Console.WriteLine(card1);
            card1 = card1 + 1500;
            Console.WriteLine(card1);
            card1 = card1 - 500;

            card1.CompareBalance(card2);
            card1.CompareBalance(card3);
            card1.CompareBalance(card4);


            Console.WriteLine($"{card1.Owner}'s and {card2.Owner}'s have the same CVC ?: {card1.Equals(card2)}");
            Console.WriteLine($"{card1.Owner}'s and {card3.Owner}'s have the same CVC ?: {card1.Equals(card3)}");
           
        }
    }
}
