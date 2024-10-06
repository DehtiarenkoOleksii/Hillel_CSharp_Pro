using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_Card
{
    internal class CreditCard
    {
        private double balance;

        public double Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance can't be less than 0");
                }
                balance = value;
            }
        }

        public string Owner { get; set; }

        public readonly int CVC;

        public CreditCard(string owner, double balance,  int cvc)
        {
            if (balance < 0)
            {
                throw new ArgumentException("Start balance can't be less than 0");
            }
            if (cvc < 100 || cvc > 999)
            {
                throw new ArgumentException("CVC must be exactly 3 digits.");
            }
           
            Owner = owner;
            Balance = balance;
            CVC = cvc;
        }

        public static CreditCard operator + (CreditCard card , double amount)
        {
            card.Balance += amount;
            return card;
        }
        public static CreditCard operator - (CreditCard card, double amount)
        {
            card.Balance -= amount;
            return card;
        }

        public static bool operator == (CreditCard card1, CreditCard card2)
        {
            return card1.CVC == card2.CVC;
        }
        public static bool operator != (CreditCard card1, CreditCard card2)
        {
            return card1.CVC != card2.CVC;
        }
        public static bool operator > (CreditCard card1, CreditCard card2)
        {
            return card1.Balance > card2.Balance;
        }
        public static bool operator < (CreditCard card1, CreditCard card2)
        {
            return card1.Balance < card2.Balance;
        }

        public override bool Equals(object obj)
        {
            if (obj is CreditCard card)
            {
                return this.CVC == card.CVC;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return CVC.GetHashCode();
        }

        public override string ToString()
        {
            return $"Owner: {Owner}, Balance : {Balance}$, CVC {CVC}";
        }

        public void CompareBalance(CreditCard otherCard)
        {
            if (this > otherCard)
            {
                Console.WriteLine($"{this.Owner}'s has more money on balance than {otherCard.Owner}'s card");
            }
            else if (this < otherCard)
            {
                Console.WriteLine($"{this.Owner}'s has less money on balance than {otherCard.Owner}'s card");
            }
            else
            {
                Console.WriteLine($"{this.Owner}'s card and {otherCard.Owner}'s card have the same balance");
            }
        }
    }
}
