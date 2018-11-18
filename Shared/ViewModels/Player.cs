namespace Shared.ViewModels
{
    public class Player
    {
        public string Name { get; set; }   
        public Team Team { get; set; }   
        public string Function { get; set; }   
        public int Games { get; set; }   
        public int Goals { get; set; }   
        public int OwnGoals { get; set; }   
        public int YellowCards { get; set; }   
        public int RedCards { get; set; }   
    }
}