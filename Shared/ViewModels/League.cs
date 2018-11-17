using System.Collections.Generic;

namespace Web.ViewModels
{
    public class League
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public CompetitionPart Competition { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<CompetitionPart> CompetitionParts { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}