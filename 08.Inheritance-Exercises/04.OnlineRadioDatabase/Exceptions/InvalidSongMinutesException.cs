public class InvalidSongMinutesException : InvalidSongLengthException
{
    public override string Message
    {
        get { return "Song minutes should be between 0 and 14."; }
    }
}