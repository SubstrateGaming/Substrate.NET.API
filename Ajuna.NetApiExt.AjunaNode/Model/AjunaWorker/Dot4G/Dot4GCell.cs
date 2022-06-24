using Ajuna.NetApi.Model.Base;
using System.Collections.Generic;
using System.Linq;

namespace Ajuna.NetApiExt.Model.AjunaWorker.Dot4G
{
    public class Dot4GCell
    {
        public Cell Cell { get; }

        public List<int> PlayerIds { get; }


        public Dot4GCell(Cell value)
        {
            Cell = value;
            PlayerIds = null;
        }

        public Dot4GCell(Cell cell, byte[] players) : this(cell)
        {
            PlayerIds = new List<int>();
            PlayerIds.AddRange(players.Select(p => (int)p).ToList());
        }

        public Dot4GCell(Cell cell, byte player) : this(cell)
        {
            PlayerIds = new List<int>() {
                player
            };
        }

        override
        public string ToString()
        {

            switch (Cell)
            {
                case Cell.Empty:
                    return "   ";

                case Cell.Bomb:
                    if (PlayerIds.Count > 1)
                    {
                        return PlayerIds[0] + "B" + PlayerIds[1];
                    }
                    else if (PlayerIds.Count > 0)
                    {
                        return " B" + PlayerIds[0];
                    }
                    return "   ";

                case Cell.Block:
                    return " # ";

                case Cell.Stone:
                    return " S" + PlayerIds[0];

                default:
                    return "   ";
            }

        }
    }
}