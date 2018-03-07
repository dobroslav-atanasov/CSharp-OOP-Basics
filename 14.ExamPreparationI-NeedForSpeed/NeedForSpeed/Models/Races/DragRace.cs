public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override int GetPoints(int carId)
    {
        Car car = this.Participants[carId];
        return car.Horsepower / car.Acceleration;
    }
}