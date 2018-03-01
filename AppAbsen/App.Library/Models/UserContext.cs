using System;
using AppAbsen.Library.DTO;
using DAL;

namespace AppAbsen.Library.Models
{
    
    public class UserContext : user
    {
        public string UserName { get; set; }
        public bool Login()
        {
            UserName = this.UserName;
            return true;
        }
    }
}
