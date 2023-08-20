namespace TestCase.Managers
{
    public class BoardManager
    {
        private const string EMPTY_SPACE_TOKEN = "-";

        private readonly string[,] Board = new string[3, 3] {{"-","-","-"},
                                                             {"-","-","-"},
                                                             {"-","-","-"}};


        public void ResetBoard() 
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i,j] = EMPTY_SPACE_TOKEN;
                }
            }
        }

        public void PrintBoard()
        {
            int rows = Board.GetLength(0);
            int cols = Board.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool PlaceToken(int row, int col, string givenToken)
        {
            if (Board[row, col] == "-")
            {
                Board[row, col] = givenToken;
                return true;
            }

            return false;
        }

        public bool CheckWin()
        {
            int rLen = Board.GetLength(0);
            int cLen = Board.GetLength(1);

            ////////////////////////////////////////check if any rows match
            bool noRowsMatch = true;
            for (int i = 0; i < cLen; i++)
            {
                string firstElement = Board[i, 0];

                bool rowEquals = true;

                for (int j = 0; j < rLen; j++)
                {
                    if (firstElement != Board[i, j])
                    {
                        rowEquals = false;
                        break;
                    }
                }

                if (rowEquals)
                {
                    if (firstElement == GlobalConsts.X_PLAYER_TOKEN)
                    {
                        Console.WriteLine("player X wins");
                        return true;
                    }
                    else if ((firstElement == GlobalConsts.O_PLAYER_TOKEN))
                    {
                        Console.WriteLine("player O wins");
                        return true;
                    }
                }
            }

            /////////////////////////////////////////////////////check if any cols match

            bool noColsMatch = true;
            for (int i = 0; i < rLen; i++)
            {
                string firstColElement = Board[0, i];
                bool colsEquals = true;
                for (int j = 0; j < cLen; j++)
                {
                    if (firstColElement != Board[j, i])
                    {
                        colsEquals = false;
                        break;
                    }
                }
                if (colsEquals)
                {
                    if (firstColElement == GlobalConsts.X_PLAYER_TOKEN)
                    {
                        Console.WriteLine("player X wins");
                        return true;
                    }
                    else if ((firstColElement == GlobalConsts.O_PLAYER_TOKEN))
                    {
                        Console.WriteLine("player O wins");
                        return true;
                    }
                }
            }

            ////////////////////////////////////////////////////////////////main diagonal (TL to BR)

            bool mainDiagonalMatch = true;
            string firstMainDiagonalElement = Board[0, 0];

            for (int i = 0; i < rLen; i++)
            {
                if (firstMainDiagonalElement != Board[i, i])
                {
                    mainDiagonalMatch = false;
                    break;
                }
            }

            if (mainDiagonalMatch)
            {
                if (firstMainDiagonalElement == GlobalConsts.X_PLAYER_TOKEN)
                {
                    Console.WriteLine("player X wins");
                    return true;
                }
                else if (firstMainDiagonalElement == GlobalConsts.O_PLAYER_TOKEN)
                {
                    Console.WriteLine("player O wins");
                    return true;
                }
            }

            ////////////////////////////////////////////////////////////inverse diagonal (TR to BL)

            bool inverseDiagonalMatch = true;
            string firstInverseDiagonuleElement = Board[0, 2];

            for (int i = 0; i < rLen; i++)
            {
                if (firstInverseDiagonuleElement != Board[i, rLen - 1 - i])
                {
                    inverseDiagonalMatch = false;
                    break;
                }
            }

            if (inverseDiagonalMatch)
            {
                if (firstInverseDiagonuleElement == GlobalConsts.X_PLAYER_TOKEN)
                {
                    Console.WriteLine("player X wins");
                    return true;
                }
                else if (firstInverseDiagonuleElement == GlobalConsts.O_PLAYER_TOKEN)
                {
                    Console.WriteLine("player O wins");
                    return true;
                }
            }

            if (!inverseDiagonalMatch && !mainDiagonalMatch && noRowsMatch && noColsMatch)
            {
                Console.WriteLine("no winner yet!!!!!!");
                return false;
            }

            return false;
        }
    }
}
