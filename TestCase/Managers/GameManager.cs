namespace TestCase.Managers
{
    public class GameManager
    {
        private readonly BoardManager _boardManager;

        private bool isPlayerXTurn = true;
        private bool isPlayerOTurn = false;

        private int turnCounter = 0;

        public GameManager()
        {
            this._boardManager = new BoardManager();
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
                    ResetChoiceInput();
                    break;
                }
                else if (turnCounter >= 9)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!DRAW!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    ResetChoiceInput();
                    break;
                }

            }
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
                Console.WriteLine("Space taken try again");
                InputFromUser();
            }
        }

        public void ResetChoiceInput()
        {
            Console.WriteLine();
            Console.WriteLine("would you like to play again. ");

            Console.Write("Y for yes or N for no. ");

            string resetChoice = Console.ReadLine();

            if (resetChoice == "Y")
            {
                ResetGame();
            }
            else if (resetChoice == "y")
            {
                ResetGame();
            }
            else if (resetChoice == "N")
            {
                Environment.Exit(0);
            }
            else if (resetChoice == "n")
            {
                Environment.Exit(0);
            }
        }

        public void ResetGame()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++NEW GAME++++++++++++++++++++++++++++++++++++++");
            turnCounter = 0;

            isPlayerXTurn = true;
            isPlayerOTurn = false;

            _boardManager.ResetBoard();

            StartGame();

        }
        //do not forget to do input handling for the reset choice inputs
        // should ask for inputs in another method

        public int GetInput()
        {
            Console.Write("Enter number between 1 and 3: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num >= 1 && num <= 3)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("you must give a number between 1 and 3");
                    return GetInput();
                }

            }

            Console.WriteLine("Please enter a number between 1 and 3");
            return GetInput();
        }

        public void InputFromUser()
        {
            if (isPlayerXTurn)
            {
                Console.WriteLine("it is currently Player X's turn");
            }
            else if (isPlayerOTurn)
            {
                Console.WriteLine("it is currently Player O's turn");
            }

            int row = GetInput() - 1;

            int col = GetInput() - 1;

            Console.WriteLine($"row input = {row}, col input =  {col}", row, col);

            PlayerTurn(row, col);
        }      

    }
}
