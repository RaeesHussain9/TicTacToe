namespace TestCase.Managers
{
    public class GameManager
    {
        private readonly BoardManager _boardManager;
        private readonly InputManager _inputManager;

        private bool isPlayerXTurn;

        private int turnCounter;
        private readonly int positionIndexDifference = 1;
        private readonly int maxNumberOfTurns = 9;
        private readonly int minWinChance = 5;



        public GameManager()
        {
            _boardManager = new BoardManager();
            _inputManager = new InputManager();

            InitialiseGame();
        }

        private void HandleRowAndColumnPosition()
        {
            Console.WriteLine($"\nit is currently player {(isPlayerXTurn ? GlobalConsts.X_PLAYER_TOKEN : GlobalConsts.O_PLAYER_TOKEN)}'s turn");

            int row = _inputManager.GetRowAndColumnPosition() - positionIndexDifference;

            int col = _inputManager.GetRowAndColumnPosition() - positionIndexDifference;

            PlayerTurn(row, col);
        }

        private void PlayerTurn(int row, int col)
        {
           if (_boardManager.PlaceToken(row, col,isPlayerXTurn ? GlobalConsts.X_PLAYER_TOKEN : GlobalConsts.O_PLAYER_TOKEN)) 
            {
                isPlayerXTurn = !isPlayerXTurn;
            }
            else 
            {
                Console.WriteLine("\nSpace taken try again");
                HandleRowAndColumnPosition();
            }
        }

        private void InitialiseGame()
        {
            turnCounter = 0;

            isPlayerXTurn = true;

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

                HandleRowAndColumnPosition();

                turnCounter++;

                if (turnCounter >= minWinChance && _boardManager.CheckWin())
                {
                    _boardManager.PrintBoard();
                 
                    if (_inputManager.ResetChoice())
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
                    _inputManager.ResetChoice();
                    break;
                }

            }
        }

    }
}
