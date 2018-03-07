using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> Cars;
    private Dictionary<int, Race> Races;
    private Garage Garage;
    private List<int> IdClosedRace;

    public CarManager()
    {
        this.Cars = new Dictionary<int, Car>();
        this.Races = new Dictionary<int, Race>();
        this.Garage = new Garage();
        this.IdClosedRace = new List<int>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Performance":
                PerformanceCar performanceCar = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                this.Cars.Add(id, performanceCar);
                break;
            case "Show":
                ShowCar showCar = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                this.Cars.Add(id, showCar);
                break;
        }
    }

    public string Check(int id)
    {
        return this.Cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                CasualRace casualRace = new CasualRace(length, route, prizePool);
                this.Races.Add(id, casualRace);
                break;
            case "Drag":
                DragRace dragRace = new DragRace(length, route, prizePool);
                this.Races.Add(id, dragRace);
                break;
            case "Drift":
                DriftRace driftRace = new DriftRace(length, route, prizePool);
                this.Races.Add(id, driftRace);
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.Garage.ParkedCars.Contains(this.Cars[carId]))
        {
            if (!this.IdClosedRace.Contains(raceId))
            {
                this.Races[raceId].AddParticipants(carId, this.Cars[carId]);
            }
        }
    }

    public string Start(int id)
    {
        if (this.Races[id].Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        this.IdClosedRace.Add(id);
        return this.Races[id].StartRace();
    }

    public void Park(int id)
    {
        foreach (KeyValuePair<int, Race> race in this.Races.Where(r => !this.IdClosedRace.Contains(r.Key)))
        {
            if (race.Value.Participants.ContainsKey(id))
            {
                return;
            }
        }
        this.Garage.ParkedCars.Add(this.Cars[id]);
    }

    public void Unpark(int id)
    {
        this.Garage.ParkedCars.Remove(this.Cars[id]);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (Car car in this.Garage.ParkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }

    public void OpenSpecialRace(int id, string type, int length, string route, int prizePool, int extraParameter)
    {
        switch (type)
        {
            case "TimeLimit":
                TimeLimitRace timeLimitRace = new TimeLimitRace(length, route, prizePool, extraParameter);
                this.Races.Add(id, timeLimitRace);
                break;
            case "Circuit":
                CircuitRace circuitRace = new CircuitRace(length, route, prizePool, extraParameter);
                this.Races.Add(id, circuitRace);
                break;
        }
    }
}