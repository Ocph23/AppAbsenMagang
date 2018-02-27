using System;
namespace AppAbsen.Library.DTO
{
    public class user:BaseNotify
    {
        private string userName;
        private string password;
        private string confirmPassword;

        public string UserName
        {
            get { return userName; }
            set {SetProperty(ref userName ,value); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { SetProperty(ref confirmPassword, value); }
        }

    }
}
