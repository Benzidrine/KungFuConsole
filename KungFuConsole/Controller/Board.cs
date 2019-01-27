using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KungFuConsole.Models;

namespace KungFuConsole.Controller
{
    public class BoardController
    {
        public static Board PositionPieceOnBoard(Board board)
        {
            foreach (Position pos in board.Squares)
            {
               foreach (BasePiece bp in board.ListOfPieces)
               {
                    if (pos.X == bp.pos.X && pos.Y == bp.pos.Y)
                    {
                        pos.piece = bp;
                    }
               }
            }
            return board;
        }

        public static bool IsOccupied (Board board, Position pos)
        {
            foreach (BasePiece bp in board.ListOfPieces)
            {
                if (bp.pos.X == pos.X && bp.pos.Y == pos.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsExit(Board board, Position pos)
        {
            BasePiece bp = board.ListOfPieces.FirstOrDefault(b => b.Type == 5);
            if (bp.pos.X == pos.X && bp.pos.Y == pos.Y)
            {
                return true;
            }
            return false;
        }

        public static bool WithinBounds(Board board, Position pos)
        {
            if (pos.X < 0 || pos.X > board.Width) return false;
            if (pos.Y < 0 || pos.Y > board.Height) return false;
            return true;
        }

        public static bool Attack(Board board,  Position attackTo)
        {
            int IDtoRemove = -1;
            foreach (BasePiece bp in board.ListOfPieces)
            {
                if (bp.pos.X == attackTo.X && bp.pos.Y == attackTo.Y)
                {
                    IDtoRemove = bp.ID;
                }
            }

            if (IDtoRemove >= 0)
            {
                board.ListOfPieces.Remove(board.ListOfPieces.FirstOrDefault(bp => bp.ID == IDtoRemove));
            }
            return true;
        }

        public static bool MovePiece(Board board, Position pos, Position MoveTo)
        {
            foreach (BasePiece bp in board.ListOfPieces)
            {
                if (bp.pos.X == pos.X && bp.pos.Y == pos.Y)
                {
                    bp.pos = MoveTo;
                }
            }
            return false;
        }

        public static Board PlaceCharacter (Board board)
        {
            //Check if character exists
            if (board.ListOfPieces.Any(p => p.Type == 1)) return board;
            Models.Character c = new Models.Character();
            c.pos.X = 0;
            c.pos.Y = board.Height;
            board.ListOfPieces.Add(c);
            return board;
        }

        public static Board PlaceEnemies(Board board)
        {
            return board;
        }


        public static Board Setup()
        {
            Board board = new Board();
            board.Height = 8;
            board.Width = 12;
            board = BoardController.PlaceCharacter(board);
            board = BoardController.PlaceEnemies(board);
            board = BoardController.PlaceExit(board);
            return board;
        }

        public static Board PlaceExit(Board board)
        {
            //Check if exit exists
            if (board.ListOfPieces.Any(p => p.Type == 5)) return board;
            Models.Exit x = new Models.Exit();
            x.pos.X = board.Width;
            x.pos.Y = 0;
            board.ListOfPieces.Add(x);
            return board;
        }
    }
}
