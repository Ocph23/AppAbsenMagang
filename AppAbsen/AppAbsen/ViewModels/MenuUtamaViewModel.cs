using AppAbsen.Library;
using AppAbsen.Library.DTO;
using AppAbsen.Library.Models;
using AppAbsen.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AppAbsen.ViewModels
{
   public class MenuUtamaViewModel: BaseNotify
    {
        public AbsenContext Absen { get; set; }
        public UserContext User { get; internal set; }
        public UnitKerjaContext UnitKerja { get; internal set; }
        public AnggotaContext Anggota { get; set; }
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


        public CollectionView SourceView { get; set; }

        public CommandHandler AdminLoginCommand { get; }
        public CommandHandler AbsenCommand { get; }

        public MenuUtamaViewModel()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("id-ID");
            Today = DateTime.Now;
            Absen = new AbsenContext();
            User = new UserContext();
            UnitKerja = new UnitKerjaContext();
            Anggota = new AnggotaContext();
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(Absen.Source);
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
                
                var dataAbsen = new absen
                {
                    IdMahasiswa = idAnggota, Tanggal = today
                };
                var isSaved = Absen.Add(dataAbsen);
                SourceView.Refresh();
                Helpers.ShowSuccessMessage("Anda Sudah Absen");
            }
            catch (Exception ex)
            {

                Helpers.ShowErrorMessage(ex.Message);
            }
          
        }

        private void AdminLoginAction(object obj)
        {
            var form = new Login();
            form.Show();
        }
    }
}
