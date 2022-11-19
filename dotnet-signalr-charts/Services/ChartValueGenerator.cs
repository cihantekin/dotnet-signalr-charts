using dotnet_signalr_charts.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace dotnet_signalr_charts.Services
{
    public class ChartValueGenerator : BackgroundService
    {
        private readonly IHubContext<ChartHub> _hubContext;
        private readonly Buffer<Point> _data;

        public ChartValueGenerator(IHubContext<ChartHub> hubContext, Buffer<Point> data)
        {
            _hubContext = hubContext;
            _data = data;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.All.SendAsync("addChartData", _data.AddNewRandomPoint(), cancellationToken: stoppingToken);

                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }
    }
}
