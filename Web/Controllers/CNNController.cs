using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Shared;

namespace Web.Controllers
{
    public class CNNController : Controller
    {
        public CNNController()
        {
        }
        public async Task<IActionResult> Index()
        {
            var restClient = new RestSharp.RestClient("http://localhost:5001");
            var result = await restClient.GetAsync<List<RSSFeed>>(new RestRequest
            {
                Method = Method.GET,
                Resource = "/api/values"
            });

            return View(result);
        }
    }
}
