// string[] menuChoice = ["View Books", "Add Book", "Delete Book"];
var menuChoices = new string[3] { "View Books", "Add Book", "Delete Book" };

var choice = AnsiConsole.Prompt(
        new SelectionPrompt&lt;string&gt;()
        .Title("What do you want to do next?")
        .AddChoices(menuChoices));
