using System.Collections.Generic;
using System.Linq;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public List<Monument> Monuments
    {
        get { return this.monuments; }
        set { this.monuments = value; }
    }

    public List<Bender> Benders
    {
        get { return this.benders; }
        set { this.benders = value; }
    }

    public double TotalPower => this.GetTotalPower();

    private double GetTotalPower()
    {
        double bendersPower = this.Benders.Sum(b => b.GetBenderPower());
        double monumentPower = this.Monuments.Sum(m => m.GetMomumentPower());
        double totalPower = bendersPower + ((bendersPower / 100) * monumentPower);
        return totalPower;
    }
}