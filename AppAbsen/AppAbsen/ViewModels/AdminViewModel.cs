using App.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AppAbsen.ViewModels
{
   public class AdminViewModel
    {
        public CollectionView SourceView { get; set; }


        public AdminViewModel(user userLogin)
        {
            UserLogin = userLogin;
            var datas = Helpers.GetMainViewModel().Absen.GetTodaySource();
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(datas);
            UnitKerjaCommandView = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = UnitKerjaCommandViewAction };
            AnggotaViewCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = AnggotaViewCommandAction };
            LaporanViewCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = LaporanViewCommandAction };
        }

        private void LaporanViewCommandAction(object obj)
        {
            var viewmodel = new ViewModels.LaporanViewModel(UserLogin);
        }

        private void AnggotaViewCommandAction(object obj)
        {
            var viewmodel = new ViewModels.AnggotaViewModel(UserLogin);
        }

        private void UnitKerjaCommandViewAction(object obj)
        {
            var viewmodel = new ViewModels.UnitKerjaViewModel(UserLogin);
        }

        public user UserLogin { get; }
        public CommandHandler UnitKerjaCommandView { get; }
        public CommandHandler AnggotaViewCommand { get; }
        public CommandHandler LaporanViewCommand { get; }
    }
}
