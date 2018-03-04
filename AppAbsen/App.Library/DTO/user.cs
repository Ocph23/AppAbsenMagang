using DAL;
using System;
namespace AppAbsen.Library.DTO
{
    [TableName("user")]
    public class user:BaseNotify
    {
        private string userName;
        private string password;
        private string confirmPassword;


        [PrimaryKey("UserName")]
        [DbColumn("UserName")]
        public string UserName
        {
            get { return userName; }
            set {SetProperty(ref userName ,value); }
        }

        [DbColumn("Password")]
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        [DbColumn("ConfirmPassword")]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }

    }
}
