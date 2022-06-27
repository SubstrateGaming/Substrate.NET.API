using Ajuna.NetApi.Model.Base;
using System.Collections.Generic;

namespace Ajuna.NetApiExt.Model.AjunaWorker.Dot4G
{
    public class Dot4GDiff
    {
        public GamePhase GamePhase { get; set; }
        public bool GamePhaseChange { get; set; }
        public DiffType bombsDiffType { get; set; }
        public List<Dot4GCell> bombsDiff { get; set; }
        public DiffType stonesDiffType { get; set; }
        public List<Dot4GCell> stonesDiff { get; set; }
        public bool ChangeFlag { get; internal set; }
        public bool PlayerChangedFlag { get; internal set; }
    }
}