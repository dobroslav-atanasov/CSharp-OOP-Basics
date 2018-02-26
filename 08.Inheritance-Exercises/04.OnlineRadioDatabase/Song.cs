public class Song
{
    private const int ArtistMinNameLength = 3;
    private const int ArtistMaxNameLength = 20;
    private const int SongMinNameLength = 3;
    private const int SongMaxNameLength = 30;
    private const int MinutesMin = 0;
    private const int MinutesMax = 14;
    private const int SecondsMin = 0;
    private const int SecondsMax = 59;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public int Seconds
    {
        get { return this.seconds; }
        set
        {
            if (value < SecondsMin || value > SecondsMax)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        set
        {
            if (value < MinutesMin || value > MinutesMax)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        set
        {
            if (value.Length < SongMinNameLength || value.Length > SongMaxNameLength)
            {
                throw new InvalidSongNameException();
            }
            this.songName = value;
        }
    }

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
            if (value.Length < ArtistMinNameLength || value.Length > ArtistMaxNameLength)
            {
                throw new InvalidArtistNameException();
            }
            this.artistName = value;
        }
    }
}