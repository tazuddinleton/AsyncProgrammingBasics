using AsynchrounousProgrammingBasics.Controllers;
using AsynchrounousProgrammingBasics.Entities;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.UsingTPL
{
    static class Program
    {
        static async Task Main(string[] args)
        {            
            await Run();
        }

        static async Task Run()
        {   
            var controller = new PlayerController();
            var watch = Stopwatch.StartNew();
            await controller.GetPlayerStatByPlayerId(2);
            watch.Stop();
            Console.WriteLine($"Running time: {watch.ElapsedMilliseconds}");

            watch = Stopwatch.StartNew();
            await controller.GetPlayerStatByPlayerIdUsingAsyncAwait(2);
            watch.Stop();
            Console.WriteLine($"Running time: {watch.ElapsedMilliseconds}");

            Console.WriteLine("Completed!");
        }
    }
}
