using System;
using System.Collections.Generic;
using System.Text;
using KungFuConsole.Models;
using KungFuConsole.Helper;
using System.Linq;

namespace KungFuConsole.Controller
{
    public class CharacterController
    {

        public static bool Attack(Board board, String Direction)
        {
            var c = ExplicitCast.castAsCorrectPiece(board.ListOfPieces.FirstOrDefault(bp => bp.Type == 1));
            Position attackTo = GetPositionFromDirection(board, Direction);

            if (BoardController.IsExit(board, attackTo))
            {
                return false;
            }

            if (!BoardController.WithinBounds(board, attackTo)) return false;

            BoardController.Attack(board, attackTo);

            return true;
        }

        public static bool Move(Board board, String Direction)
        {
            var c = ExplicitCast.castAsCorrectPiece(board.ListOfPieces.FirstOrDefault(bp => bp.Type == 1));
            Position moveTo = GetPositionFromDirection(board, Direction);

            if (BoardController.IsExit(board, moveTo))
            {
                board.CharacterEscaped = true;
                return true;
            }

            if (BoardController.IsOccupied(board, moveTo)) return false;

            if (!BoardController.WithinBounds(board, moveTo)) return false;

            BoardController.MovePiece(board, c.pos, moveTo);

            return true;
        }

        private static Position GetPositionFromDirection(Board board, String Direction)
        {
            var c = ExplicitCast.castAsCorrectPiece(board.ListOfPieces.FirstOrDefault(bp => bp.Type == 1));
            //Create position based on direction
            Position moveTo = new Position(0, 0);
            switch (Direction.ToUpper())
            {
                case "W":
                    moveTo = new Position((c.pos.X - 1), c.pos.Y);
                    break;
                case "E":
                    moveTo = new Position((c.pos.X + 1), c.pos.Y);
                    break;
                case "S":
                    moveTo = new Position((c.pos.X), (c.pos.Y + 1));
                    break;
                case "N":
                    moveTo = new Position((c.pos.X), (c.pos.Y - 1));
                    break;
            }
            return moveTo;
        }
    }
}
