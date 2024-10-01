using System.Collections.Generic;

namespace Interfaces
{
    #region Task_1 
    //Створіть інтерфейс IOutput.
    //У ньому мають бути два методи:
    //■ void Show() — відображає інформацію;
    //■ void Show(string info) — відображає інформацію та інформаційне повідомлення, зазначене у параметрі info.

    //Створіть клас MyArray (масив цілого типу) із необхідними методами.
    //Цей клас має імплементувати інтерфейс IOutput.
    //Метод Show() — відображає на екран елементи масиву.
    //Метод Show(string info) — відображає на екрані елементи масиву та інформаційне повідомлення, зазначене у параметрі info.

    //Напишіть код для тестування отриманої функціональності.
    #endregion
    #region Task_2 
    //Створіть інтерфейс IMath.
    //У ньому мають бути чотири методи:
    //■ int Max() — повертає максимум;
    //■ int Min() — повертає мінімум;
    //■ float Avg() — повертає середньоарифметичне;
    //■ bool Search(int valueToSearch) — шукає valueSearch всередині контейнера даних.
    //- Повертає true, якщо значення знайдено.
    //- Повертає false, якщо значення не знайдено.

    //Клас, створений у першому завданні Array, має імплементувати інтерфейс IMath.
    //Метод Max — повертає максимум серед елементів масиву.
    //Метод Min — повертає мінімум серед елементів масиву.
    //Метод Avg — повертає середньоарифметичне серед елементів масиву.
    //Метод Search — шукає значення всередині масиву.
    //- Повертає true, якщо значення знайдено.
    //- Повертає false, якщо значення не знайдено.
    //Напишіть код для тестування отриманої функціональності
    #endregion
    #region Task_3
    //Створіть інтерфейс ISort.
    //У ньому мають бути три методи:
    //■ void SortAsc() — сортування за зростанням;
    //■ void SortDesc() — сортування за зменшенням;
    //■ void SortByParam(bool isAsc) — сортування залежно від переданого параметра.
    //Якщо isAsc дорівнює true, сортуємо за зростанням.
    //Якщо isAsc дорівнює false, сортуємо за зменшенням

    //Клас, створений у першому завданні Array, має імплементувати інтерфейс ISort.
    //Метод SortAsc — сортує масив за зростанням.
    //Метод SortDesc — сортує масив за спаданням.
    //Спосіб SortByParam — сортує масив залежно від переданого параметра.
    //Якщо isAsc дорівнює true, сортуємо за зростанням.
    //Якщо isAsc дорівнює false, сортуємо за зменшенням.

    //Напишіть код для тестування отриманої функціональності.
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] startArray = { 1, 45, 3, -7, 5, 10, 100 };
            int valueToSearch1 = 1;
            int valueToSearch2 = 101;
            MyArray demoArray = new MyArray(startArray);

            Console.WriteLine("Task_1");
            demoArray.Show();
            demoArray.Show("Some magic info");


            Console.WriteLine("\n==========================");
            Console.WriteLine("Task_2");
            Console.WriteLine($"Max : {demoArray.Max()}");
            Console.WriteLine($"Min : {demoArray.Min()}");
            Console.WriteLine($"Avg : {demoArray.Avg()}");
            Console.WriteLine($"value: {valueToSearch1} is " + (demoArray.Search(valueToSearch1) ? "present" : "absent"));
            Console.WriteLine($"value: {valueToSearch2} is " + (demoArray.Search(valueToSearch1) ? "present" : "absent"));


            Console.WriteLine("\n==========================");
            Console.WriteLine("Task_3");
            demoArray.SortAsc();
            demoArray.Show("Demo for SortAsc");
            demoArray.SortDesc();
            demoArray.Show("Demo for SortDesc");

            demoArray.SortByParam(true);
            demoArray.Show("Demo for SortByParam with true");
            demoArray.SortByParam(false);
            demoArray.Show("Demo for SortByParam with false");
        }


    }
}
