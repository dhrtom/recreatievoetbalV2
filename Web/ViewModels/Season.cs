using System.Collections.Generic;

namespace Web.ViewModels
{
    public class Season
    {
        public string Name { get; set; }
        public ICollection<League> Leagues { get; set; }
        public ICollection<Cup> Cups { get; set; }
    }
}