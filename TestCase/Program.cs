//====================================To do list=====================================================
// 1st - between each turn say whos turn it currently is - COMPLETED
// 2nd - input handling (optionally return it to redo the specific x or y input that needs redoing) - COMPLETED
// 3rd - loop it so that the players can play again if they want to - COMPLETED
// 4th - split out the code into different classes
// 5th - (optional) redo check win method to see if it can be shorter
// 6th - make the game look nicer by putting Console.WriteLines between each print
// 7th - post code to github get code reviewed by Avtar.

namespace Tut1
{
    public class Program
    {
        private const string XPLAYERTOKEN = "X";
        private const string OPLAYERTOKEN = "O";

        private static bool isPlayerXTurn = true;
        private static bool isPlayerOTurn = false;

        private static int turnCounter = 0;

        private static string[,] Board = new string[3, 3] {{"-","-","-"},
                                                           {"-","-","-"},
                                                           {"-","-","-"}};

        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame() 
        {
            while (turnCounter < 9)
            {
                PrintBoard();

                InputFromUser();

                turnCounter++;

                if (turnCounter >= 5 && CheckWin())
                {
                    PrintBoard();
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

        private static void ResetChoiceInput()
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

            private static void ResetGame()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++NEW GAME++++++++++++++++++++++++++++++++++++++");
            turnCounter = 0;

            isPlayerXTurn = true;
            isPlayerOTurn = false;

            Board = new string[3, 3] { {"-","-","-"},
                                       {"-","-","-"},
                                       {"-","-","-"}};

            StartGame();

        }
        //do not forget to do input handling for the reset choice inputs
        // should ask for inputs in another method

            private static int GetInput()
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

        private static void InputFromUser()
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

        private static void PlayerTurn(int row, int col)
        {
            
            if (Board[row, col] == "-")
            {
                Board[row, col] = isPlayerXTurn ? XPLAYERTOKEN : OPLAYERTOKEN;

                isPlayerXTurn = !isPlayerXTurn;
                isPlayerOTurn = !isPlayerOTurn;
            }
            else
            {
                Console.WriteLine("Space already taken try again");
                InputFromUser();
            }

        }

        private static void PrintBoard() 
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



        private static bool CheckWin()
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
                    if (firstElement == XPLAYERTOKEN)
                    {
                        Console.WriteLine("player X wins");
                        noRowsMatch = false;
                        return true;
                    }
                    else if ((firstElement == OPLAYERTOKEN))
                    {
                        Console.WriteLine("player O wins");
                        noRowsMatch = false;
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
                    if (firstColElement == XPLAYERTOKEN)
                    {
                        Console.WriteLine("player X wins");
                        noColsMatch = false;
                        return true;
                    }
                    else if ((firstColElement == OPLAYERTOKEN))
                    {
                        Console.WriteLine("player O wins");
                        noColsMatch = false;
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
                if (firstMainDiagonalElement == XPLAYERTOKEN)
                {
                    Console.WriteLine("player X wins");
                    return true;
                }
                else if (firstMainDiagonalElement == OPLAYERTOKEN)
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
                if (firstInverseDiagonuleElement == XPLAYERTOKEN)
                {
                    Console.WriteLine("player X wins");
                    return true;
                }
                else if (firstInverseDiagonuleElement == OPLAYERTOKEN)
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