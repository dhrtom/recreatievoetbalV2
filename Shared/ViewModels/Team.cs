using System.Collections.Generic;

namespace Shared.ViewModels
{
    public class Team
    {
        public string Name { get; set; }
        public string TeamPictureUrl { get; set; }
        public League League { get; set; }
        public string ColorShort { get; set; }
        public string ColorShirt { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}