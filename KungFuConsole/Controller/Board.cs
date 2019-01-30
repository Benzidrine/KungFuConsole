using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KungFuConsole.Models;

namespace KungFuConsole.Controller
{
    public class BoardController
    {
        private int IDofPiece = 0;
        private int LoopCount = 0;

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

        public static Position FindCharacterPosition(Board board)
        {
            Position pos = new Position(0, 0);
            return pos;
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
                    break;
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

        public Board PlaceCharacter (Board board)
        {
            //Check if character exists
            if (board.ListOfPieces.Any(p => p.Type == 1)) return board;
            Models.Character c = new Models.Character();
            c.ID = IDofPiece++;
            c.pos.X = 0;
            c.pos.Y = board.Height;
            board.ListOfPieces.Add(c);
            return board;
        }

        public  Board PlaceEnemies(Board board)
        {
            Models.Puncher p = new Models.Puncher();
            p.ID = IDofPiece++;
            PlaceRandom(board, p);
            return board;
        }


        public Board PlaceRandom(Board board, BasePiece bp)
        {
            //Endless Loop Protection
            if (LoopCount > 10)
            { return board; }
            LoopCount++;
            Random rnd = new Random();
            int x = rnd.Next(0, board.Width + 1);
            int y = rnd.Next(0, board.Height + 1);
            Position pos = new Position(x, y);
            if (BoardController.IsOccupied(board, pos))
            {
                return PlaceRandom(board, bp);
            }
            else
            {
                bp.pos.X = x;
                bp.pos.Y = y;
                board.ListOfPieces.Add(bp);
                LoopCount = 0;
                return board;
            }
        }



        public static Board Setup()
        {
            BoardController BC = new BoardController();
            Board board = new Board();
            board.Height = 8;
            board.Width = 12;
            board = BC.PlaceCharacter(board);
            board = BC.PlaceEnemies(board);
            board = BC.PlaceExit(board);
            return board;
        }

        public Board PlaceExit(Board board)
        {
            //Check if exit exists
            if (board.ListOfPieces.Any(p => p.Type == 5)) return board;
            Models.Exit x = new Models.Exit();
            x.ID = IDofPiece++;
            x.pos.X = board.Width;
            x.pos.Y = 0;
            board.ListOfPieces.Add(x);
            return board;
        }
    }
}
