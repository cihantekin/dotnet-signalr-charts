using dotnet_signalr_charts.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace dotnet_signalr_charts.Services
{
    public class StackedBarChartValueGenerator : BackgroundService
    {
        private readonly IHubContext<StackedBarChartHub> _hubContext;
        private readonly Buffer<Stack> _stacks;

        public StackedBarChartValueGenerator(IHubContext<StackedBarChartHub> hubContext, Buffer<Stack> stacks)
        {
            _hubContext = hubContext;
            _stacks = stacks;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.All.SendAsync("addStackedBarChartData", _stacks.AddRandomTeamSupporters(), stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
            }
        }
    }
}
