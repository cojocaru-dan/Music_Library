
namespace Codecool.MusicLibrary.Ui;

public class MusicLibraryUi
{
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
                //...
            }
            //...
        }


    }

    private static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to Codecool Music Library.");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("1 - Add Song");
        Console.WriteLine("2 - View Library");
        Console.WriteLine("3 - Search Songs");
        Console.WriteLine("4 - Remove Song");
        Console.WriteLine("5 - Clear Library");
        Console.WriteLine("6 - Exit");
    }

    private static int GetCode()
    {
        return int.Parse(Console.ReadLine());
    }
    
    
    private static void AddSong()
    {
    }
    
    private static void ViewLibrary()
    {
    }
}