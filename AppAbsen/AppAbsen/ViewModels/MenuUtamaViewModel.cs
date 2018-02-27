using AppAbsen.Library;
using AppAbsen.Library.DTO;
using AppAbsen.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AppAbsen.ViewModels
{
   public class MenuUtamaViewModel: BaseNotify
    {
        private string idAnggota;

        public string IdAnggota
        {
            get { return idAnggota; }
            set { SetProperty(ref idAnggota, value); }
        }

        private DateTime today;

        public DateTime Today
        {
            get { return today; }
            set { SetProperty(ref today, value); }
        }

        public ObservableCollection<absen> Source { get; set; }
        public user UserLogin { get; }

        private AbsenContext absencontext;

        public CollectionView SourceView { get; set; }

        public CommandHandler AdminLoginCommand { get; }
        public CommandHandler AbsenCommand { get; }

        public MenuUtamaViewModel(user user)
        {
            UserLogin = user;
            absencontext = new AbsenContext();
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(absencontext.Source);
            AdminLoginCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = AdminLoginAction };
            AbsenCommand = new CommandHandler { CanExecuteAction = AbsenCommandValidate, ExecuteAction = AbsenCommandAction };
            SourceView.Filter = TodayFilter;
        }

        private bool TodayFilter(object obj)
        {
            var data = (absen)obj;
            if(data!=null)
            {
                if (today.IsEqualToday())
                {
                    return true;
                }
            }
            return false;
        }

        private bool AbsenCommandValidate(object obj)
        {
            if (string.IsNullOrEmpty(IdAnggota))
                return false;
            else
                return true;
        }

        private void AbsenCommandAction(object obj)
        {
            try
            {
                var today = DateTime.Now;
                var dataAbsen = new absen
                {
                    IdMahasiswa = idAnggota, Tanggal = today
                };
                var isSaved = absencontext.Add(dataAbsen);
                SourceView.Refresh();
            }
            catch (Exception ex)
            {

                Helpers.ShowErrorMessage(ex.Message);
            }
          
        }

        private void AdminLoginAction(object obj)
        {
            var viewmodel = new ViewModels.LoginAdminViewModel();
        }
    }
}
