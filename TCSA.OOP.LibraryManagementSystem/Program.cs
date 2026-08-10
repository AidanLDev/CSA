using TCSA.OOP.LibraryManagementSystem;
using Spectre.Console;

bool viewingLibrary = true;

while (viewingLibrary)
{
        Console.Clear();

        MenuOption choice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .Title("What do you want to do next?")
            .AddChoices(Enum.GetValues<MenuOption>()));

        switch (choice)
        {
                case MenuOption.ViewBooks:
                        BooksController.ViewBooks();
                        break;
                case MenuOption.AddBook:
                        BooksController.AddBook();
                        break;
                case MenuOption.DeleteBook:
                        BooksController.DeleteBook();
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

enum MenuOption
{
        ViewBooks,
        AddBook,
        DeleteBook,
        Exit
}
