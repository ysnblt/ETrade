using ETrade.Entity.Abstracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class BasketDetail 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }  //fiyatlar değişirse görmek için
        public int Amount { get; set; }
        public decimal Ratio { get; set; }    //fiyatlar-kdv değişirse görmek için
        public int UnitId { get; set; }    //fiyatlar değişirse görmek için
        [ForeignKey("Id")]
        public BasketMaster BasketMaster { get; set; }
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        [ForeignKey("ProductId")]
        public Products Products { get; set; }
    }
}
