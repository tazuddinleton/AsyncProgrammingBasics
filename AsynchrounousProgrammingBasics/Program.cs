using System;
using System.Collections.Generic;

namespace AsynchrounousProgrammingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();            
            Run();
        }

        static async void Run()
        {
            var controller = new NameController();
            for (int i = 0; i < 5; i++)            {
                
                var data = await controller.GetNames();
                data.ForEach(x => Console.WriteLine($"Call {i + 1}, data: {x}"));                                
            }
            Console.WriteLine("Completed!");
        }
    }
}
