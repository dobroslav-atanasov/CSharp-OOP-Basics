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
            List<string> inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputParts[0];
            inputParts.Remove(inputParts[0]);

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.draftManager.RegisterHarvester(inputParts));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(this.draftManager.RegisterProvider(inputParts));
                    break;
                case "Day":
                    Console.WriteLine(this.draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(this.draftManager.Mode(inputParts));
                    break;
                case "Check":
                    Console.WriteLine(this.draftManager.Check(inputParts));
                    break;
                case "Shutdown":
                    Console.WriteLine(this.draftManager.ShutDown());
                    return;
            }
            input = Console.ReadLine();
        }
    }
}