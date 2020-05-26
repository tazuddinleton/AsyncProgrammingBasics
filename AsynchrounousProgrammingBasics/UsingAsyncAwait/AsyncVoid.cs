using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.UsingAsyncAwait
{
    // Async void bad practice because it swallows exceptions
    // use Async Task instead
    // only exception is Event Handlers
    static class AsyncVoid
    {
        static async Task Main(string[] args)
        {
            try
            {
                await ThrowException2();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        // Bad practice
        static async void ThrowException()
        {
            await Task.Delay(200);
            throw new Exception();
        }

        static async Task ThrowException2()
        {
            await Task.Delay(200);
            throw new Exception();
        }
    }
}
