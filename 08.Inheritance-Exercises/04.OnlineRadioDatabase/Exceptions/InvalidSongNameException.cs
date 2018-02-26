public class InvalidSongNameException : InvalidSongException
{
    public override string Message
    {
        get { return "Song name should be between 3 and 30 symbols."; }
    }
}