namespace TestCase.Managers
{
    public class GameManager
    {
        private readonly BoardManager _boardManager;
        private readonly InputManager _inputManager;

        private bool isPlayerXTurn;
        private bool isPlayerOTurn;

        private int turnCounter;
        private readonly int positionIndexDiffrence = 1;
        private readonly int maxNumberOfTurns = 9;
        private readonly int minWinChance = 5;



        public GameManager()
        {
            _boardManager = new BoardManager();
            _inputManager = new InputManager();

            InitialiseGame();
        }

        private void GetRowAndColumnPosition()
        {
            Console.WriteLine($"\nit is currently player {(isPlayerXTurn ? GlobalConsts.X_PLAYER_TOKEN : GlobalConsts.O_PLAYER_TOKEN)}'s turn");

            int row = _inputManager.GetInput() - positionIndexDiffrence;

            int col = _inputManager.GetInput() - positionIndexDiffrence;

            PlayerTurn(row, col);
        }

        private void PlayerTurn(int row, int col)
        {
           if (_boardManager.PlaceToken(row, col,isPlayerXTurn ? GlobalConsts.X_PLAYER_TOKEN : GlobalConsts.O_PLAYER_TOKEN)) 
            {
                isPlayerXTurn = !isPlayerXTurn;
                isPlayerOTurn = !isPlayerOTurn;
            }
            else 
            {
                Console.WriteLine("\nSpace taken try again");
                GetRowAndColumnPosition();
            }
        }

        private void InitialiseGame()
        {
            turnCounter = 0;

            isPlayerXTurn = true;
            isPlayerOTurn = false;

        }

        private void ResetGame() 
        {
            Console.WriteLine("\n++++++++++++++++++++++++++++++NEW GAME++++++++++++++++++++++++++++++++++++++");

            InitialiseGame();

            _boardManager.InitializeBoard();

            StartGame();
        }

        public void StartGame()
        {
            while (turnCounter < maxNumberOfTurns)
            {
                _boardManager.PrintBoard();

                GetRowAndColumnPosition();

                turnCounter++;

                if (turnCounter >= minWinChance && _boardManager.CheckWin())
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
                else if (turnCounter >= maxNumberOfTurns)
                {
                    Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!DRAW!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    _inputManager.ResetChoiceInput();
                    break;
                }

            }
        }

    }
}
