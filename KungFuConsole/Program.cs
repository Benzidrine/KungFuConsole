using System;
using KungFuConsole.Models;
using KungFuConsole.Controller;

namespace KungFuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = BoardController.Setup();
            Console.WriteLine(PresentationController.PresentBoard(board));
            InputController.InputCycle(board);
            Console.ReadLine();
        }
    }
}
