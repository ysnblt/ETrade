using ETrade.Entity.Concretes;
using ETrade.Ul.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.Ul.Controllers
{
    public class AuthController : Controller
    {
        UsersModel _model;
        IUnitOfWork _uow;
        public AuthController(UsersModel model, IUnitOfWork uow)
        {
            _model = model;
            _uow = uow;
        }
        public IActionResult Register()
        {
            _model.User = new Users();
            _model.Counties = _uow._countyRep.List();
            return View(_model);
        }
        [HttpPost]
        public IActionResult Register(UsersModel? m)
        {
            m.User = _uow._usersRep.CreateUser(m.User);
            if (m.User.Error == true)  //hata
            {

                m.Counties = _uow._countyRep.List();
                m.Error = $"{m.User.Mail} Kullanıcı mevcut!";
                return View(m);
                //return RedirectToAction("Error", "Home", new { Msg = $"{m.User.Mail} Kullanıcı mevcut!" });
            }
            else
            {
                m.User.Role = "User";
                _uow._usersRep.Add(m.User);
                _uow.Commit();
                return RedirectToAction("Error", "Home" , new { Msg = $"{m.User.Mail} Kullanıcı başarıyla kayıt edilmiştir." });
            }

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Mail, string Password)
        {
            var usr = _uow._usersRep.Login(Mail, Password);
            if (usr.Error == false)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(usr));
                if (usr.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();                                                              
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
