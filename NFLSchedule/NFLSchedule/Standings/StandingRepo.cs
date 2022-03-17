using System.Globalization;
using System.IO;
using CsvHelper;

namespace NFLSchedule.Standings;

public class StandingRepo
{
    public StandingRepo()
    {
        using var reader = new StreamReader("standings.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<RawData>();
    }
    
    
}