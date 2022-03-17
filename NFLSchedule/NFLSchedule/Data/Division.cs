using System.Collections.Generic;

namespace NFLSchedule.Data;

public record Division(string Name)
{
    public List<Team> Teams { get; } = new();
}