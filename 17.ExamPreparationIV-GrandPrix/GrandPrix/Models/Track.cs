public class Track
{
    public Track(int totalLaps, int length)
    {
        this.TotalLaps = totalLaps;
        this.Length = length;
        this.CurrentLap = 0;
        this.Weather = "Sunny";
    }

    public int TotalLaps { get; }

    public int Length { get; }

    public int CurrentLap { get; set; }

    public string Weather { get; set; }
}