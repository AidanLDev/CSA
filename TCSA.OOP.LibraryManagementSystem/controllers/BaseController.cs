using Spectre.Console;
namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal abstract class BaseController
{
  protected void DisplayMessage(string message, string colour = "yellow")
  {
    AnsiConsole.MarkupLine($"[{colour}]{message}[/]");
  }

  protected bool ConfirmDeletion(string itemName)
  {
    return AnsiConsole.Confirm($"Are you sure you want to delete [red]{itemName}[/]?");
  }
}