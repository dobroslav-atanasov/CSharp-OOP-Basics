using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string input = Console.ReadLine();
        while (true)
        {
            List<string> arguments = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = arguments[0];
            arguments.Remove(command);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.draftManager.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(this.draftManager.RegisterProvider(arguments));
                    break;
                case "Day":
                    Console.WriteLine(this.draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(this.draftManager.Mode(arguments));
                    break;
                case "Check":
                    Console.WriteLine(this.draftManager.Check(arguments));
                    break;
                case "Shutdown":
                    Console.WriteLine(this.draftManager.ShutDown());
                    return;
            }

            input = Console.ReadLine();
        }
    }
}