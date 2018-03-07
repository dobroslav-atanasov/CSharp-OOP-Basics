using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : CasualRace
{
    private int laps;
    
    public CircuitRace(int length, string route, int prizePool, int laps) 
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps
    {
        get { return this.laps; }
        set { this.laps = value; }
    }

    public override string StartRace()
    {
        for (int i = 0; i < this.Laps; i++)
        {
            foreach (KeyValuePair<int, Car> car in this.Participants)
            {
                car.Value.Durability -= this.Length * this.Length;
            }
        }

        Dictionary<int, int> raceResults = new Dictionary<int, int>();
        foreach (KeyValuePair<int, Car> car in this.Participants)
        {
            int carPoints = this.GetPoints(car.Key);
            raceResults.Add(car.Key, carPoints);
        }

        Dictionary<int, int> winners = raceResults
            .OrderByDescending(c => c.Value)
            .Take(4)
            .ToDictionary(k => k.Key, v => v.Value);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");
        int position = 1;
        foreach (KeyValuePair<int, int> winner in winners)
        {
            Car car = this.Participants[winner.Key];
            sb.AppendLine($"{position}. {car.Brand} {car.Model} {winner.Value}PP - ${this.GetPrize()[position - 1]}");
            position++;
        }
        return sb.ToString().Trim();
    }

    public override List<int> GetPrize()
    {
        List<int> prizes = new List<int>();
        prizes.Add(this.PrizePool * 40 / 100);
        prizes.Add(this.PrizePool * 30 / 100);
        prizes.Add(this.PrizePool * 20 / 100);
        prizes.Add(this.PrizePool * 10 / 100);
        return prizes;
    }
}