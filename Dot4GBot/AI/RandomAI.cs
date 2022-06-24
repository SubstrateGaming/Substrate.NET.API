using Ajuna.NetApi.Model.Base;
using Ajuna.NetApiExt.Model.AjunaWorker.Dot4G;
using Dot4GBot.AI;
using System;

namespace Dot4GBot
{
    public class RandomAI : IBotAI
    {
        private Random _random;

        public RandomAI()
        {
            _random = new Random();
        }

        public int[] Bombs(Dot4GObj gameBoard)
        {
            return gameBoard.EmptySlots[_random.Next(gameBoard.EmptySlots.Count)];
        }

        public (Side, int) Play(Dot4GObj gameBoard)
        {
            return gameBoard.PossibleMoves[_random.Next(gameBoard.PossibleMoves.Count)];
        }
    }
}