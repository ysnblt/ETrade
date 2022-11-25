﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concretes
{
    //Unit:kg gr gibi birim 
    public class Unit : BaseDescription
    {
        public ICollection<Products> Products { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }

    }
}
