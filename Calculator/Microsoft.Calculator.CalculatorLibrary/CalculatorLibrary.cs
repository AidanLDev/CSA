using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.Calculator.CalculatorLibrary.Enums;

namespace Microsoft.Calculator.CalculatorLibrary;

public class Calculator
{
  JsonWriter writer;
  public int CalculatorCount { get; private set; }

  private void AddTrace(double num1, double num2, double result, OperationType op)
  {
    Trace.WriteLine($"{num1} {op} {num2} = {result}");
  }

  public Calculator()
  {
    StreamWriter logFile = File.CreateText("calculator.log");
    Trace.AutoFlush = true;
    writer = new JsonTextWriter(logFile);
    writer.Formatting = Formatting.Indented;
    writer.WriteStartObject();
    writer.WritePropertyName("Operations");
    writer.WriteStartArray();
  }
  public double DoOperation(double num1, double num2, OperationType op)
  {
    double result = double.NaN;
    writer.WriteStartObject();
    writer.WritePropertyName("Operand1");
    writer.WriteValue(num1);
    writer.WritePropertyName("Operand2");
    writer.WriteValue(num2);
    writer.WritePropertyName("Operation");
    writer.WriteValue(op.ToString());
    CalculatorCount++;

    switch (op)
    {
      case OperationType.Add:
        result = num1 + num2;
        AddTrace(num1, num2, result, op);
        break;
      case OperationType.Subtract:
        result = num1 - num2;
        AddTrace(num1, num2, result, op);
        break;
      case OperationType.Multiply:
        result = num1 * num2;
        AddTrace(num1, num2, result, op);
        break;
      case OperationType.Divide:
        if (num2 != 0)
        {
          result = num1 / num2;
          AddTrace(num1, num2, result, op);
        }
        break;
    }

    writer.WritePropertyName("Result");
    writer.WriteValue(result);
    writer.WriteEndObject();

    return result;
  }
  public void Finish()
  {
    writer.WriteEndArray();
    writer.WriteEndObject();
    writer.Close();
  }
}
