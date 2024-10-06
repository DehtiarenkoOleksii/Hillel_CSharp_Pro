namespace City
{
    #region Task 2

    //Створiть та опишiть клас «Місто».
    //Виконайте перевантаження

    //+ (для збільшення кількості жителів на вказану кількість),
    //– (для зменшення кількості жителів на вказану кількість),
    //== (перевірка на рівність двох міст за кількістю жителів),
    //< і > (перевірка на меншу чи більшу кількість мешканців),
    //!= і Equals.

    //Використовуйте механізм властивостей полів класу.
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            City city1 = new City("Kharkiv", "Ukraine", 2000000);
            City city2 = new City("Kyiv", "Ukraine", 3000000);
            City city3 = new City("New York", "USA", 15000000);
            City city4 = new City("London", "England", 4000000);

            Console.WriteLine(city1);
            city1 = city1 + 1500000;
            Console.WriteLine(city1);
            city1 = city1 - 500000;

            city1.ComparePopulation(city2);
            city1.ComparePopulation(city3);
            city1.ComparePopulation(city4);

            Console.WriteLine($"Cities {city1.Name} and {city2.Name} have the same population ?: {city1.Equals(city2)}");
            Console.WriteLine($"Cities {city1.Name} and {city3.Name} have the same population ?: {city1.Equals(city3)}");
        }
    }
}
