using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics
{
    public class NameRepository
    {

        public async Task<List<string>> GetNames()
        {
            // Assuming data base call
            Thread.Sleep(new Random().Next(500, 1000));
            return new List<string>() { "Toma", "Tawhid", "Shetu" };
        }

        public async Task<List<string>> GetAddresses()
        {
            // Assuming data base call
            Thread.Sleep(new Random().Next(0, 1000));
            return new List<string>() { "Gazipur", "Gazipur", "Dhaka" };
        }
    }
}
