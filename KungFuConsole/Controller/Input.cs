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

            string input = cReadLine();

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
                case "ATTACK":
                    moveMade =
                        Attack(board);
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
                Console.WriteLine(PresentationController.PresentBoard(board));
                InputCycle(board);
            }
            
            if (board.CharacterEscaped)
            {
                board = BoardController.Setup();
            }

            if (moveMade)
            {
                Console.Clear();
                Console.WriteLine(PresentationController.PresentBoard(board));
                InputCycle(board);
            }

            return displayString;
        }

        private static bool Attack(Board board)
        {
            bool moveMade = false;
            Console.WriteLine("Direction to Attack:");
            string input = cReadLine();
            switch (input)
            {
                case "W":
                    moveMade =
                        CharacterController.Attack(board, input);
                    break;
                case "E":
                    moveMade =
                        CharacterController.Attack(board, input);
                    break;
                case "S":
                    moveMade =
                        CharacterController.Attack(board, input);
                    break;
                case "N":
                    moveMade =
                        CharacterController.Attack(board, input);
                    break;
                default:
                    moveMade = true;
                    break;
            }
            return true;
        }

        private static string cReadLine()
        {
            return Console.ReadLine().Trim().ToUpper();
        }
    }
}
