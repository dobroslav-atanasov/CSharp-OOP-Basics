using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private const double HalfModeEnergyConsume = 0.6;
    private const double HalfModeOreProduce = 0.5;

    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalEnergyStored;
    private double totalMinedOre;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(arguments[1], harvester);
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = ProviderFactory.CreateProvider(arguments);
            this.providers.Add(arguments[1], provider);
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double summedEnergyOutput = this.providers.Values.Sum(e => e.EnergyOutput);
        double harvestersEnergy = this.harvesters.Values.Sum(e => e.EnergyRequirement);
        double summedOreOutput = 0;

        this.totalEnergyStored += summedEnergyOutput;

        if (this.mode == "Full" && harvestersEnergy <= this.totalEnergyStored)
        {
            summedOreOutput = this.harvesters.Values.Sum(o => o.OreOutput);
            this.totalEnergyStored -= harvestersEnergy;
            this.totalMinedOre += summedOreOutput;
        }
        else if (this.mode == "Half")
        {
            double halfHarvestersEnergy = harvestersEnergy * HalfModeEnergyConsume;
            if (halfHarvestersEnergy <= this.totalEnergyStored)
            {
                summedOreOutput = this.harvesters.Values.Sum(o => o.OreOutput) * HalfModeOreProduce;
                this.totalEnergyStored -= halfHarvestersEnergy;
                this.totalMinedOre += summedOreOutput;
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"A day has passed.")
            .AppendLine($"Energy Provided: {summedEnergyOutput}")
            .Append($"Plumbus Ore Mined: {summedOreOutput}");
        return sb.ToString();
    }

    public string Mode(List<string> arguments)
    {
        string modeType = arguments[0];
        switch (modeType)
        {
            case "Full":
                this.mode = modeType;
                return $"Successfully changed working mode to {modeType} Mode";
            case "Half":
                this.mode = modeType;
                return $"Successfully changed working mode to {modeType} Mode";
            case "Energy":
                this.mode = modeType;
                return $"Successfully changed working mode to {modeType} Mode";
            default:
                return null;
        }
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        if (this.harvesters.ContainsKey(id))
        {
            return $"{this.harvesters[id]}";
        }
        if (this.providers.ContainsKey(id))
        {
            return $"{this.providers[id]}";
        }
        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalEnergyStored}")
            .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        return sb.ToString();
    }
}