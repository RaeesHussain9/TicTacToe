namespace TestCase.Managers
{
    public class InputManager
    {
        public int GetRowAndColumnPosition()
        {
            Console.Write("\nEnter number between 1 and 3: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num >= 1 && num <= 3)
                {
                    return num;
                }
            }
            Console.WriteLine("\nPlease enter a number between 1 and 3");
            return GetRowAndColumnPosition();
        }

        public bool ResetChoice()
        {
            Console.WriteLine("\nwould you like to play again. ");

            Console.Write("\nY for yes or N for no. ");

            string resetChoice = Console.ReadLine();

            if (string.Equals(resetChoice, "y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(resetChoice, "n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

                Console.WriteLine("\nplease input something");
            return ResetChoice();
        }
    }
}
