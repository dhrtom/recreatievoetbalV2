﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels.Other;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fallback()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        public void AddSubscription(Subscription Subscription) {

           
        }

        public void TriggerPush() {

            
        }
    }
}
