const data = JSON.parse(document.getElementById('data').innerHTML);
const ctx = document.getElementById('myChart').getContext('2d');

const myChart = new Chart(ctx, {
    type: 'bar',
    data: data,
    options: {
        plugins: {
            title: {
                display: true,
                text: 'Chart.js Bar Chart - Stacked'
            },
        },
        responsive: true,
        scales: {
            x: {
                stacked: true,
            },
            y: {
                stacked: true
            }
        }
    }
});

const connection = new signalR.HubConnectionBuilder().withUrl("/stackedBarChart").configureLogging(signalR.LogLevel.Information).build();

async function start() {
    try {
        await connection.start();
        console.log('SignalR Connection successful');
    } catch (e) {
        console.log(e);
        setTimeout(start, 5000)
    }
}

connection.onclose(async () => {
    await start();
});

start().then(() => { });