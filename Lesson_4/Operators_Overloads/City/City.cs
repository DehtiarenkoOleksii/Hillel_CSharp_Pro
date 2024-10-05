using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City
{
    internal class City
    {

        public string Name { get; set; }
        public uint Population { get; set; }
        public string Country { get; set; }

        public City(string name, string country, uint population)
        {
            Name = name;
            Country = country;
            Population = population;
        }

        public static City operator +(City city, uint amount)
        {
            city.Population += amount;
            return city;
        }
        public static City operator - (City city, uint amount)
        {
            city.Population -= amount;
            return city;
        }
        public static bool operator == (City city1, City city2)
        {
            return city1.Population == city2.Population;
        }
        public static bool operator !=(City city1, City city2)
        {
            return city1.Population != city2.Population;
        }
        public static bool operator > (City city1, City city2)
        {
            return city1.Population > city2.Population;
        }
        public static bool operator <(City city1, City city2)
        {
            return city1.Population < city2.Population;
        }
        public override bool Equals(object obj)
        {
            if (obj is City otherCity)
            {
                return this == otherCity;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Population.GetHashCode();
        }
        public override string ToString()
        {
            return $"{Name}, {Country}: {Population:N0}";
        }
        public void ComparePopulation(City otherCity)
        {
            if (this > otherCity)
            {
                Console.WriteLine($"{this.Name} has more population than {otherCity.Name}");
            }
            else if (this < otherCity)
            {
                Console.WriteLine($"{otherCity.Name} has more population than {this.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} and {otherCity.Name} have the same population");
            }
        }
    }
}
