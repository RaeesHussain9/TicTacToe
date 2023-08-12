namespace TestCase.Managers
{
    public class InputManager
    {
        private readonly int __MinValue;
        private readonly int __MaxValue;
        private readonly PlayerManager __PlayerManager;

        public InputManager(int minInputValue, int maxInputValue, PlayerManager playerManager)
        {
            __MinValue = minInputValue;
            __MaxValue = maxInputValue;
            __PlayerManager = playerManager;
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

        public PlayerPosition GetPlayerPositionFromUser()
        {
            Console.WriteLine($"Player '{__PlayerManager.GetPlayerToken()}' turn");

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
