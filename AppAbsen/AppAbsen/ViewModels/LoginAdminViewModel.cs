using System;
using AppAbsen.Library.Models;
using AppAbsen.Views;
using AppAbsen.ViewModels;

namespace AppAbsen.ViewModels
{
    internal class LoginAdminViewModel
    {
        public UserContext context = new UserContext();
        public CommandHandler CancelCommand { get; }
        public CommandHandler LoginCommand { get; }

        public LoginAdminViewModel()
        {
            CancelCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = CancelCommanAction };
            LoginCommand = new CommandHandler { CanExecuteAction = LoginValidate, ExecuteAction = LoginAction };
        }

        private bool LoginValidate(object obj)
        {
            if (string.IsNullOrEmpty(context.UserName) && (string.IsNullOrEmpty(context.Password)))
                return false;
            else
                return true;
        }

        private void LoginAction(object obj)
        {
          bool success=  context.Login();
            if (success == true)
            {
                var form = new MenuAdmin();
                var vm = new AdminViewModel(context);
                form.DataContext = vm;
                form.ShowDialog();
                WindowClose();
            }
            else
                Helpers.ShowErrorMessage("User dan Password tidak sesuai");
        }

        public Action WindowClose { get; set; }
        public Action WindowHide { get; internal set; }

        private void CancelCommanAction(object obj)
        {
            WindowClose();
        }
    }
}