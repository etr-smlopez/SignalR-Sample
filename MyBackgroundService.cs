using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Your background service logic goes here
            Console.WriteLine("Background service is running");

            await Task.Delay(1000, stoppingToken); // Delay for 1 second
        }
    }

}