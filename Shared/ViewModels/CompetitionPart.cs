using System.Collections.Generic;

namespace Web.ViewModels
{
    public class CompetitionPart
    {
        public string Name { get; set; } // Totaalstand van A1 Cup    
        public ICollection<Standing> Standings { get; set; }    
    }
}