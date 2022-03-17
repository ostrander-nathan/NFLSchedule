namespace NFLSchedule.Standings;

public record RawData
{
    public int Season { get; set; }
    public string Conference { get; set; }
    public string Division { get; set; }
    public string Team { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Ties { get; set; }
    public decimal Pct { get; set; }
    public int DivRank { get; set; }
}