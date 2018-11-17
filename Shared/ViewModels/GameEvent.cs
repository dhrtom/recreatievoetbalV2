namespace Web.ViewModels
{
    public class GameEvent
    {
        public Player Player { get; set; }    
        public GameEventType Type { get; set; }

        public enum GameEventType
        {
            Goal,
            OwnGoal,
            YellowCard,
            RedCard,
            Penalty
        }
    }
}