using Ajuna.NetApi.Model.Base;
using Ajuna.NetApiExt.Model.AjunaWorker.Dot4G;
using System;

namespace Dot4GBot.AI
{
    public interface IBotAI
    {
        public int[] Bombs(Dot4GObj gameBoard);

        public (Side, int) Play(Dot4GObj gameBoard);
    }
}