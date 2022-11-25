using ETrade.Dto;
using ETrade.Entity.Concretes;
using ETrade.Ul.Models;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace ETrade.Ul.Controllers
{
    public class BasketDetailController : Controller
    {
        IUnitOfWork _uow;
        BasketDetail _basketDetail;
        BasketDetailModel _model;
        public BasketDetailController(IUnitOfWork uow, BasketDetail basketDetail, BasketDetailModel model)
        {
            _uow = uow;
            _basketDetail = basketDetail;
            _model = model;
        }
        public IActionResult Add(int id)
        {
            _model.ProductsDTO = _uow._productsRep.GetProductsSelect();
            _model.BasketDetailDTO = _uow._basketDetailRep.BasketDetailDTO(id);
            return View(_model);
        }
        [HttpPost]
        public IActionResult Add(BasketDetailModel m, int id, int Amount , int ProductId )
        {
              Products products = _uow._productsRep.FindWithVar(m.ProductId);
                _basketDetail.Amount = m.Amount;
                _basketDetail.ProductId = m.ProductId;
                _basketDetail.Id = id;
                _basketDetail.UnitId = products.UnitId;
                _basketDetail.Ratio = products.Vat.Ratio;
                _basketDetail.UnitPrice = products.UnitPrice;
                _uow._basketDetailRep.Add(_basketDetail);
                _uow.Commit();

            return RedirectToAction("Add", new { id });

        }
        public IActionResult Delete(int Id, int productId)
        {
            _uow._basketDetailRep.Delete(Id, productId);
            _uow.Commit();
            return RedirectToAction("Add", new { Id });
        }
        public IActionResult Update(int Id, int ProductId)
        {
            return View(_uow._basketDetailRep.Find(Id, ProductId));
        }
        [HttpPost]
        public IActionResult Update(int Amount, int Id, int ProductId)
        {
            // m.BasketDetailDTO = null;
            // m.ProductsDTO = null;
            //_basketDetail.Amount = m.Amount;
            //_basketDetail.ProductId = m.ProductId;
            //_basketDetail.Id = m.Id;
            //_basketDetail.UnitId = m.UnitId;
            //_basketDetail.UnitPrice = m.UnitPrice;
            //_basketDetail.Ratio = m.Ratio;
            var selected = _uow._basketDetailRep.Find(Id, ProductId);
            selected.Amount = Amount;

            _uow._basketDetailRep.Update(selected);
            _uow.Commit();
            return RedirectToAction("Add", new { Id });
        }

    }
}
