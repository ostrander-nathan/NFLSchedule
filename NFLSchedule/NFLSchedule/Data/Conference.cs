using System;

namespace NFLSchedule.Data;

public record Conference(string Name)
{
    public void AddTeam(string name, string abbreviation, string division)
    {
        if (division.Equals("north", StringComparison.OrdinalIgnoreCase))
            North.Teams.Add(new Team(name,abbreviation));
        
        if (division.Equals("south", StringComparison.OrdinalIgnoreCase))
            South.Teams.Add(new Team(name,abbreviation));
        
        if (division.Equals("east", StringComparison.OrdinalIgnoreCase))
            East.Teams.Add(new Team(name,abbreviation));
        
        if (division.Equals("west", StringComparison.OrdinalIgnoreCase))
            West.Teams.Add(new Team(name,abbreviation));
    }
    public Division North { get; } = new("North");
    public Division South { get; } = new("South");
    public Division East { get; } = new("East");
    public Division West { get; } = new("West");
}