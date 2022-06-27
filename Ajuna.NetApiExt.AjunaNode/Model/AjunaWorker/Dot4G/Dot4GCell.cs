using Ajuna.NetApi.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ajuna.NetApiExt.Model.AjunaWorker.Dot4G
{
    public class Dot4GCell : IEquatable<Dot4GCell>
    {
        public int[] Position { get; }

        public Cell Cell { get; }

        public List<int> PlayerIds { get; }


        public Dot4GCell(int[] position, Cell value)
        {
            Position = position;
            Cell = value;
            PlayerIds = null;
        }

        public Dot4GCell(int[] position, Cell cell, byte[] players) : this(position, cell)
        {
            PlayerIds = new List<int>();
            PlayerIds.AddRange(players.Select(p => (int)p).ToList());
        }

        public Dot4GCell(int[] position, Cell cell, byte player) : this(position, cell)
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

        public bool Equals(Dot4GCell other)
        {
            if (this.Position[0] != other.Position[0]
             || this.Position[1] != other.Position[1])
            {
                return false;
            }

            if (this.Cell != other.Cell)
            {
                return false;
            }
            
            if ((this.PlayerIds == null && other.PlayerIds != null)
             || (this.PlayerIds != null && other.PlayerIds == null))
            {
                return false;
            }


            return (this.PlayerIds == null && other.PlayerIds == null) 
                || Enumerable.SequenceEqual(this.PlayerIds, other.PlayerIds);
        }
    }
}