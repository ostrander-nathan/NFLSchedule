namespace NFLSchedule.Data;

public record RawData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Conference { get; set; }
    public string Division { get; set; }
}