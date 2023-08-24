namespace TestCase.Managers
{
    public class BoardManager
    {
        private const string EMPTY_SPACE_TOKEN = "-";

        private string[,] _board;

        public BoardManager()
        {
            InitializeBoard();
        }

        public bool CheckWin()
        {
            int rowLength = _board.GetLength(0);
            int columnLength = _board.GetLength(1);

            ////////////////////////////////////////check if any rows match
            bool noRowsMatch = true;
            for (int i = 0; i < columnLength; i++)
            {
                string firstRowElement = _board[i, 0];

                bool rowEquals = true;

                for (int j = 0; j < rowLength; j++)
                {
                    if (firstRowElement != _board[i, j])
                    {
                        rowEquals = false;
                        break;
                    }
                }

                if (rowEquals)
                {
                    if (firstRowElement == GlobalConsts.X_PLAYER_TOKEN)
                    {
                        Console.WriteLine("\nplayer X wins");
                        return true;
                    }
                    else if ((firstRowElement == GlobalConsts.O_PLAYER_TOKEN))
                    {
                        Console.WriteLine("\nplayer O wins");
                        return true;
                    }
                }
            }

            /////////////////////////////////////////////////////check if any cols match

            bool noColsMatch = true;
            for (int i = 0; i < rowLength; i++)
            {
                string firstColumnElement = _board[0, i];
                bool colsEquals = true;
                for (int j = 0; j < columnLength; j++)
                {
                    if (firstColumnElement != _board[j, i])
                    {
                        colsEquals = false;
                        break;
                    }
                }
                if (colsEquals)
                {
                    if (firstColumnElement == GlobalConsts.X_PLAYER_TOKEN)
                    {
                        Console.WriteLine("\nplayer X wins");
                        return true;
                    }
                    else if ((firstColumnElement == GlobalConsts.O_PLAYER_TOKEN))
                    {
                        Console.WriteLine("\nplayer O wins");
                        return true;
                    }
                }
            }

            ////////////////////////////////////////////////////////////////main diagonal (TL to BR)

            bool mainDiagonalMatch = true;
            string firstMainDiagonalElement = _board[0, 0];

            for (int i = 0; i < rowLength; i++)
            {
                if (firstMainDiagonalElement != _board[i, i])
                {
                    mainDiagonalMatch = false;
                    break;
                }
            }

            if (mainDiagonalMatch)
            {
                if (firstMainDiagonalElement == GlobalConsts.X_PLAYER_TOKEN)
                {
                    Console.WriteLine("\nplayer X wins");
                    return true;
                }
                else if ((firstMainDiagonalElement == GlobalConsts.O_PLAYER_TOKEN))
                {
                    Console.WriteLine("\nplayer O wins");
                    return true;
                }
            }

            ////////////////////////////////////////////////////////////inverse diagonal (TR to BL)

            bool inverseDiagonalMatch = true;
            string firstInverseDiagonuleElement = _board[0, 2];

            for (int i = 0; i < rowLength; i++)
            {
                if (firstInverseDiagonuleElement != _board[i, rowLength - 1 - i])
                {
                    inverseDiagonalMatch = false;
                    break;
                }
            }

            if (inverseDiagonalMatch)
            {
                if (firstInverseDiagonuleElement == GlobalConsts.X_PLAYER_TOKEN)
                {
                    Console.WriteLine("\nplayer X wins");
                    return true;
                }
                else if ((firstInverseDiagonuleElement == GlobalConsts.O_PLAYER_TOKEN))
                {
                    Console.WriteLine("\nplayer O wins");
                    return true;
                }
            }

            if (!inverseDiagonalMatch && !mainDiagonalMatch && noRowsMatch && noColsMatch)
            {
                return false;
            }

            return false;
        }

        public void InitializeBoard()
        {
           _board = new string[3, 3] {{"-","-","-"},
                                      {"-","-","-"},
                                      {"-","-","-"}};
        }

        public bool PlaceToken(int row, int col, string givenToken)
        {
            if (_board[row, col] == EMPTY_SPACE_TOKEN)
            {
                _board[row, col] = givenToken;
                return true;
            }

            return false;
        }

        public void PrintBoard()
        {
            int rows = _board.GetLength(0);
            int cols = _board.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
