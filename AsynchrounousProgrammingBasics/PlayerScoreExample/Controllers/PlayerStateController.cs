using AsynchrounousProgrammingBasics.Entities;
using AsynchrounousProgrammingBasics.Repositories;
using AsynchrounousProgrammingBasics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchrounousProgrammingBasics.Controllers
{
    public class PlayerStateController
    {
        private readonly PlayerStatRepository _playerStatRepository;
        public PlayerStateController()
        {
            _playerStatRepository = new PlayerStatRepository();
        }

    }
}
