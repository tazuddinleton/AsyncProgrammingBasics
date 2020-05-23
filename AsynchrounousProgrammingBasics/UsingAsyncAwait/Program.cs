using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.UsingAsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {

           //Run();
           await RunAsync();
        }


        static async Task RunAsync()
        {
            var controller = new PlayerController();
            var tasks = new List<Task<Player>>();
            for (int i = 1; i < 5; i++)
            {
                tasks.Add(controller.GetWinnerAsync(i));
            }
            try
            {
                await Task.WhenAny(tasks).ContinueWith(result =>
                {
                    Console.WriteLine($"The winner is : {result.Result.Result.Name}");
                    Console.WriteLine("Completed!");
                });
            }
            // TimeoutException never caught because of WhenAny
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Run()
        {
            var controller = new PlayerController();     
            for (int i = 1; i < 5; i++)
            {
                try
                {
                    var result = controller.GetWinner(i);
                    Console.WriteLine($"The winner is : {result.Name}");
                    Console.WriteLine("Completed!");
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
