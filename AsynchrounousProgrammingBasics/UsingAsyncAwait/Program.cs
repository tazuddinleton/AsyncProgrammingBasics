using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.UsingAsyncAwait
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Run();
                //await RunAsync();
                await RunLoopAsync();
            }            
            catch (TimeoutException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task RunLoopAsync()
        {
            var controller = new PlayerController();
            var tasks = new List<Task<Player>>();
            for (int i = 1; i < 5; i++)
            {
                tasks.Add(controller.GetWinnerAsync(i));
            }
            await Task.WhenAny(tasks).ContinueWith( result =>
            {                
                Console.WriteLine($"The winner is : {result.Result.Result.Name}");
                Console.WriteLine("Completed!");                
            });
            ////// Continuation
            //// same as 
            //var result = await Task.WhenAny(tasks);
            //Console.WriteLine($"The winner is : {result.Result.Name}");
            //Console.WriteLine("Completed!");
        }

        static async Task RunAsync()
        {
            var controller = new PlayerController();
            var result = await controller.GetWinnerAsync(2);
            Console.WriteLine($"The winner is : {result.Name}");
            Console.WriteLine("Completed!");
        }

        static void Run()
        {
            var controller = new PlayerController();     
            for (int i = 1; i < 5; i++)
            {
                var result = controller.GetWinner(i);
                Console.WriteLine($"The winner is : {result.Name}");
                Console.WriteLine("Completed!");
            }
        }

       
    }
}
