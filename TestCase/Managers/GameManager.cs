namespace TestCase.Managers
{
    public class GameManager
    {
        private int __TurnCounter;

        private readonly BoardManager __BoardManager;
        private readonly InputManager __InputManager;
        private readonly PlayerManager __PlayerManager;

        public GameManager()
        {
            int _GridSize = 3;
            __PlayerManager = new PlayerManager(Player.Crosses);
            __BoardManager = new BoardManager(_GridSize, _GridSize, __PlayerManager);
            __InputManager = new InputManager(1, _GridSize, __PlayerManager);

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
                    Console.WriteLine("!!!!!!DRAW!!!!!!!");
                    break;
                }
            }
        }

        private void PlayerTurn()
        {
            PlayerPosition _Position = __InputManager.GetPlayerPositionFromUser();

            if (__BoardManager.AddPlayerPositionToBoard(_Position.Row, _Position.Column))
            {
               __PlayerManager.NextPlayerTurn();
            }
            else
            {
                Console.WriteLine("Space already taken try again");
                PlayerTurn();
            }

        }
    }
}
