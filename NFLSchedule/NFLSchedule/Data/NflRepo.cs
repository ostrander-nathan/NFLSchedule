using System;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace NFLSchedule.Data;

public class NflRepo
{
    readonly Nfl _nfl;

    public NflRepo()
    {
        using var reader = new StreamReader("teams.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<RawData>();

        var afc = new Conference("AFC");
        var nfc = new Conference("NFC");
        
        foreach (var data in records)
        {
            if (data.Conference.Equals("nfc", StringComparison.OrdinalIgnoreCase))
            {
                nfc.AddTeam(data.Name, data.Abbreviation, data.Division);
            }
            if (data.Conference.Equals("afc", StringComparison.OrdinalIgnoreCase))
            {
                afc.AddTeam(data.Name, data.Abbreviation, data.Division);
            }
        }

        _nfl = new Nfl(nfc, afc);
    }

    public Nfl GetNflTeams()
    {
        return _nfl;
    }
}