namespace Structures
{
    #region Завдання 3 (Структури)
    //Створіть структуру «Десяткове число». 
    //Визначте в ній необхідні поля і методи.Реалізуйте наступну функціональність: 

    //■ Перевести число у двійкову систему; 
    //■ Перевести число у вісімкову систему; 
    //■ Перевести число у шістнадцяткову систему.
    #endregion
    public struct DecimalNumber
    {
        private int _number;


        public DecimalNumber(int number)
        {
            _number = number;
        }

        public string ToBinary()
        {
            return Convert.ToString(_number, 2);
        }

        public string ToOctal()
        {
            return Convert.ToString(_number, 8);
        }

        public string ToHexadecimal()
        {
            return Convert.ToString(_number, 16).ToUpper();
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public override string ToString()
        {
            return _number.ToString();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            int inputNumber;
            while (true)
            {
                Console.Write("Enter a decimal number: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out inputNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer between " + int.MinValue + " and " + int.MaxValue);
                }
            }

            DecimalNumber decimalNumber = new DecimalNumber(inputNumber);

            DisplayHelper.DisplayConversions(decimalNumber);
        }
    }
}
