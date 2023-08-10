namespace TestCase.Managers
{
    public class BoardManager
    {
        private const string EMPTY_SPACE = "-";

        private readonly int __Rows;
        private readonly int __Columns;
        private string[][] __Board;

        public BoardManager(int rows, int columns)
        {
            __Rows = rows;
            __Columns = columns;

            InstantiateBoard();
        }

        public bool AddPlayerPositionToBoard(Player player, int row, int column)
        {
            --row;
            --column;

            if (__Board[row][column] == EMPTY_SPACE)
            {
                __Board[row][column] = PlayerHelper.GetPlayerToken(player);

                return true;
            }
             
            return false;
        }

        private void InstantiateBoard() 
        {
            __Board = Enumerable.Range(0, __Rows).Select(row => Enumerable.Range(0, __Columns).Select(element => EMPTY_SPACE).ToArray()).ToArray(); 
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < __Rows; i++)
            {
                for (int j = 0; j < __Columns; j++)
                {
                    Console.Write(__Board[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool CheckWin()
        {
            ////////////////////////////////////////check if any rows match
            bool noRowsMatch = true;
            for (int i = 0; i < __Columns; i++)
            {
                string firstElement = __Board[i][0];

                bool rowEquals = true;

                for (int j = 0; j < __Rows; j++)
                {
                    if (firstElement != __Board[i][j])
                    {
                        rowEquals = false;
                        break;
                    }
                }

                if (rowEquals)
                {
                    if (firstElement == PlayerHelper.XPLAYERTOKEN)
                    {
                        Console.WriteLine("player X wins");
                        noRowsMatch = false;
                        return true;
                    }
                    else if ((firstElement == PlayerHelper.OPLAYERTOKEN))
                    {
                        Console.WriteLine("player O wins");
                        noRowsMatch = false;
                        return true;
                    }
                }
            }

            /////////////////////////////////////////////////////check if any cols match
            bool noColsMatch = true;
            for (int i = 0; i < __Rows; i++)
            {
                string firstColElement = __Board[0][i];
                bool colsEquals = true;
                for (int j = 0; j < __Columns; j++)
                {
                    if (firstColElement != __Board[j][i])
                    {
                        Console.WriteLine("do something");
                        colsEquals = false;
                        break;
                    }
                }
                if (colsEquals)
                {
                    if (firstColElement == PlayerHelper.XPLAYERTOKEN)
                    {
                        Console.WriteLine("player X wins");
                        noColsMatch = false;
                        return true;
                    }
                    else if ((firstColElement == PlayerHelper.OPLAYERTOKEN))
                    {
                        Console.WriteLine("player O wins");
                        noColsMatch = false;
                        return true;
                    }
                }
            }

            ////////////////////////////////////////////////////////////////main diagonal (TL to BR)
            bool mainDiagonalMatch = true;
            string firstMainDiagonalElement = __Board[0][0];

            for (int i = 0; i < __Rows; i++)
            {
                if (firstMainDiagonalElement != __Board[i][i])
                {
                    mainDiagonalMatch = false;
                    break;
                }
            }

            if (mainDiagonalMatch)
            {
                if (firstMainDiagonalElement == PlayerHelper.XPLAYERTOKEN)
                {
                    Console.WriteLine("player X wins");
                    return true;
                }
                else if (firstMainDiagonalElement == PlayerHelper.OPLAYERTOKEN)
                {
                    Console.WriteLine("player O wins");
                    return true;
                }
            }

            ////////////////////////////////////////////////////////////inverse diagonal (TR to BL)

            bool inverseDiagonalMatch = true;
            string firstInverseDiagonuleElement = __Board[0][2];

            for (int i = 0; i < __Rows; i++)
            {
                if (firstInverseDiagonuleElement != __Board[i][__Rows - 1 - i])
                {
                    inverseDiagonalMatch = false;
                    break;
                }
            }

            if (inverseDiagonalMatch)
            {
                if (firstInverseDiagonuleElement == PlayerHelper.XPLAYERTOKEN)
                {
                    Console.WriteLine("player X wins");
                    return true;
                }
                else if (firstInverseDiagonuleElement == PlayerHelper.OPLAYERTOKEN)
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

            //OVERALL IT WORKS AS IT IS INTENDED TO WORK CHECKS ALL WIN CONDITIONS CORRECTLY.
            //HOWEVER ALL OTHER CHECKS STILL RUN EVEN AFTER A WIN CONDITION IS ALREADY FOUND.
            //THIS SHOULD BE FIXED IF THE REST OF THE GAME IS DONE SINCE CALLING OTHER METHODS SHOULD END THE METHOD BY RUNNINGA ANOTHER METHODS
            return false;
        }

    }
}
