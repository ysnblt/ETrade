using ETrade.Dto;
using ETrade.Ul.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ETrade.Ul.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error(string Msg)
        {
            ViewBag.Msg=Msg;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}