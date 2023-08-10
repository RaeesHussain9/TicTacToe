namespace TestCase.Managers
{
    public class InputManager
    {
        private readonly int __MinValue;
        private readonly int __MaxValue;

        public InputManager(int minInputValue, int maxInputValue)
        {
            __MinValue = minInputValue;
            __MaxValue = maxInputValue;
        }

        private int GetInput(BoardPosition position)
        {
            Console.WriteLine($"Choose {position} position - Enter a number between {__MinValue} and {__MaxValue}: ");

            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num >= __MinValue && num <= __MaxValue)
                {
                    return num;
                }
            }

            return GetInput(position);
        }

        public PlayerPosition GetPlayerPositionFromUser(Player currentPlayer)
        {
            Console.WriteLine($"Player '{(PlayerHelper.GetPlayerToken(currentPlayer))}' turn");

            int row = GetInput(BoardPosition.Row);

            int column = GetInput(BoardPosition.Column);

            return new PlayerPosition 
            {
                Row = row,
                Column = column 
            };
        }

    }
}
