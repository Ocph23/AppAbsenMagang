using System;
using AppAbsen.Library.DTO;
using DAL;

namespace AppAbsen.Library.Models
{
    public class UserContext : user
    {
        public bool Login()
        {
            return true;
        }
    }
}
