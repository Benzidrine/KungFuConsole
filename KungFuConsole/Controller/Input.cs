using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KungFuConsole.Models;

namespace KungFuConsole.Controller
{
    public class InputController
    {
        public InputController() { }

        public static string InputCycle(Board board)
        {

            string displayString = "";
            bool moveMade = false;

            string input = cReadLine().ToUpper();

            switch (input)
            {
                case "W":
                    moveMade = 
                        CharacterController.Move(board, input);
                    break;
                case "E":
                    moveMade =
                        CharacterController.Move(board, input);
                    break;
                case "S":
                    moveMade =
                        CharacterController.Move(board, input);
                    break;
                case "N":
                    moveMade =
                        CharacterController.Move(board, input);
                    break;
                case "EXIT":
                    moveMade = false;
                    break;
                default:
                    moveMade = true;
                    break;
            }

            if (!moveMade)
            {
                Console.WriteLine("Invalid move");
                moveMade = !moveMade;
            }

            if (moveMade)
            {
                Console.Clear();
                Console.WriteLine(PresentationController.PresentBoard(board));
                InputCycle(board);
            }

            return displayString;
        }

        private static string cReadLine()
        {
            return Console.ReadLine().Trim().ToUpper();
        }
    }
}
