using System;

public class InvalidSongException : Exception
{
    public override string Message
    {
        get { return "Invalid song."; }
    }
}