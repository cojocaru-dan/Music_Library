using Codecool.MusicLibrary.Model;

namespace Codecool.MusicLibrary.Ui;

public interface ILibrary
{
    List<Song> Songs { get; }
    void AddSong(Song newSong);
    void ViewLibrary();
    List<Song> SearchSongsBy(string artistName);
    bool CheckInexistence(string songNameToRemove);
    void RemoveSong(string songNameToRemove);
    void ClearLibrary();
    void Exit();
}

public class Library : ILibrary
{
    public List<Song> Songs { get; private set; }

    public Library(Song[] songs)
    {
        Songs = new List<Song>(songs);
    } 
    public void AddSong(Song newSong)
    {
        Songs.Add(newSong);
    }

    public void ViewLibrary()
    {
        if (Songs.Count == 0) Console.WriteLine("The library is empty!");
        else
        {
            Console.WriteLine("The library is shown below.");
            List<Song> songsOrderedByArtist = Songs.OrderBy(s => s.Artist).ToList();
            foreach (var orderedSong in songsOrderedByArtist)
            {
                Console.WriteLine(orderedSong);
            }
        }
    }

    public List<Song> SearchSongsBy(string artistName) => Songs.Where(s => s.Artist.Contains(artistName)).ToList();
    public bool CheckInexistence(string songNameToRemove) => Songs.Where(s => s.Title == songNameToRemove).ToList().Count == 0;

    public void RemoveSong(string songNameToRemove)
    {
        Songs.RemoveAll(s => s.Title == songNameToRemove);
    }

    public void ClearLibrary()
    {
        Songs.Clear();
    }

    public void Exit()
    {

    }
}