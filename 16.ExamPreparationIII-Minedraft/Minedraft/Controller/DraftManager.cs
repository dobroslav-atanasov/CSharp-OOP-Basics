using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private const double HalfModeEnergyRequirments = 60;
    private const double HalfModeOreOutput = 50;

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
        string type = arguments[0];
        string id = arguments[1];
        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(id, harvester);
            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        try
        {
            Provider provider = ProviderFactory.CreateProvider(arguments);
            this.providers.Add(id, provider);
            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double totalHarvesterEnergy = this.harvesters.Sum(e => e.Value.EnergyRequirement);
        double summedEnergyOutput = this.providers.Sum(e => e.Value.EnergyOutput);
        double summedOreOutput = 0;

        this.totalEnergyStored += summedEnergyOutput;

        if (this.mode == "Full" && totalHarvesterEnergy <= this.totalEnergyStored)
        {
            summedOreOutput = this.harvesters.Sum(o => o.Value.OreOutput);
            this.totalEnergyStored -= totalHarvesterEnergy;
            this.totalMinedOre += summedOreOutput;
        }
        else if (this.mode == "Half")
        {
            double halfTotalHarvesterEnergy = totalHarvesterEnergy * HalfModeEnergyRequirments / 100;
            if (halfTotalHarvesterEnergy <= this.totalEnergyStored)
            {
                summedOreOutput = (this.harvesters.Sum(o => o.Value.OreOutput)) * HalfModeOreOutput / 100;
                this.totalEnergyStored -= halfTotalHarvesterEnergy;
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
        string newMode = arguments[0];
        this.mode = newMode;
        return $"Successfully changed working mode to {newMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string searchedId = arguments[0];
        if (this.harvesters.ContainsKey(searchedId))
        {
            return this.harvesters[searchedId].ToString();
        }
        if (this.providers.ContainsKey(searchedId))
        {
            return this.providers[searchedId].ToString();
        }
        return $"No element found with id - {searchedId}";
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