using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Employee
    {
        public int Salary { get; set; }
        public string Name { get; set; }

        public Employee(int salary, string name)
        {
            Salary = salary;
            Name = name;
        }

        public static Employee operator + (Employee employee, int amount)
        {
            employee.Salary += amount;
            return employee;
        }
        public static Employee operator - (Employee employee, int amount)
        {
            employee.Salary -= amount;
            return employee;
        }

        public static bool operator == (Employee employee1, Employee employee2) 
        {
            return employee1.Salary == employee2.Salary;
        }
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            return employee1.Salary != employee2.Salary;
        }
        public static bool operator > (Employee employee1, Employee employee2)
        {
            return employee1.Salary > employee2.Salary;
        }
        public static bool operator < (Employee employee1, Employee employee2)
        {
            return employee1.Salary < employee2.Salary;
        }
        public override bool Equals(object obj)
        {
            if (obj is Employee otherEmployee)
            {
                return this == otherEmployee;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Salary.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}: {Salary}$";
        }

        public void CompareSalary(Employee otherEmployee)
        {
            if (this > otherEmployee)
            {
                Console.WriteLine($"{this.Name} has more salary than {otherEmployee.Name}");
            }
            else if (this < otherEmployee)
            {
                Console.WriteLine($"{otherEmployee.Name} has more salary than {this.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} and {otherEmployee.Name} have the same salary");
            }
        }
    }
}
