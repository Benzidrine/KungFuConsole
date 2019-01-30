using System;
using System.Collections.Generic;
using System.Text;

namespace KungFuConsole.Models
{
    public class BasePiece
    {
        //public enum PieceName { Pawn = 1, Bishop, Knight, Rook, Queen, King };
        public BasePiece() { pos = new Position(0,0); Construct(); }

        public int ID { get; set; }
        public int Type { get; set; }
        public enum PieceName { PlayerCharacter = 1, Puncher, Kicker, FlyKicker, Exit };
        public int Value { get; set; }
        public bool HasNotMoved { get; set; }
        public Position pos { get; set; }

        public string letterExpression()
        {
            string letter = "Z";
            switch (Type)
            {
                case 1:
                    letter = "@";
                    break;
                case 2:
                    letter = "P";
                    break;
                case 3:
                    letter = "K";
                    break;
                case 4:
                    letter = "F";
                    break;
            }

            return letter;
        }

        public virtual bool CanMove(Board chessboard)
        {
            return false;
        }

        public virtual void Construct()
        {
        }
        
        public virtual bool ForwardMove(Board board)
        {

            return false;
        }

        public virtual bool ReverseMove(Board board)
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
