using System;
using App.Library.DTO;
using DAL;

namespace App.Library.Models
{
    public class UserContext : user
    {
        public bool Login()
        {
            return true;
        }
    }
}
