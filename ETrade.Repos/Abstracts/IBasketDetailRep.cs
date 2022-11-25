﻿using ETrade.Core;
using ETrade.Dto;
using ETrade.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Abstracts
{
    public interface IBasketDetailRep : IBaseRepository<BasketDetail>
    {
      List<BasketDetailDTO> BasketDetailDTO(int MasterId); // login olmuş usera ait yada entity diyebiliriz id'yi çeker
      
    }
}
