using AsynchrounousProgrammingBasics.Entities;
using AsynchrounousProgrammingBasics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.Repositories
{
    public class PlayerRepository
    {
        private List<Player> _names = new List<Player>();

        public PlayerRepository()
        {
            _names.Add(new Player(1, "Steve"));
            _names.Add(new Player(2, "Smith"));
            _names.Add(new Player(3, "Kevin"));
            _names.Add(new Player(4, "Bob"));
            _names.Add(new Player(5, "Martin"));
            _names.Add(new Player(6, "Julie"));
        }


        public async Task<Player> GetWinnerAsync(int id)
        {
            // Assuming data base call
            var wait = new Random().Next(0, 1000);
            Console.WriteLine($"waiting : {wait}, id: {id}");

            if (wait >= 500)
            {
                throw new TimeoutException($"Timeout occured. Wait time: {wait}ms");
            }
            await Task.Delay(wait);

            var res = _names.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"found {res.Name}");
            return res;
        }

        public Player GetWinner(int id)
        {
            // Assuming data base call
            var wait = new Random().Next(0, 1000);
            Console.WriteLine($"waiting : {wait}, id: {id}");

            if (wait >= 500)
            {
                throw new TimeoutException($"Timeout occured. Wait time: {wait}ms");
            }

            Thread.Sleep(wait);
            var res = _names.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"found {res.Name}");
            return res;
        }

        public Player GetPlayerById(int id)
        {
            // Assuming data base call
            Console.WriteLine($"Getting player of id: {id}");
            Thread.Sleep(2000);
            var player = _names.FirstOrDefault(x => x.Id == id);
            return player;
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            // Assuming data base call
            Console.WriteLine($"Getting player of id: {id}");
            await Task.Delay(2000);
            var player = _names.FirstOrDefault(x => x.Id == id);
            return player;
        }

    }
}
