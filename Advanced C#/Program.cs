using Lab_1;

string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string filePath = projectFolder + Path.DirectorySeparatorChar + "Videogames.csv";
string filePathbookmark = projectFolder + Path.DirectorySeparatorChar + "bookmarks.csv";
List<Videogames> listOfGames = new List<Videogames>();
Queue<Videogames> bookMarkedGames = new Queue<Videogames>();
//This whole thing just lists the games into lists
using (var sr = new StreamReader(filePath))
{
    while (!sr.EndOfStream)
    {
        string? line = sr.ReadLine();
        string[] lineElements = line.Split(',');
        Videogames game = new Videogames();
        {
            game.Name = lineElements[0];
            game.Platform = lineElements[1];
            game.Year = lineElements[2];
            game.Genre = lineElements[3];
            game.Publisher = lineElements[4];
            game.NASales = lineElements[5];
            game.EUSales = lineElements[6];
            game.JPSales = lineElements[7];
            game.OtherSales = lineElements[8];
            game.GlobalSales = lineElements[9];
        }
        listOfGames.Add(game);
    }
}

//Same thing but different file
using (var sr = new StreamReader(filePathbookmark))
{
    while (!sr.EndOfStream)
    {
        string? line = sr.ReadLine();
        string[] lineElements = line.Split(',');
        Videogames game = new Videogames();
        {
            game.Name = lineElements[0];
            game.Platform = lineElements[1];
            game.Year = lineElements[2];
            game.Genre = lineElements[3];
            game.Publisher = lineElements[4];
            game.NASales = lineElements[5];
            game.EUSales = lineElements[6];
            game.JPSales = lineElements[7];
            game.OtherSales = lineElements[8];
            game.GlobalSales = lineElements[9];
        }
        bookMarkedGames.Enqueue(game);
    }
}

//Sort the list for some reason (Dosent really matter tbh)
listOfGames.Sort();

//I created a Dictinary that usees publisher names as the key, and links it to a list of games created by that publisher
var gamePublishers = new Dictionary<string, List<Videogames>>();

//sorts out so that there are only unique keys
IEnumerable<string> uniqueItems = listOfGames.Select(game => game.Publisher).Distinct();

//adds games to the publisher's list
foreach (string publisher in uniqueItems)
{
    List<Videogames> publishersGames = new List<Videogames>();

    foreach (var game in listOfGames)
    {
        if (game.Publisher == publisher)
        {
            publishersGames.Add(game);
        }    
    }

    gamePublishers.Add(publisher, publishersGames);
}

//Variables
bool check = false;
string userInput = "";
int index = 0;
bool exitProgram = false;
Stack<Videogames> chosenPublisher = new Stack<Videogames>();

//User Side of the program
while (!check)
{
    Console.WriteLine("Please Enter the publisher you are looking for: ");
    Console.WriteLine("(if you need a list of each publisher, please type publisher)");
    Console.WriteLine("If you wish to look at your bookmarked games type BookMarks");
    userInput = Console.ReadLine();
    bool publisherExists = listOfGames.Any(game => game.Publisher == userInput);
    if (publisherExists)
    {
        check = true;
        userInput = userInput;
    }
    else if (userInput.ToLower() == "publisher")
    {
        var listOfKeys = gamePublishers.Keys.ToList();
        foreach (var item in listOfKeys)
        Console.WriteLine(item);
    }
    else if(userInput.ToLower() == "bookmarks")
    {
        foreach (var item in bookMarkedGames)
            Console.WriteLine(item);
    }
    else
    {
        Console.WriteLine("Publisher not found in the list. Please try again.\n\n");
    }
}
foreach (var item in gamePublishers[userInput])
    chosenPublisher.Push(item);

//second half of the user side of the program
while (!exitProgram)
{
    Console.Clear();
    Console.WriteLine("Use the Left arrow key to view the previous game from the company, use the right to view the next game! \n(Press the up or down arrow to exit)\n Press Enter to Bookmark this Game! ");

    if (index > chosenPublisher.Count -1)
        index = 0;
    else if (index < 0)
        index = chosenPublisher.Count - 1;
    string stackItem = chosenPublisher.ElementAt(index).ToString();
    Console.WriteLine(stackItem);
    var userButton = Console.ReadKey();
    switch (userButton.Key)
    {
            case ConsoleKey.LeftArrow: index--;
            break;
            case ConsoleKey.RightArrow: index++;
            break;
            case ConsoleKey.UpArrow: exitProgram = true;
            break;
            case ConsoleKey.DownArrow: exitProgram = true;
            break;
            case ConsoleKey.Enter: bookMarkedGames.Enqueue(chosenPublisher.ElementAt(index));
            Console.WriteLine("Game BookMarked!");
            break;
    }
        
}

//Writes to the bookmark File
using (var sw = new StreamWriter(filePathbookmark))
{
 foreach (var item in bookMarkedGames)
        sw.WriteLine($"{item.Name},{item.Platform},{item.Year},{item.Genre},{item.Publisher},{item.NASales},{item.EUSales},{item.JPSales},{item.OtherSales},{item.GlobalSales}");
}






