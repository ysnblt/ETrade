using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
   // Vat:KDV
    public class Vat : BaseDescription
    {
        public decimal Ratio { get; set; }
        //Ratio:Oran
        public ICollection<Products> Products { get; set; }
    }
}
