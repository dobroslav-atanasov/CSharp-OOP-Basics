using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.length = length;
        this.route = route;
        this.prizePool = prizePool;
        this.participants = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> Participants
    {
        get { return this.participants; }
        set { this.participants = value; }
    }

    public int PrizePool
    {
        get { return this.prizePool; }
        set { this.prizePool = value; }
    }

    public string Route
    {
        get { return this.route; }
        set { this.route = value; }
    }

    public int Length
    {
        get { return this.length; }
        set { this.length = value; }
    }

    public abstract int GetPoints(int carId);

    public virtual void AddParticipants(int carId, Car car)
    {
        this.Participants.Add(carId, car);
    }

    public virtual string StartRace()
    {
        Dictionary<int, int> raceResults = new Dictionary<int, int>();
        foreach (KeyValuePair<int, Car> car in this.Participants)
        {
            int carPoints = this.GetPoints(car.Key);
            raceResults.Add(car.Key, carPoints);
        }

        Dictionary<int, int> winners = raceResults
            .OrderByDescending(r => r.Value)
            .Take(3)
            .ToDictionary(k => k.Key, v => v.Value);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");
        int position = 1;
        foreach (KeyValuePair<int, int> winner in winners)
        {
            Car car = this.Participants[winner.Key];
            sb.AppendLine($"{position}. {car.Brand} {car.Model} {winner.Value}PP - ${this.GetPrize()[position - 1]}");
            position++;
        }
        return sb.ToString().Trim();
    }

    public virtual List<int> GetPrize()
    {
        List<int> prizes = new List<int>();
        prizes.Add(this.PrizePool * 50 / 100);
        prizes.Add(this.PrizePool * 30 / 100);
        prizes.Add(this.PrizePool * 20 / 100);
        return prizes;
    }
}