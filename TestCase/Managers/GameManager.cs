﻿namespace TestCase.Managers
{
    public class GameManager
    {
        private Player __CurrentPlayer;
        private int __TurnCounter;

        private readonly BoardManager __BoardManager;
        private readonly InputManager __InputManager;

        public GameManager()
        {
            __BoardManager = new BoardManager(3, 3);
            __InputManager = new InputManager(0, 2);

            __CurrentPlayer = Player.Crosses;
            __TurnCounter = 0;
        }

        public void PlayGame()
        {
            while (__TurnCounter < 9)
            {
                __BoardManager.PrintBoard();

                PlayerTurn();

                __TurnCounter++;

                if (__TurnCounter >= 5 && __BoardManager.CheckWin())
                {
                    __BoardManager.PrintBoard();
                    break;
                }
                else if (__TurnCounter >= 9)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!DRAW!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
                }
            }
        }

        private void PlayerTurn()
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
