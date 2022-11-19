using Microsoft.AspNetCore.SignalR;

namespace dotnet_signalr_charts.Hubs
{
    public class ChartHub : Hub
    {
        public const string Url = "/chart";
    }
}
