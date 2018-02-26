public class InvalidSongSecondsException : InvalidSongLengthException
{
    public override string Message
    {
        get { return "Song seconds should be between 0 and 59."; }
    }
}