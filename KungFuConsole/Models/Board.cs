using System;
using System.Collections.Generic;
using System.Text;

namespace KungFuConsole.Models
{
    public class Board
    {

        public Board() { }

        public List<Position> Squares { get; set; }
        public List<BasePiece> ListOfPieces { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
