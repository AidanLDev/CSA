using Spectre.Console;
string[] menuChoices = ["View Books", "Add Book", "Delete Book", "Exit"];
List<string> books = ["The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"];

void continuePrompt()
{
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
}

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
                        AnsiConsole.MarkupLine("[yellow]List of books:[/]");
                        foreach (string book in books)
                        {
                                AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
                        }

                        continuePrompt();

                        break;
                case MenuOption.AddBook:
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
                        break;
                case MenuOption.DeleteBook:
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
