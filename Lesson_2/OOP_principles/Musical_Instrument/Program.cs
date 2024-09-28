namespace Musical_Instrument
{
    #region Завдання 2 (ООП)
    // Створити базовий клас «Музичний інструмент» і похідні класи: «Скрипка», «Тромбон», «Укулеле», «Віолончель». 
    //За допомогою конструктора, встановити назву до кожного музичного інструменту і його характеристики.
    //Реалізуйте для кожного з класів методи:
    //■ Sound — видає звук музичного інструменту(пишемо текстом у консоль); 
    //■ Show — відображає назву музичного інструменту; 
    //■ Desc — відображає опис музичного інструменту; 
    //■ History — відображає історію створення музичного інструменту.
    //Додати iнкапсуляцiю до полiв та методiв якщо треба.
    #endregion
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Create an array of musical instruments
            MusicalInstrument[] instruments = new MusicalInstrument[]
            {
            new Violin(),
            new Trombone(),
            new Ukulele(),
            new Cello()
            };

            // Execute methods for each instrument
            foreach (var instrument in instruments)
            {
                Console.WriteLine("\n========================");
                
                instrument.Show();
                instrument.Desc();
                instrument.History();
                instrument.Sound();
            }
        }
    }
}
