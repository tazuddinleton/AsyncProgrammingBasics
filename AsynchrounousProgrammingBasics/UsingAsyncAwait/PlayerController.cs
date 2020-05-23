using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.UsingAsyncAwait
{
    public class PlayerController
    {
        private readonly PlayerRepository _playerRepository;
        public PlayerController()
        {
            _playerRepository = new PlayerRepository();
        }
        public async Task<Player> GetWinnerAsync(int id)
        {
            Console.WriteLine($"Controller currently handling request: {id}");
            var result = await _playerRepository.GetWinnerAsync(id);
            return result;
        }

        public Player GetWinner(int id)
        {
            Console.WriteLine($"Controller currently handling request: {id}");
            var result =  _playerRepository.GetWinner(id);
            return result;
        }
    }
}
