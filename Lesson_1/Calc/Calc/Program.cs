namespace Calc
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool keepCalculating = true;
            double? savedResult = null; 

            while (keepCalculating)
            {
                DisplaySavedResult(savedResult);

                int operation = MultipleChoice(false, CalculatorOptions.Exit);

                if (operation == (int)CalculatorOptions.Exit)
                {
                    keepCalculating = false;
                    Console.WriteLine("Exiting Calc Pro. Goodbye!)))");
                    break;
                }

                double num1 = GetFirstNumber(savedResult);
                double result = 0;

                if ((CalculatorOptions)operation == CalculatorOptions.SquareRoot || (CalculatorOptions)operation == CalculatorOptions.Square)
                {
                    switch ((CalculatorOptions)operation)
                    {
                        case CalculatorOptions.SquareRoot:
                            result = Calculator.FindSquareRoot(num1);
                            break;
                        case CalculatorOptions.Square:
                            result = Calculator.FindSquare(num1);
                            break;
                    }
                }
                else
                {
                    double num2 = GetValidNumber("Enter the second number:");

                    switch ((CalculatorOptions)operation)
                    {
                        case CalculatorOptions.Addition:
                            result = Calculator.Add(num1, num2);
                            break;
                        case CalculatorOptions.Subtraction:
                            result = Calculator.Subtract(num1, num2);
                            break;
                        case CalculatorOptions.Multiplication:
                            result = Calculator.Multiply(num1, num2);
                            break;
                        case CalculatorOptions.Division:
                            result = Calculator.Divide(num1, num2);
                            break;
                        case CalculatorOptions.FindPercent:
                            result = Calculator.FindPercent(num1, num2);
                            break;
                        case CalculatorOptions.Power:
                            result = Calculator.RankToPower(num1, num2);
                            break;
                    }
                }

                // Check fo validation cases
                if (!double.IsNaN(result))
                {
                    savedResult = AskToSaveResult(result);
                }
                else
                {
                    Console.WriteLine("Operation was not successful. Result not saved.");
                }
            }
        }
        /// <summary>
        /// Get first nimber from user or use saved result from previous calculation
        /// </summary>
        public static double GetFirstNumber(double? savedResult)
        {
            if (savedResult.HasValue)
            {
                Console.WriteLine($"Saved result: {savedResult.Value}. Do you want to use it as the first number? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    return savedResult.Value;
                }
            }

            return GetValidNumber("\nEnter the first number:");
        }
        /// <summary>
        /// Show saved result for cases when it's present
        /// </summary>
        public static void DisplaySavedResult(double? savedResult)
        {
            Console.Clear(); // Очищаємо консоль

            if (savedResult.HasValue)
            {
                Console.WriteLine($"Saved result: {savedResult.Value}");
            }
            else
            {
                Console.WriteLine("No saved result.");
            }

            Console.WriteLine("\nSelect an operation:\n");
        }
        /// <summary>
        /// Save result in memory for future calculation if needed 
        /// </summary>
        public static double? AskToSaveResult(double result)
        {
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Do you want to save the result {result} for the next operation? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine($"Result {result} saved.");
                return result;
            }
            else
            {
                return null;
            }
        }
        public static double GetValidNumber(string prompt)
        {
            double result;
            bool validInput = false;

            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                // Try to parse the input to a double
                if (double.TryParse(input, out result))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

            } while (!validInput);

            return result;
        }

        /// <summary>
        /// Enum-based Menu for user to select an option using arrow keys with borders
        /// </summary>

        // That's not my owned method and but I've modified it and used on Hillel previous course. Taken from here https://dijix.com.ua/blog/uk/kak-sdelat-menyu-v-konsoli-c/
        public static int MultipleChoice(bool canCancel, Enum userEnum, int spacingPerLine = 18, int optionsPerLine = 2,
                                         int startX = 1, int startY = 1)
        {
            int currentSelection = 0;
            ConsoleKey key;
            Console.CursorVisible = false;
            int length = Enum.GetValues(userEnum.GetType()).Length;

            do
            {
                Console.Clear();

                // Display options from the Enum with borders
                for (int i = 0; i < length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    // Get the operation symbol instead of the word
                    string optionText = GetOperationSymbol((CalculatorOptions)i);
                    string buttonText = $"[{optionText}]";

                    // Highlight the current selection
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.White;
                    }

                    // Display the button text
                    Console.Write(buttonText);

                    // Reset color
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                // Arrow key navigation for menu
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (currentSelection % optionsPerLine > 0)
                            currentSelection--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentSelection % optionsPerLine < optionsPerLine - 1)
                            currentSelection++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (currentSelection >= optionsPerLine)
                            currentSelection -= optionsPerLine;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentSelection + optionsPerLine < length)
                            currentSelection += optionsPerLine;
                        break;
                    case ConsoleKey.Escape:
                        if (canCancel)
                            return -1;
                        break;
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }
        /// <summary>
        /// Transforms words into the math sumbols
        /// </summary>
        public static string GetOperationSymbol(CalculatorOptions option)
        {
            switch (option)
            {
                case CalculatorOptions.Addition:
                    return "+";
                case CalculatorOptions.Subtraction:
                    return "-";
                case CalculatorOptions.Multiplication:
                    return "*";
                case CalculatorOptions.Division:
                    return "/";
                case CalculatorOptions.FindPercent:
                    return "%";
                case CalculatorOptions.Power:
                    return "^";
                case CalculatorOptions.SquareRoot:
                    return "√";
                case CalculatorOptions.Square:
                    return "x²";
                case CalculatorOptions.Exit:
                    return "Exit";
                default:
                    return option.ToString();
            }
        }
    }
}
