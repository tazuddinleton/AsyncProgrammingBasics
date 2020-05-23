using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics
{
    class Program
    {
        static async Task Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                Run();
            }

            for (int i = 0; i < 3; i++)
            {
                await RunAsync();
            }            
        }

        static async Task RunAsync()
        {
            var controller = new PlayerController();
            var tasks = new List<Task<Player>>();
            for (int i = 1; i < 5; i++)            {

                tasks.Add(controller.GetWinnerAsync(i));                
            }

            await Task.WhenAny(tasks).ContinueWith(result => {

                Console.WriteLine($"The winner is : {result.Result.Result.Name}");

                Console.WriteLine("Completed!");
            });
        }

        static void Run()
        {
            var controller = new PlayerController();
            var tasks = new List<Task<Player>>();
            for (int i = 1; i < 5; i++)
            {

                var result = controller.GetWinner(i);
                Console.WriteLine($"The winner is : {result.Name}");
                Console.WriteLine("Completed!");
            }
        }
    }
}
