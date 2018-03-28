using System.Collections.Generic;

public class CarFactory
{
    public static Car CreateCar(List<string> commandArgs, Tyre tyre)
    {
        return new Car(int.Parse(commandArgs[0]), double.Parse(commandArgs[1]), tyre);
    }
}