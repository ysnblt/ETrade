using ETrade.Entity.Concretes;
using ETrade.Ul.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace ETrade.Ul.Controllers
{
    public class CityController : Controller
    {
        IUnitOfWork _uow;
        CityModel _model;
        public CityController(IUnitOfWork uow, CityModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uow._cityRep.List();
            return View(clist);
            //builder.Services.AddScoped<CityModel>();  program.cs e ekle
        }
        public IActionResult Create()
        {
            _model.Head = "Yeni giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            //yeni bir nesne oluşturduk
            _model.City = new City();
            return View("Crud",_model);
        }
        [HttpPost]
        public IActionResult Create(CityModel model)
        {
            _uow._cityRep.Add(model.City);
            //herşey uow de olcak
            //add
            //update
            //Delete
            _uow.Commit();
            return RedirectToAction("List");
            //Program.cs de newledik.
        }
        public IActionResult Update(int Id)
        {
            _model.Head = "güncelle";
            _model.Text = "güncelle";
            _model.Cls = "btn btn-success";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Update(CityModel model)
        {
            _uow._cityRep.Update(model.City);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Head = "sil";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(CityModel model)
        {
            _uow._cityRep.Delete(model.City);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
