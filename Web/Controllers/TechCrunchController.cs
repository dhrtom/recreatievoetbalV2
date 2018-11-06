using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Service;

namespace Web.Controllers
{
    public class TechCrunchController : Controller
    {
        private readonly IRSSReaderService _rssreader;
        const string TC_RSS_Feed = "http://feeds.feedburner.com/TechCrunch/";

        public TechCrunchController(IRSSReaderService rssreader)
        {
            _rssreader = rssreader;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _rssreader.ReadAsync(TC_RSS_Feed);
            return View(result);
        }
    }
}
