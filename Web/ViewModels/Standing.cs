namespace Web.ViewModels
{
    public class Standing
    {
        public Team Team { get; set; }
        public int Games { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Draw { get; set; }
        public int Points { get; set; }
        public int GoalsAhead { get; set; }
        public int GoalsAgainst { get; set; }
        public string Remark { get; set; }
    }
}