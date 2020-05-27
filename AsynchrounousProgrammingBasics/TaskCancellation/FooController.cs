using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AsynchrounousProgrammingBasics.TaskCancellation
{
    public class FooController
    {
        private readonly HttpClient _client;
        public FooController()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetFoo(CancellationToken cancellationToken)
        {
            try
            {                
                await _client.GetAsync("http://httpstat.us/204?sleep=5000", cancellationToken);
                return "Completed!";
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Task Cancelled!");
                return String.Empty;
            }            
        }

        public async Task<string> ConfigureAwait(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _client.GetAsync("https://www.bynder.com", cancellationToken);
                return await response.Content.ReadAsStringAsync();
                
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Task Cancelled!");
                return String.Empty;
            }
        }
    }
}
