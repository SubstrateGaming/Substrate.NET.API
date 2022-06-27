using Ajuna.NetApi.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ajuna.NetApiExt.Model.AjunaWorker.Dot4G
{
    public enum DiffType { Le, Gr, Eq }

    public class Dot4GStateHelper
    {
        public Dot4GObj _oldState, _newState;

        public Dot4GDiff NewState(Dot4GObj newState)
        {
            _oldState = _newState;
            _newState = newState;

            if (_oldState != null && _newState != null)
            {
                return Diff(_oldState, _newState);
            }

            return null;
        }

        public Dot4GDiff Diff(Dot4GObj oldState, Dot4GObj newState)
        {
            var gamePhaseFlag = oldState.GamePhase != newState.GamePhase;
            var playerChangedFlag = oldState.Next != newState.Next;

            var bombsDiffType = GetDiff(
                GetCells(oldState.Board, Cell.Bomb), 
                GetCells(newState.Board, Cell.Bomb), 
                out List<Dot4GCell> diffBombs);

            var stonesDiffType = GetDiff(
                GetCells(oldState.Board, Cell.Stone), 
                GetCells(newState.Board, Cell.Stone), 
                out List<Dot4GCell> diffStones);

            return new Dot4GDiff() { 
                ChangeFlag = gamePhaseFlag || bombsDiffType != DiffType.Eq || stonesDiffType != DiffType.Eq,
                GamePhase = newState.GamePhase,
                PlayerChangedFlag = playerChangedFlag,
                GamePhaseChange = gamePhaseFlag,
                bombsDiffType = bombsDiffType,
                bombsDiff = diffBombs,
                stonesDiffType = stonesDiffType,
                stonesDiff = diffStones,
            };
        }

        internal DiffType GetDiff(List<Dot4GCell> oldsCells, List<Dot4GCell> newCells, out List<Dot4GCell> diffCells)
        {
            diffCells = new List<Dot4GCell>();

            if (oldsCells.Count < newCells.Count)
            {
                diffCells = newCells.Except(oldsCells).ToList();

                return DiffType.Gr;
            }
            else if (oldsCells.Count > newCells.Count)
            {
                diffCells = oldsCells.Except(newCells).ToList();

                return DiffType.Le;
            }
            else
            {
                return DiffType.Eq;
            }
        }


        internal List<Dot4GCell> GetCells(Dot4GCell[,] board, Cell cell)
        {
            var result = new List<Dot4GCell>();
            foreach(var c in board)
            {
                if (c.Cell == cell)
                {
                    result.Add(c);
                }
            }
            return result;
        }
    }
}
