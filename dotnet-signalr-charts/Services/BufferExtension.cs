using System.Globalization;
using System.Security.Cryptography;

namespace dotnet_signalr_charts.Services
{
    public static class BufferExtension
    {
        public static Point AddNewRandomPoint(this Buffer<Point> buffer)
        {
            var now = DateTime.Now.AddMonths(buffer.TotalItemsAddedCount);
            var year = now.Year;
            var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(now.Month);
            var point = new Point($"{monthName} ({year})", RandomNumberGenerator.GetInt32(1, 11));
            buffer.Add(point);
            return point;
        }
    }
}
