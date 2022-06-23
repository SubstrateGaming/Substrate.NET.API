using Ajuna.NetApi.Model.Base;
using System;

namespace Ajuna.UnityInterface
{
    public class Dot4GClient
    {


        public bool Queue(int gameId, int playerId1, int playerId2)
        {
            return false;
        }

        public bool PlayerBomb(int gameId, int playerId, int posX, int posY)
        {
            return false;
        }

        public bool PlayerMove(int gameId, int playerId, Side side, int column)
        {
            return false;
        }

        public bool Tick(int gameId)
        {
            return false;
        }

        public bool ValidateBomb(int gameId, int playerId, int posX, int posY)
        {
            return false;
        }

        public bool ValidateMove(int gameId, int playerId, Side side, int column)
        {
            return false;
        }

        public void FullState(int gameId)
        {

        }

        public int GetPlayerId(int player)
        {
            return 0;
        }

        public int GetPlayer(int playerId)
        {
            return 0;
        }
    }
}
