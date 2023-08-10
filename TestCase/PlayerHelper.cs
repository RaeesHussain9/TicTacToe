namespace TestCase
{
    public static class PlayerHelper
    {
        public const string XPLAYERTOKEN = "X";
        public const string OPLAYERTOKEN = "O";

        public static string GetPlayerToken(Player player) => player switch
        {
            Player.Crosses => XPLAYERTOKEN,
            Player.Noughts => OPLAYERTOKEN,
            _ => string.Empty
        };
    }
}
