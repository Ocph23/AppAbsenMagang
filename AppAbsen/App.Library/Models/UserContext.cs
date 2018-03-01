using System;
using System.Collections.Generic;
using System.Linq;
using AppAbsen.Library.DTO;
using DAL;

namespace AppAbsen.Library.Models
{
    
    public class UserContext : user
    {
        public List<user> datauser = new List<user>();
        public bool Login()
        {
            
            using (var db = new OcphDbContext())
            {
                datauser = db.Users.Where(o=>o.UserName==this.UserName && Password==this.Password).ToList();
                if (datauser.Count == 0)
                    return false;
                else
                    return true;
            }
           
        }
    }
}
