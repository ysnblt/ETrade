﻿using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concretes;
using ETrade.Repos.Abstracts;
using BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Dto;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ETrade.Repos.Concretes
{
    public class UsersRep<T> : BaseRepository<Users>, IUsersRep where T : class
    {
        TradeContext _db;
        public UsersRep(TradeContext db) : base(db)
        {
            _db = db;
        }

        public Users CreateUser(Users u)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == u.Mail);   //key olmak zorunda değil Find() deseydik key olmalıydı
            if (selectedUser == null)
            {
                u.Password = BCrypt.Net.BCrypt.HashPassword(u.Password);
                u.Error = false;
            }
            else { u.Error = true; }
            return u;

        }

        public UserDTO Login(string username, string password)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == username);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            UserDTO user = new UserDTO();
            if (selectedUser != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(password, selectedUser.Password);
                if(verified == true)
                {
                    user.Id = selectedUser.Id;
                    user.Mail = selectedUser.Mail;
                    user.Role = selectedUser.Role;
                    user.Error = false;
                 
                }
                else
                {
                    user.Error = true;
                }
            }
            else
            {
                user.Error = true;
            }

            return user;
        }
    }
}
