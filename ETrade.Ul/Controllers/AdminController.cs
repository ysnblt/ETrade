using ETrade.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.Ul.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var s = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            ViewBag.User = s.Mail;
            return View();
        }
    }
}
