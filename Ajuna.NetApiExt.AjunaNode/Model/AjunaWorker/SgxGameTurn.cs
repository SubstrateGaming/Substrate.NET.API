using Ajuna.NetApi.Model.Base;
using Ajuna.NetApi.Model.PalletBoard;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;

namespace Ajuna.NetApi.Model.AjunaWorker
{
    // Guessing Game
    //public class SgxGuessingTurn : U32 { }
    public class SgxGameTurn : EnumTurn
    {
        public static SgxGameTurn DropStone(Side side, byte column)
        {
            var enumSide = new EnumSide();
            enumSide.Create(side);

            var col = new U8();
            col.Create(column);

            var tuple = new BaseTuple<EnumSide, U8>();
            tuple.Create(enumSide, col);

            var turnType = new SgxGameTurn();
            turnType.Create(Turn.DropStone, tuple);

            return turnType;
        }

        public static SgxGameTurn DropBomb(int[] coord)
        {
            var rowU8 = new U8();
            rowU8.Create((byte) coord[0]);

            var colU8 = new U8();
            colU8.Create((byte) coord[1]);

            var coords = new Coordinates
            {
                Row = rowU8,
                Col = colU8
            };

            var turnType = new SgxGameTurn();
            turnType.Create(Turn.DropBomb, coords);

            return turnType;
        }
    }
}

