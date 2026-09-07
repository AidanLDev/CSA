
using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem;
using TCSA.OOP.LibraryManagementSystem.Controllers;

public class UserInterface
{

  private readonly BooksController booksController = new();
  private readonly MagazineController magazineController = new();
  private readonly NewspaperController newspaperController = new();
  internal void MainMenu()
  {
    bool viewingLibrary = true;

    while (viewingLibrary)
    {
      Console.Clear();

      MenuOption choice = AnsiConsole.Prompt(
          new SelectionPrompt<MenuOption>()
          .Title("What do you want to do next?")
          .AddChoices(Enum.GetValues<MenuOption>()));

      ItemType itemTypeChoice = AnsiConsole.Prompt(
        new SelectionPrompt<ItemType>()
        .Title("Choose an item")
        .AddChoices(Enum.GetValues<ItemType>())
      );

      switch (choice)
      {
        case MenuOption.ViewBooks:
          ViewItems(itemTypeChoice);
          break;
        case MenuOption.AddBook:
          AddItems(itemTypeChoice);
          break;
        case MenuOption.DeleteBook:
          DeleteItems(itemTypeChoice);
          break;
        case MenuOption.Exit:
          AnsiConsole.MarkupLine("Thanks for visiting our library");
          viewingLibrary = false;
          break;
        default:
          AnsiConsole.MarkupLine("[red]Unknown option[/]");
          break;
      }
    }
  }

  private void ViewItems(ItemType itemType)
  {
    switch (itemType)
    {
      case ItemType.Book:
        booksController.ViewItems();
        break;
      case ItemType.Magazine:
        magazineController.ViewItems();
        break;
      case ItemType.Newspaper:
        newspaperController.ViewItems();
        break;
    }
  }

  private void AddItems(ItemType itemType)
  {
    switch (itemType)
    {
      case ItemType.Book:
        booksController.AddItem();
        break;
      case ItemType.Magazine:
        magazineController.AddItem();
        break;
      case ItemType.Newspaper:
        newspaperController.AddItem();
        break;
    }
  }

  private void DeleteItems(ItemType itemType)
  {
    switch (itemType)
    {
      case ItemType.Book:
        booksController.DeleteItem();
        break;
      case ItemType.Magazine:
        magazineController.DeleteItem();
        break;
      case ItemType.Newspaper:
        newspaperController.DeleteItem();
        break;
    }
  }

}