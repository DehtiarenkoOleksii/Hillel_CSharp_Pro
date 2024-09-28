using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Product
{
    internal class Product
    {
        private string _name;
        private Money _price;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The product must has name");
                }
                _name = value;
            }
        }

        public Money Price
        {
            get { return _price; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The price can't be null.");
                }
                _price = value;
            }
        }

        public Product(string name, int integerPrice, int decimalPrice)
        {
            Name = name;
            Price = new Money(integerPrice, decimalPrice);
        }

        public void DecreasePrice(int integerDecrease, int decimalDecrease)
        {
            Money decreaseAmount = new Money(integerDecrease, decimalDecrease);
            _price.Subtract(decreaseAmount);
        }

        public void Display()
        {
            Console.Write($"Product: {_name}, Price: ");
            _price.Display();
        }

        public void SetPrice(int integerPrice, int decimalPrice)
        {
            _price.SetValues(integerPrice, decimalPrice);
        }
    }
}
