using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousApi.Controllers
{
    public class FooController : ControllerBase
    {
        private readonly HttpClient _client;
        public FooController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> GetFoo(CancellationToken cancellationToken)
        {
            try
            {
                await _client.GetAsync("http://httpstat.us/204?sleep=5000", cancellationToken);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("Cancelled!");
                return NoContent();
            }
            return Ok("Completed!");
        }

        public async Task<IActionResult> GetBar(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                await Task.Delay(2000, cancellationToken);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("Cancelled!");
                return NoContent();
            }
            return Ok("Completed!");
        }
    }
}
