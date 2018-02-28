using AppAbsen.Library.Models;
using AppAbsen.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAbsen.ViewModels
{
   public class MainWindowViewModel
    {
        public CommandHandler LoginCommand { get; set; }
        public AbsenContext Absen { get; set; }
        public UserContext User { get; internal set; }
        public UnitKerjaContext UnitKerja { get; internal set; }
        public AnggotaContext Anggota { get; set; }

        public MainWindowViewModel()
        {
            LoginCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = LoginAction };
            Absen = new AbsenContext();
            User = new UserContext();
            UnitKerja = new UnitKerjaContext();
            Anggota = new AnggotaContext();
        }


        private void LoginAction(object obj)
        {
            var form = new Login();
            //var vm = new LoginAdminViewModel();
            //form.DataContext = vm;
            form.Show();

        }
    }
}
