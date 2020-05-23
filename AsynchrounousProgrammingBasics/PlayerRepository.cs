using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics
{
    public class Player
    {
        public int Id { get;}
        public string Name { get;}
        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
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

            Thread.Sleep(wait);

            var res = _names.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"found {res.Name}");
            return res;
        }
    }
}
