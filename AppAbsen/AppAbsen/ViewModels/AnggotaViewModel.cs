using AppAbsen.Library;
using AppAbsen.Library.DTO;
using AppAbsen.Library.Models;
using System;
using System.ComponentModel;
using System.Windows.Data;

namespace AppAbsen.ViewModels
{
    public class AnggotaViewModel:anggota,IDataErrorInfo
    {

        public user UserLogin { get; }
        public anggota Selected { get; set; }

        private AnggotaContext contextAnggota;
        private string error;

        public CollectionView SourceView { get; }
        public CommandHandler NewCommand { get; }
        public CommandHandler SaveCommand { get; }
        public CommandHandler EditCommand { get; }
        public CommandHandler DeleteCommand { get; }

        public string Error => error;


        public string this[string columnName]
        {
            get
            {

                if (columnName == "Alamat")
                    error = string.IsNullOrEmpty(Alamat) ? "Alamat Tidak Boleh Kosong" : null;


                return error;
            }
        }

        public AnggotaViewModel(user userLogin)
        {
            this.UserLogin = userLogin;
            contextAnggota = Helpers.GetMainViewModel().Anggota;
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(contextAnggota.Source);
            NewCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = NewCommandAction };
            SaveCommand = new CommandHandler { CanExecuteAction = SaveCommandValidation, ExecuteAction = SaveCommandAction };
            EditCommand = new CommandHandler { CanExecuteAction = EditCommandValidation, ExecuteAction = EditCommandAction };
            DeleteCommand = new CommandHandler { CanExecuteAction = DeleteCommandValidation, ExecuteAction = DeleteCommandAction };
        }

        private void EditCommandAction(object obj)
        {
            contextAnggota.Update(this);
        }

        private void DeleteCommandAction(object obj)
        {
            contextAnggota.Delete(this.Selected);
        }

        private bool DeleteCommandValidation(object obj)
        {
          return !string.IsNullOrEmpty(IdMahasiswa);
        }

        private bool EditCommandValidation(object obj)
        {
            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private void SaveCommandAction(object obj)
        {
            contextAnggota.Add(this.Selected);
        }

        private bool SaveCommandValidation(object obj)
        {
            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;
        }

        private void NewCommandAction(object obj)
        {
            this.Agama = Kepercayaan.Islam;
            this.Alamat = string.Empty;
            this.AsalSekolah = string.Empty;
            this.AsalUniversitas = string.Empty;
            this.IdMahasiswa = string.Empty;
            this.IdUnitKerja = string.Empty;
            this.JenisKelamin = Gender.Pria;
            this.Nama = string.Empty;
            this.TempatLahir = string.Empty;
            this.TglLahir = DateTime.Now;
        }
    }
}