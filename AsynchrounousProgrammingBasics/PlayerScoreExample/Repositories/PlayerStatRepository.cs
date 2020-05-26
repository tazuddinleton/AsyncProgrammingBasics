using AsynchrounousProgrammingBasics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.Repositories
{
    public class PlayerStatRepository
    {

        private readonly List<PlayerStat> _stats = new List<PlayerStat>();
        public PlayerStatRepository()
        {
            _stats.Add(new PlayerStat(1, 200, 1));
            _stats.Add(new PlayerStat(2, 300, 2));
            _stats.Add(new PlayerStat(3, 300, 3));
            _stats.Add(new PlayerStat(4, 300, 4));
            _stats.Add(new PlayerStat(5, 300, 5));
            _stats.Add(new PlayerStat(6, 300, 6));
            _stats.Add(new PlayerStat(7, 300, 7));

        }

        public PlayerStat GetPlayerStatById(int playerId)
        {
            Console.WriteLine($"Getting stat for player {playerId}");
            Thread.Sleep(2000);
            return _stats.FirstOrDefault(s => s.PlayerId == playerId);
        }

        public async Task<PlayerStat> GetPlayerStatByIdAsync(int playerId)
        {
            Console.WriteLine($"Getting stat for player {playerId}");
            await Task.Delay(2000);
            return _stats.FirstOrDefault(s => s.PlayerId == playerId);
        }
    }
}
