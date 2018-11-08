using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Web.ViewModels;

namespace Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly IOptions<AppSettings> _appSettings;

        public TeamController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
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
