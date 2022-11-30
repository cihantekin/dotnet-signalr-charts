using dotnet_signalr_charts.Hubs;
using dotnet_signalr_charts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton(_ =>
{
    var buffer = new Buffer<Point>(10);
    for (int i = 0; i < 7; i++)
    {
        buffer.AddNewRandomPoint();
    }

    return buffer;
});

builder.Services.AddSingleton(_ =>
{
    var buffer = new Buffer<Stack>(10);
    for (int i = 0; i < 7; i++)
    {
        buffer.AddRandomTeamSupporters();
    }
    return buffer;
});

builder.Services.AddSignalR();

builder.Services.AddHostedService<ChartValueGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapHub<ChartHub>(ChartHub.Url);
app.MapHub<StackedBarChartHub>(StackedBarChartHub.Url);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
