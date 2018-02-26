public class InvalidSongLengthException : InvalidSongException
{
    public override string Message
    {
        get { return "Invalid song length."; }
    }
}