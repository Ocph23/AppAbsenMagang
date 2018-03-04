using AppAbsen.Library.DTO;
using AppAbsen.Library.Models;
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
            absenContex = Helpers.GetMainViewModel().Absen;
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(absenContex.Source);
            UnitKerjaCommandView = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = UnitKerjaCommandViewAction };
            AnggotaViewCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = AnggotaViewCommandAction };
            LaporanViewCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = LaporanViewCommandAction };
        }

        private void LaporanViewCommandAction(object obj)
        {
            var FormLaporan = new Views.Laporan();
            var viewmodel = new ViewModels.LaporanViewModel(this.UserLogin);
            FormLaporan.DataContext = viewmodel;
            FormLaporan.Show();
        }

        private void AnggotaViewCommandAction(object obj)
        {
            var FormAnggota = new Views.Anggota();
            var viewmodel = new ViewModels.AnggotaViewModel(this.UserLogin);
            FormAnggota.DataContext = viewmodel;
            FormAnggota.ShowDialog();
        }

        private void UnitKerjaCommandViewAction(object obj)
        {
            var formUnitKerja = new Views.UnitKerja();
            var viewmodel = new ViewModels.UnitKerjaViewModel(this.UserLogin);
            formUnitKerja.DataContext = viewmodel;
            formUnitKerja.ShowDialog();
        }

        public user UserLogin { get; }

        private AbsenContext absenContex;

        public CommandHandler UnitKerjaCommandView { get; }
        public CommandHandler AnggotaViewCommand { get; }
        public CommandHandler LaporanViewCommand { get; }
    }
}
