//====================================To do list=====================================================
// 1st - between each turn say whos turn it currently is
// 2nd - input handling (optionally return it to redo the specific x or y input that needs redoing)
// 3rd - loop it so that the players can play again if they want to
// 4th - split out the code into different classes
// 5th - (optional) redo check win method to see if it can be shorter
// 6th - post code to github get code reviewed by Avtar.

using TestCase;
using TestCase.Managers;

namespace Tut1
{
    public class Program
    {
        private static Player __CurrentPlayer = Player.Crosses;

        private static BoardManager __BoardManager;

        private static int turnCounter = 0;

        static void Main(string[] args)
        {
            __BoardManager = new BoardManager(3, 3);

            while (turnCounter < 9)
            {
                __BoardManager.PrintBoard();

                InputFromUser();

                turnCounter++;

                if (turnCounter >= 5 && __BoardManager.CheckWin())
                {
                    __BoardManager.PrintBoard();
                    break;
                }
                else if (turnCounter >= 9)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!DRAW!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
                }

            }
        }

        private static int GetInput(BoardPosition position)
        {
            Console.WriteLine($"Choose {position} position - Enter a number between 0 and 2: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num >= 0 && num <= 2)
                {
                    return num;
                }
            }

            return GetInput(position);
        }

        private static void InputFromUser()
        {
            Console.WriteLine($"Player '{(PlayerHelper.GetPlayerToken(__CurrentPlayer))}' turn");

            int row = GetInput(BoardPosition.Row);

            int column = GetInput(BoardPosition.Column);

            PlayerTurn(row, column);
        }

        private static void PlayerTurn(int xPlane, int yPlane)
        {
            
            if (__BoardManager.AddPlayerPositionToBoard(__CurrentPlayer, xPlane, yPlane))
            {
                __CurrentPlayer = __CurrentPlayer == Player.Crosses ? Player.Noughts : Player.Crosses;
            }
            else
            {
                Console.WriteLine("Space already taken try again");
                InputFromUser();
            }

        }
    }
}