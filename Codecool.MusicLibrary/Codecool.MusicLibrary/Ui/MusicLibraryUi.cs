
using Codecool.MusicLibrary.Model;
using Codecool.MusicLibrary.logger;

namespace Codecool.MusicLibrary.Ui;

public class MusicLibraryUi
{
    public ILibrary Library { get; private set; }
    private static FileLogger _logger = new FileLogger("FileLogResult.txt");

    public MusicLibraryUi(ILibrary library)
    {
        Library = library;
    }
     
    public void Run()
    {
        DisplayWelcomeMessage();
        
        int code = 0;

        while (code != 6)
        {
            DisplayMenu();
            code = GetCode();
            
            switch (code)
            {
                case 1:
                    AddSong();
                    break;
                case 2:
                    ViewLibrary();
                    break;
                case 3:
                    SearchSongs();
                    break;
                case 4:
                    RemoveSong();
                    break;
                case 5:
                    ClearLibrary();
                    break;
                case 6:
                    Exit();
                    break;
            }
        }
    }

    private static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to Codecool Music Library.");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Choose an option from the menu below.\n");
        Console.WriteLine("1 - Add Song");
        Console.WriteLine("2 - View Library");
        Console.WriteLine("3 - Search Songs");
        Console.WriteLine("4 - Remove Song");
        Console.WriteLine("5 - Clear Library");
        Console.WriteLine("6 - Exit");
    }

    private static int GetCode()
    {
        int[] options = { 1, 2, 3, 4, 5, 6 };
        string Code = Console.ReadLine() ?? "default";
        bool ConvertedCode = Int32.TryParse(Code, out int code);
        while (!ConvertedCode || !options.Any(option => option == code))
        {
            System.Console.WriteLine("The input must be between 1 and 6.");
            Code = Console.ReadLine() ?? "default";
            ConvertedCode = Int32.TryParse(Code, out code);
        }
        return code;
    }

    public void AddSong()
    {
        string song = GetInput("Enter the Song Name: ");
        string artist = GetInput("Enter the Artist Name: ");
        string duration = GetInput("Enter the Duration of the song in Seconds: ");

        Song newSong = new Song(song, artist, Int32.Parse(duration));
        while (Library.Songs.Any(s => s == newSong))
        {
            Console.WriteLine("This Song is already in the library. Choose another song!");

            song = GetInput("Enter the Song Name: ");
            artist = GetInput("Enter the Artist Name: ");
            duration = GetInput("Enter the Duration of the song in Seconds: ");
            newSong = new Song(song, artist, Int32.Parse(duration));
        }
        Library.AddSong(newSong);
        Console.WriteLine("The song was added Successfully!");
        _logger.LogInfo($"{newSong} was added Successfully!");
    }

    public void ViewLibrary()
    {
        Library.ViewLibrary();
    }
    public void SearchSongs()
    {
        Console.WriteLine("Let's search for a song by artist name.");
        string artistName = GetInput("Enter the Artist Name: ");
        _logger.LogInfo($"There was a search for the name '{artistName}'.");
        List<Song> filteredSongsByArtist = Library.SearchSongsBy(artistName);
        if (filteredSongsByArtist.Count == 0) Console.WriteLine($"Songs with Artist Name: {artistName} don't exist in the library.");
        else
        {
            Console.WriteLine("Songs with this artist are shown below.");
            foreach (var filteredSong in filteredSongsByArtist)
            {
                Console.WriteLine(filteredSong);
            }
        }
    }
    public void RemoveSong()
    {
        Console.WriteLine("Let's remove a song by Song Name.");
        string songNameToRemove = GetInput("Enter the Song Name To Remove From The Library: ");
        if (Library.CheckInexistence(songNameToRemove)) Console.WriteLine("This song doesn't exist in the library.");
        else
        {
            Library.RemoveSong(songNameToRemove);
            Console.WriteLine("This song was removed successfully.");
            _logger.LogInfo($"The song '{songNameToRemove}' was removed successfully.");
        }
    }

    public void ClearLibrary()
    {
        Library.ClearLibrary();
        Console.WriteLine("The library is now empty.");
        _logger.LogInfo("The library is empty now!");
    }
    public void Exit()
    {
        Library.Exit();
        Console.WriteLine("The Library is now closed.");
    }
    private static string GetInput(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine() ?? "blank";
        input = input == "" ? "blank" : input;
        while (input == "blank" || (message == "Enter the Duration of the song in Seconds: " && !Int32.TryParse(input, out _)))
        {
            Console.WriteLine("The Input is not valid.");
            _logger.LogError($"{input} is not a valid input.");
            if (message == "Enter the Duration of the song in Seconds: ") Console.WriteLine("You must type a number of seconds.");
            Console.Write(message);
            input = Console.ReadLine() ?? "blank";
            input = input == "" ? "blank" : input;
        }
        return input;
    }
}