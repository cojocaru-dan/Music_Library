using Codecool.MusicLibrary.Model;
using Codecool.MusicLibrary.Ui;

namespace Codecool.MusicLibrary;

public class Program
{
    #region Songs
    private static Song[] _songs =
    {
        new("Drivers License", "Olivia Rodrigo", 242),
        new("Good 4 U", "Olivia Rodrigo", 178),
        new("Levitating", "Dua Lipa", 203),
        new("Don't Start Now", "Dua Lipa", 183),
        new("Blinding Lights", "The Weeknd", 201),
        new("Save Your Tears", "The Weeknd", 215),
        new("Montero (Call Me By Your Name)", "Lil Nas X", 137),
        new("Old Town Road", "Lil Nas X", 113),
        new("Peaches", "Justin Bieber", 198),
        new("Stay", "The Kid LAROI, Justin Bieber", 141),
        new("Watermelon Sugar", "Harry Styles", 174),
        new("Adore You", "Harry Styles", 207),
        new("Positions", "Ariana Grande", 173),
        new("Thank U, Next", "Ariana Grande", 207),
        new("Intentions", "Justin Bieber ft. Quavo", 212),
        new("Lonely", "Justin Bieber, Benny Blanco", 149),
        new("Kiss Me More", "Doja Cat ft. SZA", 208),
        new("Say So", "Doja Cat", 237),
        new("Dynamite", "BTS", 199),
        new("Butter", "BTS", 164),
    };
    #endregion

    public static void Main(string[] args)
    {
        var ui = new MusicLibraryUi();
        ui.Run();
    }
}