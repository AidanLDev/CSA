using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

internal static class BooksController
{
    private static List<string> books = ["The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"];

    private static void continuePrompt()
    {
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    internal static void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
        foreach (string book in books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
        }

        continuePrompt();
    }

    internal static void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add");

        if (books.Contains(title))
        {
            AnsiConsole.MarkupLine($"Library already has [red]{title}[/]");
        }
        else
        {
            books.Add(title);
        }

        continuePrompt();
    }

    internal static void DeleteBook()
    {
        if (books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books to delete, library is empty[/]");
            Console.ReadLine();
            return;
        }

        string bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete")
            .AddChoices(books)
        );

        if (books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine($"[green]{bookToDelete} was successfully removed[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found[/]");
        }
        continuePrompt();
    }
}
