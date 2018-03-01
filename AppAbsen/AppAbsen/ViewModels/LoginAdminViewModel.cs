using System;
using AppAbsen.Library.Models;
using AppAbsen.Views;
using AppAbsen.ViewModels;

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
                return true;
            else
                return true;
        }

        private void LoginAction(object obj)
        {
          bool success=  context.Login();
            if(success ==true)
            {
                var form = new MenuAdmin();
                var vm = new MenuUtamaViewModel(context);
                form.DataContext = vm;
                form.Show();

            }
        }

        public Action WindowClose { get; set; }
        public Action WindowHide { get; internal set; }

        private void CancelCommanAction(object obj)
        {
            WindowClose();
        }
    }
}