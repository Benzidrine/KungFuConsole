using System;
using System.Collections.Generic;
using System.Text;

namespace KungFuConsole.Models
{
    public class BasePiece
    {
        //public enum PieceName { Pawn = 1, Bishop, Knight, Rook, Queen, King };

        public int ID { get; set; }
        public int Type { get; set; }
        public int Value { get; set; }
        public bool HasNotMoved { get; set; }
        public Position pos { get; set; }

        public string letterExpression()
        {
            string letter = "Z";
            switch (Type)
            {
                case 1:
                    letter = "P";
                    break;
                case 2:
                    letter = "B";
                    break;
                case 3:
                    letter = "H";
                    break;
                case 4:
                    letter = "R";
                    break;
                case 5:
                    letter = "Q";
                    break;
                case 6:
                    letter = "K";
                    break;
            }

            return letter;
        }

        public virtual bool CanMove(Board chessboard)
        {
            return false;
        }

        public virtual bool ValidMove()
        {
            return false;
        }

        public virtual bool ValidMoveInjection(Position newpos, List<BasePiece> ListOfPieces)
        {
            return false;
        }
    }
}
