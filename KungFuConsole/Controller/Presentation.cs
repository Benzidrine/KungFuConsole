using System;
using System.Collections.Generic;
using System.Text;
using KungFuConsole.Models;

namespace KungFuConsole.Controller
{
    public class PresentationController
    {
        public static string PresentBoard(Board board)
        {
            string DisplayString = "";
            //Check for instantition
            if (board.Squares != null) return DisplayString;

            //Padding
            DisplayString += "\n";
            DisplayString += "\n";

            for (int y = 0; y <= board.Height; y++)
            {
                //Padding
                DisplayString += "    ";
                for (int x = 0; x <= board.Width; x++)
                {
                    bool hasWritten = false;
                    foreach (BasePiece bp in board.ListOfPieces)
                    {
                        if (bp.pos.X == x && bp.pos.Y == y)
                        {
                            DisplayString += bp.letterExpression();
                            hasWritten = true;
                        }
                    }
                    if (!hasWritten) DisplayString += ".";
                }
                DisplayString += "\n";
            }

            return DisplayString;
        }
    }
}
