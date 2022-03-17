using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace NFLSchedule.Standings;

public class StandingRepo
{
    List<Standing> _standings;
    public StandingRepo()
    {
        using var reader = new StreamReader("./standings/standings.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<RawData>();

        var afc = new Conference("AFC");
        var nfc = new Conference("NFC");

        foreach (var data in records)
        {
            if (data.Conference.Equals("nfc", StringComparison.OrdinalIgnoreCase))
            {
                nfc.AddTeam(data.Team, data.Wins, data.Losses, data.Ties, data.Division);
            }
            if (data.Conference.Equals("afc", StringComparison.OrdinalIgnoreCase))
            {
                afc.AddTeam(data.Team, data.Wins, data.Losses, data.Ties, data.Division);
            }
        }
        
    }
    
}


public record Standing
{
    public int Year { get; set;}

    public Conference NFC { get;set;}

    public Conference AFC { get; set; }

}

public record Conference(string Name) 
{
    public void AddTeam(string name, int wins, int losses, int ties, string division)
    {
        if (division.Equals("north", StringComparison.OrdinalIgnoreCase))
            North.Teams.Add(new Team(name, wins, losses, ties));

        if (division.Equals("south", StringComparison.OrdinalIgnoreCase))
            South.Teams.Add(new Team(name, wins, losses, ties));

        if (division.Equals("east", StringComparison.OrdinalIgnoreCase))
            East.Teams.Add(new Team(name, wins, losses, ties));

        if (division.Equals("west", StringComparison.OrdinalIgnoreCase))
            West.Teams.Add(new Team(name, wins, losses, ties));
    }
    public Division North { get; } = new("North");
    public Division South { get; } = new("South");
    public Division East { get; } = new("East");
    public Division West { get; } = new("West");
}

public record Division(string Name)
{
    public List<Team> Teams { get; } = new();
}

public record Team(string Name, int Wins, int Loosses, int Ties);