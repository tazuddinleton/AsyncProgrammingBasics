using AsynchrounousProgrammingBasics.Entities;
using AsynchrounousProgrammingBasics.Repositories;
using AsynchrounousProgrammingBasics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics.Controllers
{
    public class PlayerController
    {
        private readonly PlayerRepository _playerRepository;
        private readonly PlayerStatRepository _playerStatRepository;
        public PlayerController()
        {
            _playerRepository = new PlayerRepository();
            _playerStatRepository = new PlayerStatRepository();
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
            var result = _playerRepository.GetWinner(id);
            return result;
        }

        public Player GetPlayerById(int id)
        {
            Console.WriteLine($"Controller currently handling request with id: {id}");
            var result = _playerRepository.GetPlayerById(id);
            return result;
        }

        public async Task<PlayerStatViewModel> GetPlayerStatByPlayerId(int playerId)
        {
            var playerStat = new PlayerStatViewModel();

            var playerTask = Task.Run(() => _playerRepository.GetPlayerById(playerId));
            var statTask = Task.Run(() => _playerStatRepository.GetPlayerStatById(playerId));
            
            playerStat.Player = await playerTask;
            playerStat.PlayerStat = await statTask;
            return playerStat;                
        }


        // This is bad
        public async Task<PlayerStatViewModel> GetPlayerStatByPlayerIdUsingAsyncAwait(int playerId)
        {
            var playerStat = new PlayerStatViewModel()
            {
                Player = await _playerRepository.GetPlayerByIdAsync(playerId),
                PlayerStat = await _playerStatRepository.GetPlayerStatByIdAsync(playerId)
            };
            return playerStat;
        }
    }
}
