using ETrade.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    public class Users: BaseEntity
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // normal kullanıcı mı admin mi
        public bool Error { get; set; }
        public ICollection<BasketMaster> BasketMaster { get; set; }
        [ForeignKey("CountyId")]
        public County County { get; set; }
    }
}
