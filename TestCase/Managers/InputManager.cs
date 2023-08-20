using System.Runtime.Intrinsics.X86;

namespace TestCase.Managers
{
    public class InputManager
    {
        public int GetInput()
        {
            Console.Write("\nEnter number between 1 and 3: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num >= 1 && num <= 3)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("\nyou must give a number between 1 and 3");
                    return GetInput();
                }
            }
            Console.WriteLine("\nPlease enter a number between 1 and 3");
            return GetInput();
        }

        public bool ResetChoiceInput()
        {
            Console.WriteLine();
            Console.WriteLine("\nwould you like to play again. ");

            Console.Write("\nY for yes or N for no. ");

            string resetChoice = Console.ReadLine();

            if (resetChoice == "Y")
            {
                return true;
            }
            else if (resetChoice == "y")
            {
                return true;
            }
            else if (resetChoice == "N")
            {
                return false;
            }
            else if (resetChoice == "n")
            {
                return false;
            }

            Console.WriteLine("\nplease input something");
            return ResetChoiceInput();
        }
    }
}
