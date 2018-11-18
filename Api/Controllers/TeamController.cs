using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace Api.Controllers
{
    public class TeamController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new List<Team>
            {
                new Team
                {
                    Name = "Sdv Installatie",
                    ColorShirt = "Wit",
                    ColorShort = "Zwart",
                    TeamPictureUrl = "/images/teams/2016/SDV%20installatietechniek.JPG"
                },
                new Team
                {
                    Name = "Ander team",
                    ColorShirt = "Groen",
                    ColorShort = "Rood",
                    TeamPictureUrl = "/images/teams/2017/SDV%20installatietechniek.JPG"
                }
            });
        }
    }
}
