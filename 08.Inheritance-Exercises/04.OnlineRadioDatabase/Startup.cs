using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Song> songs = new List<Song>();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] inputParts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (inputParts.Length != 3)
                {
                    throw new InvalidSongException();
                }
                ParseSong(songs, inputParts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        PrintTotalTime(songs);
    }

    private static void ParseSong(List<Song> songs, string[] inputParts)
    {
        string[] time = inputParts[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        int minutes;
        int seconds;
        if (int.TryParse(time[0], out minutes) && int.TryParse(time[1], out seconds))
        {
            Song song = new Song(inputParts[0], inputParts[1], minutes, seconds);
            songs.Add(song);
            Console.WriteLine("Song added.");
        }
        else
        {
            throw new InvalidSongLengthException();
        }
    }

    private static void PrintTotalTime(List<Song> songs)
    {
        long totalSecond = songs.Sum(m => m.Minutes * 60) + songs.Sum(s => s.Seconds);
        TimeSpan ts = TimeSpan.FromSeconds(totalSecond);
        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {ts.Hours}h {ts.Minutes}m {ts.Seconds}s");
    }
}