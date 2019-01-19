using System;
using System.Collections.Generic;
using System.Text;

namespace KungFuConsole.Models
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsOccupied(BasePiece p)
        {
            if (p.pos.X == X && p.pos.Y == Y) return true;
            else return false;
        }

        public bool WithinBounds(int MaxX,int MaxY)
        {
            if (X > MaxX || X < 1 || Y > MaxY || Y < 1) return false;
            return true;
        }

        public int X { get; set; }
        public int Y { get; set; }
        BasePiece piece { get; set; }
    }
}
