using System;
using System.Collections.Generic;
using System.Text;

namespace AsynchrounousProgrammingBasics.Entities
{
    public class PlayerStat
    {
        public int Id { get; }
        public double Score { get;}
        public int PlayerId { get; }

        public PlayerStat(int id, double score, int playerId)
        {
            Id = id;
            Score = score;
            PlayerId = playerId;
        }
    }
}
