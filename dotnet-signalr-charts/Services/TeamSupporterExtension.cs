using System.Globalization;
using System.Security.Cryptography;

namespace dotnet_signalr_charts.Services
{
    public static class TeamSupporterExtension
    {
        public static Stack AddRandomTeamSupporters(this Buffer<Stack> buffer)
        {
            var now = DateTime.Now.AddMonths(buffer.TotalItemsAddedCount);
            var year = now.Year;
            var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(now.Month);
            var stack = new Stack($"{monthName} ({year})", new List<TeamSupporters>
            {
                new TeamSupporters {Color = "Blue", TeamName = "Fenerbahce", Count = RandomNumberGenerator.GetInt32(10_000_000, 20_000_000) },
                new TeamSupporters {Color = "Red", TeamName = "Galatasaray", Count = RandomNumberGenerator.GetInt32(10_000_000, 20_000_000) },
                new TeamSupporters {Color = "Black", TeamName = "Besiktas", Count = RandomNumberGenerator.GetInt32(10_000_000, 20_000_000) }
            });

            buffer.Add(stack);
            return stack;
        }
    }
}
