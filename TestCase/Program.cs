//====================================To do list=====================================================
// 1st - between each turn say whos turn it currently is
// 2nd - input handling (optionally return it to redo the specific x or y input that needs redoing)
// 3rd - loop it so that the players can play again if they want to
// 4th - split out the code into different classes
// 5th - (optional) redo check win method to see if it can be shorter
// 6th - post code to github get code reviewed by Avtar.

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
            while (turnCounter < 9)
            {
                PrintBoard();

                InputFromUser();

                turnCounter++;

                if (turnCounter >= 5 && CheckWin())
                {
                    PrintBoard();
                    break;
                }
                else if (turnCounter >= 9)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!DRAW!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
                }

            }
        }

        private static int GetInput()
        {
            Console.WriteLine("Enter number: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                return num;
            }

            return GetInput();
        }

        private static void InputFromUser()
        {
            Console.Write("Input a number between 0 and 2. ");

            int xPLane = int.Parse(Console.ReadLine());

            Console.Write("Input a number between 0 and 2. ");

            int yPlane = int.Parse(Console.ReadLine());

            PlayerTurn(xPLane, yPlane);
        }

        private static void PlayerTurn(int xPlane, int yPlane)
        {
            
            if (Board[xPlane, yPlane] == "-")
            {
                Board[xPlane, yPlane] = isPlayerXTurn ? XPLAYERTOKEN : OPLAYERTOKEN;

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
                        //Console.WriteLine("somethings hapening");
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

            //Console.WriteLine();

            bool noColsMatch = true;
            for (int i = 0; i < rLen; i++)
            {
                string firstColElement = Board[0, i];
                bool colsEquals = true;
                for (int j = 0; j < cLen; j++)
                {
                    if (firstColElement != Board[j, i])
                    {
                        Console.WriteLine("do something");
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
                    Console.WriteLine("doing something");
                    Console.WriteLine("current arr value = {0}; array index = {1}", Board[i, i], i);
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
                    Console.WriteLine("doing something");
                    Console.WriteLine("current arr value = {0}; array index = {1}", Board[i, rLen - 1 - i], i);
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

            //OVERALL IT WORKS AS IT IS INTENDED TO WORK CHECKS ALL WIN CONDITIONS CORRECTLY.
            //HOWEVER ALL OTHER CHECKS STILL RUN EVEN AFTER A WIN CONDITION IS ALREADY FOUND.
            //THIS SHOULD BE FIXED IF THE REST OF THE GAME IS DONE SINCE CALLING OTHER METHODS SHOULD END THE METHOD BY RUNNINGA ANOTHER METHODS
            return false;
        } 

    }
}