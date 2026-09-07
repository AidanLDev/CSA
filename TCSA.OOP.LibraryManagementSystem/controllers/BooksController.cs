using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal class BooksController : BaseController, IBaseController
{
    private void ContinuePrompt()
    {
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    public void ViewItems()
    {
        Table table = new();
        table.Border = TableBorder.Rounded;

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        var books = MockDatabase.LibraryItems.OfType<Book>();

        DisplayMessage("[yellow]List of books:[/]");
        foreach (Book book in books)
        {
            table.AddRow(book.Id.ToString(),
            $"[cyan]{book.Name}[/]",
            $"[cyan]{book.Author}[/]",
            $"[green]{book.Category}[/]",
            $"[blue]{book.Location}[/]",
            book.Pages.ToString());
        }

        AnsiConsole.Write(table);

        ContinuePrompt();
    }

    public void AddItem()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
        var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

        if (MockDatabase.LibraryItems.OfType<Book>().Any(book => book.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            DisplayMessage($"Library already has {title}", "red");
        }
        else
        {
            Book newBook = new(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
            MockDatabase.LibraryItems.Add(newBook);
        }

        ContinuePrompt();
    }

    public void DeleteItem()
    {
        var books = MockDatabase.LibraryItems.OfType<Book>().ToList();
        if (books.Count == 0)
        {
            DisplayMessage("No books to delete, library is empty", "red");
            Console.ReadLine();
            return;
        }

        Book bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
            .Title("Select a [red]book[/] to delete")
            .UseConverter(book => $"{book.Name}")
            .AddChoices(books)
        );

        if (ConfirmDeletion(bookToDelete.Name))
        {
            if (MockDatabase.LibraryItems.Remove(bookToDelete))
            {
                DisplayMessage($"{bookToDelete.Name} was successfully removed", "green");
            }
            else
            {
                DisplayMessage("Book not found", "red");
            }
        }

        ContinuePrompt();
    }
}
