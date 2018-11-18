using System.Collections.Generic;

namespace Shared.ViewModels
{
    public class Season
    {
        public string Name { get; set; }
        public ICollection<League> Leagues { get; set; }
        public ICollection<Cup> Cups { get; set; }
    }
}