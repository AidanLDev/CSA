using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Calculator.CalculatorLibrary;
using Microsoft.Calculator.CalculatorLibrary.Enums;
using Microsoft.Calculator.CalculatorLibrary.Models;

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
  private static OperationType GetValidOperationType()
  {
    // Ask the user to choose an operator.
    Console.WriteLine("Choose an operator from the following list:");
    Console.WriteLine("\ta - Add");
    Console.WriteLine("\ts - Subtract");
    Console.WriteLine("\tm - Multiply");
    Console.WriteLine("\td - Divide");
    Console.Write("Your option? ");

    string? opInput = Console.ReadLine();

    while (opInput == null || !Regex.IsMatch(opInput, "^(a|s|m|d)$"))
    {
      Console.WriteLine("This is not a valid option. Please choose a, s, m or d");
      opInput = Console.ReadLine();
    }

    OperationType op = opInput switch
    {
      "a" => OperationType.Add,
      "s" => OperationType.Subtract,
      "m" => OperationType.Multiply,
      _ => OperationType.Divide,
    };

    return op;
  }

  private static MenuChoice GetValidMenuChoice()
  {
    Console.WriteLine("View history (h) or new calculation (c)?: ");
    string? choiceInput = Console.ReadLine();

    while (choiceInput == null || !Regex.IsMatch(choiceInput, "^(h|c)$"))
    {
      Console.WriteLine($"{choiceInput} is not a valid option, please choose (h)istory or (c)alculation");
      choiceInput = Console.ReadLine();
    }

    MenuChoice choice = choiceInput switch
    {
      "c" => MenuChoice.Calculation,
      _ => MenuChoice.History
    };

    return choice;
  }
  private static void Calculation()
  {
    // Ask the user to type the first number.
    Console.Write("Type a number, and then press Enter: ");
    double cleanNum1 = GetValidNumber();

    // Ask the user to type the second number.
    Console.Write("Type another number, and then press Enter: ");
    double cleanNum2 = GetValidNumber();

    double result;
    OperationType op = GetValidOperationType();

    try
    {
      result = calc.DoOperation(cleanNum1, cleanNum2, op);
      if (double.IsNaN(result))
      {
        Console.WriteLine("This operation will result in a mathematical error.\n");
      }
      else
      {
        Console.WriteLine("Your result: {0:0.##}\n", result);
        Console.WriteLine($"Calculations completed - {calc.GetCalculatorCount()}");
      }
    }
    catch (Exception e)
    {
      Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
    }
  }
  private static void DisplayHistory()
  {
    List<CalculationRecord> history = calc.GetHistory();
    for (int i = 0; i < history.Count; i++)
    {
      CalculationRecord record = history[i];
      Console.WriteLine($"{i + 1}. {record.Num1} {record.Operation} {record.Num2} = {record.Result}");
    }
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
      if (calc.GetCalculatorCount() >= 1)
      {
        MenuChoice choice = GetValidMenuChoice();
        if (choice == MenuChoice.Calculation)
        {
          Calculation();
        }
        else
        {
          DisplayHistory();
        }
      }
      else
      {
        Calculation();
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