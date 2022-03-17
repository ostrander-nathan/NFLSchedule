using NFLSchedule.Data;

namespace NFLSchedule;

class Program
{
    static void Main(string[] args)
    {
        var teams = new NflRepo().GetNflTeams();

    }
}