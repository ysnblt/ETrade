using ETrade.Entity.Concretes;
using ETrade.Ul.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace ETrade.Ul.Controllers
{
    public class UnitController : Controller
    {
        IUnitOfWork _uow;
        UnitModel _model;
        public UnitController(IUnitOfWork uow, UnitModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uow._unitRep.List();
            return View(clist);
            //builder.Services.AddScoped<UnitModel>();  program.cs e ekle
        }
        public IActionResult Create()
        {
            _model.Head = "Yeni giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            //yeni bir nesne oluşturduk
            _model.Unit = new Unit();
            return View("Crud",_model);
        }
        [HttpPost]
        public IActionResult Create(UnitModel model)
        {
            _uow._unitRep.Add(model.Unit);
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
            _model.Unit = _uow._unitRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Update(UnitModel model)
        {
            _uow._unitRep.Update(model.Unit);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Head = "sil";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.Unit = _uow._unitRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(UnitModel model)
        {
            _uow._unitRep.Delete(model.Unit);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
