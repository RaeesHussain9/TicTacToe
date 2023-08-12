namespace TestCase.Managers
{
    public class PlayerManager
    {
        private Player __Player;

        public PlayerManager(Player currentPlayer)
            => __Player = currentPlayer;

        public string GetPlayerToken() => __Player switch
        {
            Player.Crosses => GlobalConstants.X_PLAYER_TOKEN,
            Player.Noughts => GlobalConstants.O_PLAYER_TOKEN,
            _ => string.Empty
        };

        public Player NextPlayerTurn()
            => __Player = __Player == Player.Crosses ? Player.Noughts : Player.Crosses;
    }
}
