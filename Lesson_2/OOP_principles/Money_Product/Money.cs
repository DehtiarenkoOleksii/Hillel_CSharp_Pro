using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Product
{
    internal class Money
    {
        private int _integerPart;
        private int _decimalPart;
        private static string _currencyName;
        private static string _currencyFraction;

        public decimal Amount
        {
            get { return _integerPart + _decimalPart / 100m; }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount could not be zero or cheeper");
                }

                _integerPart = (int)value;
                _decimalPart = (int)Math.Round((value - _integerPart) * 100);

                // for cases we "cents" will be automatically added to integer part
                if (_decimalPart >= 100)
                {
                    _integerPart += _decimalPart / 100;
                    _decimalPart = _decimalPart % 100;
                }
            }
        }

        // incapsulation
        public int IntegerPart => _integerPart;
        public int DecimalPart => _decimalPart;


        public static string CurrencyName => _currencyName;
        public static string CurrencyFraction => _currencyFraction;

        // Money without money is not logic
        public Money()
        {
            throw new ArgumentException("Amount could not be zero or cheeper");
        }

        public Money(int integerPart, int decimalPart)
        {
            SetValues(integerPart, decimalPart);
        }

        public void SetValues(int integerPart, int decimalPart)
        {
            if (integerPart < 0 || decimalPart < 0)
            {
                throw new ArgumentException("Amount could not be zero or cheeper");
            }

            _integerPart = integerPart;
            _decimalPart = decimalPart;

            if (_decimalPart >= 100)
            {
                _integerPart += _decimalPart / 100;
                _decimalPart = _decimalPart % 100;
            }

            if (_integerPart == 0 && _decimalPart == 0)
            {
                throw new ArgumentException("Amount could not be zero");
            }
        }

        public void Display()
        {
            Console.WriteLine($"{_integerPart} {CurrencyName}, {_decimalPart:D2} {CurrencyFraction}");
        }

        /// <summary>
        /// For decrease amount
        /// </summary>
        public void Subtract(Money m)
        {
            decimal currentAmount = this.Amount;
            decimal subAmount = m.Amount;

            decimal result = currentAmount - subAmount;

            if (result <= 0)
            {
                throw new InvalidOperationException("Amount could not be zero or cheeper");
            }

            this.Amount = result;
        }

        /// <summary>
        /// For increase amount
        /// </summary>
        public void Add(Money m)
        {
            decimal newAmount = this.Amount + m.Amount;
            this.Amount = newAmount;
        }

        //feature with selecting currency  
        public static void SetCurrency(string currencyName, string currencyFraction)
        {
            if (string.IsNullOrWhiteSpace(currencyName) || string.IsNullOrWhiteSpace(currencyFraction))
                throw new ArgumentException("You shoud give name for currency and fraction");

            _currencyName = currencyName;
            _currencyFraction = currencyFraction;
        }
    }

}
