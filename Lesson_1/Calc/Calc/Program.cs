namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepCalculating = true;
 
            int operation = MultipleChoice(false, CalculatorOptions.Exit);

            if (operation == (int)CalculatorOptions.Exit)
            {
                keepCalculating = false;
                Console.WriteLine("Exiting Calc Pro. Goodbye!");
                
            }

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
