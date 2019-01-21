using System;
using KungFuConsole.Models;
using KungFuConsole.Controller;

namespace KungFuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Height = 8;
            board.Width = 12;
            board = BoardController.PlaceCharacter(board);
            Console.WriteLine(PresentationController.PresentBoard(board));
            InputController.InputCycle(board);
            Console.ReadLine();
        }
    }
}
