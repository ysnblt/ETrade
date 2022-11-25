using ETrade.Dto;
using ETrade.Entity.Concretes;
using ETrade.Uw;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.Ul.Controllers
{
    public class BasketMasterController : Controller
    {
        IUnitOfWork _uow;
        BasketMaster _basketMaster;
        public BasketMasterController(IUnitOfWork uow , BasketMaster basketMaster)
        {
            _uow = uow;
            _basketMaster = basketMaster;
        }
        public IActionResult Create()
        {
            var user = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            var selectedMaster = _uow._basketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == user.Id);
            if(selectedMaster != null)
            {
               return RedirectToAction("Add" , "BasketDetail" , new { id = selectedMaster.Id });
            }
            else
            {

                _basketMaster.OrderDate = DateTime.Now;
                _basketMaster.EntityId = user.Id;
                _uow._basketMasterRep.Add(_basketMaster);
                _uow.Commit();
                return RedirectToAction("Add", "BasketDetail", new { id = _basketMaster.Id });
            }
 
        }
    }
}
