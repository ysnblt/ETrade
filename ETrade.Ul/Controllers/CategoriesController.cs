using ETrade.Entity.Concretes;
using ETrade.Ul.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace ETrade.Ul.Controllers
{
    public class CategoriesController : Controller
    {
        IUnitOfWork _uow;
        CategoriesModel _model;
        public CategoriesController(IUnitOfWork uow, CategoriesModel model)
        {
            _uow = uow;
            _model = model;
        }
        public IActionResult List()
        {
            var clist = _uow._categoriesRep.List();
            return View(clist);
            //builder.Services.AddScoped<CategoriesModel>();  program.cs e ekle
        }
        public IActionResult Create()
        {
            _model.Head = "Yeni giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            //yeni bir nesne oluşturduk
            _model.Categories = new Categories();
            return View("Crud",_model);
        }
        [HttpPost]
        public IActionResult Create(CategoriesModel model)
        {
            _uow._categoriesRep.Add(model.Categories);
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
            _model.Categories = _uow._categoriesRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Update(CategoriesModel model)
        {
            _uow._categoriesRep.Update(model.Categories);
            _uow.Commit();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Head = "sil";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.Categories = _uow._categoriesRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Delete(CategoriesModel model)
        {
            _uow._categoriesRep.Delete(model.Categories);
            _uow.Commit();
            return RedirectToAction("List");
        }
    }
}
