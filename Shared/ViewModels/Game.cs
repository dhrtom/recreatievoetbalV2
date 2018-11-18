using System;
using System.Collections.Generic;

namespace Shared.ViewModels
{
    public class Game
    {
        public Team HallService { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public int HomeScore { get; set; }
        public int GuestScore { get; set; }
        public ICollection<GameEvent> Events { get; set; }
    }
}