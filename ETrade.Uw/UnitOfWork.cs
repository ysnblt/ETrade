using ETrade.Dal;
using ETrade.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Uw
{
    public class UnitOfWork : IUnitOfWork
    {
         TradeContext _db;
        public UnitOfWork(TradeContext db,IBasketDetailRep basketDetailRep,IBasketMasterRep basketMasterRep,ICategoriesRep categoriesRep,ICityRep cityRep, ICountyRep countyRep, IProductsRep productsRep, ISuppliersRep suppliersRep, IUnitRep unitRep, IUsersRep usersRep, IVatRep vatRep)
        {
            _db = db;
            _basketDetailRep = basketDetailRep;
            _basketMasterRep = basketMasterRep;
            _categoriesRep = categoriesRep;
            _cityRep = cityRep;
            _countyRep = countyRep;
            _productsRep = productsRep;
            _unitRep = unitRep;
            _usersRep = usersRep;
            _vatRep = vatRep;
            _suppliersRep = suppliersRep;
        }

       

        public IBasketDetailRep _basketDetailRep {get;set;}

        public IBasketMasterRep _basketMasterRep { get; set; }

        public ICategoriesRep _categoriesRep  { get; set;}

        public ICityRep _cityRep { get; set; }

        public ICountyRep _countyRep { get; set; }

        public IProductsRep _productsRep { get; set; }

        public ISuppliersRep _suppliersRep { get; set; }

        public IUnitRep _unitRep { get; set; }

        public IUsersRep _usersRep { get; set; }

        public IVatRep _vatRep { get; set; }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
