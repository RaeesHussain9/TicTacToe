namespace TestCase.Managers
{
    public class GameManager
    {
        private readonly BoardManager _boardManager;
        private readonly InputManager _inputManager;

        private bool isPlayerXTurn = true;
        private bool isPlayerOTurn = false;

        private int turnCounter = 0;

        public GameManager()
        {
            this._boardManager = new BoardManager();
            this._inputManager = new InputManager();
        }

        public void InputFromUser()
        {
            if (isPlayerXTurn)
            {
                Console.WriteLine("\nit is currently Player X's turn");
            }
            else if (isPlayerOTurn)
            {
                Console.WriteLine("\nit is currently Player O's turn");
            }

            int row = _inputManager.GetInput() - 1;

            int col = _inputManager.GetInput() - 1;

            PlayerTurn(row, col);
        }

        public void PlayerTurn(int row, int col)
        {
           if (_boardManager.PlaceToken(row, col,isPlayerXTurn ? GlobalConsts.X_PLAYER_TOKEN : GlobalConsts.O_PLAYER_TOKEN)) 
            {
                isPlayerXTurn = !isPlayerXTurn;
                isPlayerOTurn = !isPlayerOTurn;
            }
            else 
            {
                Console.WriteLine("\nSpace taken try again");
                InputFromUser();
            }
        }

        public void ResetGame()
        {
            Console.WriteLine("\n++++++++++++++++++++++++++++++NEW GAME++++++++++++++++++++++++++++++++++++++");
            turnCounter = 0;

            isPlayerXTurn = true;
            isPlayerOTurn = false;

            _boardManager.ResetBoard();

            StartGame();

        }

        public void StartGame()
        {
            while (turnCounter < 9)
            {
                _boardManager.PrintBoard();

                InputFromUser();

                turnCounter++;

                if (turnCounter >= 5 && _boardManager.CheckWin())
                {
                    _boardManager.PrintBoard();
                    if (_inputManager.ResetChoiceInput())
                    {
                        ResetGame();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }

                    break;
                }
                else if (turnCounter >= 9)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!DRAW!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    _inputManager.ResetChoiceInput();
                    break;
                }

            }
        }

    }
}
