using System;
using System.Collections.Generic;
using System.Text;
using KungFuConsole.Models;

namespace KungFuConsole.Helper
{
    class ExplicitCast
    {
        public static dynamic castAsCorrectPiece(BasePiece bp)
        {
            if (bp.Type == 1) return (Character)bp;
            return bp;
        }
    }
}
