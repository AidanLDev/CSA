using System.Text.RegularExpressions;
using Microsoft.Calculator.CalculatorLibrary;

class Program
{
  private static double GetValidNumber()
  {
    string? userInput = Console.ReadLine();
    double cleanInput = 0;
    while (!double.TryParse(userInput, out cleanInput))
    {
      Console.Write("This is not valid input. Please neter a numeric value: ");
      userInput = Console.ReadLine();
    }
    return cleanInput;
  }
  static readonly Calculator calc = new();
  static void Main(string[] args)
  {
    bool endApp = false;
    // Display title as the C# console calculator app.
    Console.WriteLine("Console Calculator in C#\r");
    Console.WriteLine("------------------------\n");

    while (!endApp)
    {
      double result = 0;

      // Ask the user to type the first number.
      Console.Write("Type a number, and then press Enter: ");
      double cleanNum1 = GetValidNumber();

      // Ask the user to type the second number.
      Console.Write("Type another number, and then press Enter: ");
      double cleanNum2 = GetValidNumber();

      // Ask the user to choose an operator.
      Console.WriteLine("Choose an operator from the following list:");
      Console.WriteLine("\ta - Add");
      Console.WriteLine("\ts - Subtract");
      Console.WriteLine("\tm - Multiply");
      Console.WriteLine("\td - Divide");
      Console.Write("Your option? ");

      string? op = Console.ReadLine();

      // Validate input is not null, and matches the pattern
      if (op == null || !Regex.IsMatch(op, "^(a|s|m|d)$"))
      {
        Console.WriteLine("Error: Unrecognized input.");
      }
      else
      {
        try
        {
          result = calc.DoOperation(cleanNum1, cleanNum2, op);
          if (double.IsNaN(result))
          {
            Console.WriteLine("This operation will result in a mathematical error.\n");
          }
          else Console.WriteLine("Your result: {0:0.##}\n", result);
        }
        catch (Exception e)
        {
          Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
        }
      }
      Console.WriteLine("------------------------\n");

      // Wait for the user to respond before closing.
      Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
      if (Console.ReadLine() == "n") endApp = true;

      Console.WriteLine("\n"); // Friendly linespacing.
    }
    calc.Finish();
    return;
  }
}