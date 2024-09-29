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
        static void Main(string[] args)
        {
            Console.Write("Enter a decimal number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int inputNumber))
            {
                DecimalNumber decimalNumber = new DecimalNumber(inputNumber);

                Console.WriteLine("Decimal Number: " + decimalNumber.Number);
                Console.WriteLine("Binary: " + decimalNumber.ToBinary());
                Console.WriteLine("Octal: " + decimalNumber.ToOctal());
                Console.WriteLine("Hexadecimal: " + decimalNumber.ToHexadecimal());
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer between " + int.MinValue + " and " + int.MaxValue);
            }
        }
    }
}
