using System;
using App.Library.Models;

namespace AppAbsen.ViewModels
{
    internal class LoginAdminViewModel
    {
        public UserContext context;

        public CommandHandler CancelCommand { get; }
        public CommandHandler LoginCommand { get; }

        public LoginAdminViewModel()
        {
            context = AppAbsen.Helpers.GetMainViewModel().User;
            CancelCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = CancelCommanAction };
            LoginCommand = new CommandHandler { CanExecuteAction = LoginValidate, ExecuteAction = LoginAction };
        }

        private bool LoginValidate(object obj)
        {
            if (string.IsNullOrEmpty(context.UserName) || string.IsNullOrEmpty(context.Password))
                return false;
            else
                return false;
        }

        private void LoginAction(object obj)
        {
          bool success=  context.Login();
        }

        public Action WindowClose { get; set; }

        private void CancelCommanAction(object obj)
        {
            WindowClose();
        }
    }
}