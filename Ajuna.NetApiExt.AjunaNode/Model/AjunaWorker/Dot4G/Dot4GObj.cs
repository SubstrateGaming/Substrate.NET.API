using Ajuna.NetApi;
using Ajuna.NetApi.Model.Base;
using Ajuna.NetApi.Model.PalletBoard;
using Ajuna.NetApi.Model.SpCore;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApiExt.Model.AjunaWorker.Dot4G;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ajuna.NetApiExt.Model.AjunaWorker.Dot4G
{

    public class Dot4GObj
    {
        public int Id { get; }

        public int Seed { get; }

        public Dot4GCell[,] Board { get; set; }

        public List<Dot4GPlayer> Players { get; set; } = new List<Dot4GPlayer>();

        public GamePhase GamePhase { get; }

        public int Next { get; }

        public int? Winner { get; }

        public List<(Side, int)> PossibleMoves { get; }

        public List<int[]> EmptySlots { get; }

        public Dot4GObj(BoardGame boardGame)
        {
            foreach (var player in boardGame.State.Players.Value.Select(p => Utils.GetAddressFrom(p.Value.Value.Select(q => q.Value).ToArray())))
            {
                Players.Add(new Dot4GPlayer(GetPlayername(player), player));
            }
            GamePhase = boardGame.State.Phase.Value;
            Id = (int) boardGame.BoardId.Value;
            Seed = (int)boardGame.State.Seed.Value;
            Winner = boardGame.State.Winner.OptionFlag ? boardGame.State.Winner.Value.Value : (int?)null;

            foreach (var bomb in boardGame.State.Bombs.Value.ToList())
            {
                var player = Players.Where(p => p.Address == Utils.GetAddressFrom(((AccountId32)bomb.Value[0]).Value.Value.Select(q => q.Value).ToArray())).FirstOrDefault();
                if (player != null)
                {
                    player.Bombs = ((U8)bomb.Value[1]).Value;
                }
            }

            Next = boardGame.State.NextPlayer.Value;

            EnumCell[][] array = boardGame.State.Board.Cells.Value.Select(p => p.Value).ToArray();

            Board = new Dot4GCell[array.Length, array[0].Length];

            for (int i = 0; i < array.Length; i++)
            {
                EnumCell[] enumCellArray = array[i];
                for (int j = 0; j < enumCellArray.Length; j++)
                {
                    EnumCell enumCell = enumCellArray[j];
                    switch (enumCell.Value)
                    {
                        case Cell.Empty:
                            Board[i, j] = new Dot4GCell(enumCell.Value);
                            break;

                        case Cell.Bomb:
                            var playerBombs = ((Arr2Special1)enumCell.Value2).Value.Where(p => p.OptionFlag).Select(p => p.Value.Value).ToArray();
                            Board[i, j] = new Dot4GCell(enumCell.Value, playerBombs);
                            break;

                        case Cell.Block:
                            Board[i, j] = new Dot4GCell(enumCell.Value);
                            break;

                        case Cell.Stone:
                            var playerId = ((U8)enumCell.Value2).Value;
                            Board[i, j] = new Dot4GCell(enumCell.Value, playerId);
                            break;
                    }
                }
            }

            PossibleMoves = DropStoneList();
            EmptySlots = GetCoords(Cell.Empty);
        }

        private List<(Side, int)> DropStoneList()
        {
            var list = GetCoords(Cell.Empty);
            var moves = new List<(Side, int)>();

            list.Where(p => p[0] == 0).Select(p => p[1]).ToList()
                .ForEach(p => moves.Add((Side.North, p)));
            list.Where(p => p[1] == 9).Select(p => p[0]).ToList()
                .ForEach(p => moves.Add((Side.East, p)));
            list.Where(p => p[0] == 9).Select(p => p[1]).ToList()
                .ForEach(p => moves.Add((Side.South, p)));
            list.Where(p => p[1] == 0).Select(p => p[0]).ToList()
                .ForEach(p => moves.Add((Side.West, p)));

            return moves;
        }

        private string GetPlayername(string address)
        {
            switch (address)
            {
                case "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY":
                    return "Alice";
                case "5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty":
                    return "Bob";
                default:
                    return address.Substring(0, 10);
            }
        }

        public List<int[]> GetCoords(Cell cell)
        {
            var result = new List<int[]>();
            for (int i = 0; i < Board.GetLength(0); i++)
            {

                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j].Cell == cell) {
                        result.Add(new int[] { i, j});
                    }

                }
            }
            return result;
        }

        public void Print()
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| " + $"Board[{Id}|{Seed}] Phase: {GamePhase}".PadRight(38) + "|");
            Console.WriteLine("| " + $"Empty[{EmptySlots.Count}] - Moves[{PossibleMoves.Count}]".PadRight(38) + "|");
            Players.ForEach(p => Console.WriteLine("| " + p.ToString().PadRight(38) + "|"));
            Console.WriteLine("| " + $"Next: {Players[Next].Name}".PadRight(38) + "|");
            Console.WriteLine("| " + $"Winner: {Winner}".PadRight(38) + "|");
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");
                Console.Write($"|");
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(Board[i, j].ToString());
                    Console.Write($"|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");
        }
    }
}
