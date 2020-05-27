using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.TaskCancellation
{
    static class App
    {
        static async Task Main(string[] args)
        {
            
            //await CancelFoo();
            await ConfigureAwait();

        }

        static async Task CompleteFoo()
        {
            var controller = new FooController();
            var cts = new CancellationTokenSource();
            var foo = await controller.GetFoo(cts.Token);
            Console.WriteLine(foo);
        }

        static async Task ConfigureAwait()
        {                        
            var controller = new FooController();
            var cts = new CancellationTokenSource();
            var foo = await Task.Run(() =>
            {
                return controller.ConfigureAwait(cts.Token);
            }).ConfigureAwait(false);

            Console.WriteLine(foo);
        }

        static async Task CancelFoo()
        {
            var controller = new FooController();
            var cts = new CancellationTokenSource();
            var task = controller.GetFoo(cts.Token);
            if(!task.Wait(2000))                
                cts.Cancel();
            var foo = await task;            
            Console.WriteLine(foo);
        }

    }
}
