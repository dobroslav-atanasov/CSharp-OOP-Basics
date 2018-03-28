using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    private const int SilverTimePrize = 50;
    private const int BronzeTimePrize = 30;

    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime) 
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime
    {
        get { return this.goldTime; }
        set { this.goldTime = value; }
    }

    public override void AddParticipants(int carId, Car car)
    {
        if (this.Participants.Count == 0)
        {
            base.Participants.Add(carId, car);
        }
    }
    
    public override int GetPoints(int carId)
    {
        Car car = base.Participants[carId];
        return this.Length * ((car.Horsepower / 100) * car.Acceleration);
    }

    public override string StartRace()
    {
        KeyValuePair<int, Car> car = base.Participants.ElementAt(0);
        int time = this.GetPoints(car.Key);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}")
            .AppendLine($"{car.Value.Brand} {car.Value.Model} - {time} s.");

        if (time <= this.GoldTime)
        {
            sb.Append($"Gold Time, ${this.PrizePool}.");
        }
        else if (time <= this.GoldTime + 15)
        {
            sb.Append($"Silver Time, ${this.PrizePool * SilverTimePrize / 100}.");
        }
        else if (time > this.GoldTime + 15)
        {
            sb.Append($"Bronze Time, ${this.PrizePool * BronzeTimePrize / 100}.");
        }
        return sb.ToString();
    }
}