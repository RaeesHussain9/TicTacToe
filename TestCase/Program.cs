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
        private static InputManager __InputManager;

        private static int turnCounter = 0;

        static void Main(string[] args)
        {
            __BoardManager = new BoardManager(3, 3);
            __InputManager = new InputManager(0, 2);

            while (turnCounter < 9)
            {
                __BoardManager.PrintBoard();

                PlayerTurn();

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

        private static void PlayerTurn()
        {
            PlayerPosition _Position = __InputManager.GetPlayerPositionFromUser(__CurrentPlayer);

            if (__BoardManager.AddPlayerPositionToBoard(__CurrentPlayer, _Position.Row, _Position.Column))
            {
                __CurrentPlayer = __CurrentPlayer == Player.Crosses ? Player.Noughts : Player.Crosses;
            }
            else
            {
                Console.WriteLine("Space already taken try again");
                PlayerTurn();
            }

        }
    }
}