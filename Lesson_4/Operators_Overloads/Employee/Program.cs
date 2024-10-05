namespace Employee
{
    #region Task_1
    //Створiть та опишiть клас «Співробітник».
    //Додайте до вже створеного класу інформацію про заробітну плату працівника.

    //Виконайте перевантаження
    //+ (для збільшення зарплати на вказану кількість),
    //– (для зменшення зарплати на вказану кількість),
    //== (перевірка на рівність зарплат працівників),
    //< і > (перевірка на меншу чи більшу кількість зарплат працівників),
    //!= і Equals.Використовуйте механізм властивостей полів класу.
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee(6000, "Bob");
            Employee employee2 = new Employee(6000, "Tom");
            Employee employee3 = new Employee(7000, "Bill");
            Employee employee4 = new Employee(5000, "Will");

            Console.WriteLine(employee1);
            employee1 = employee1 + 500;
            Console.WriteLine(employee1);
            employee1 = employee1 - 500;
            Console.WriteLine(employee1);

            employee1.CompareSalary(employee3);
            employee1.CompareSalary(employee4);
            employee1.CompareSalary(employee2);

            Console.WriteLine($"Employees {employee1.Name} and {employee2} have the same salary ?: {employee1.Equals(employee2)}");
            Console.WriteLine($"Employees {employee1.Name} and {employee3} have the same salary ?: {employee1.Equals(employee3)}");
        }
    }
}
