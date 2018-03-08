using AppAbsen.Library;
using AppAbsen.Library.DTO;
using AppAbsen.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace AppAbsen.ViewModels
{
    public class AnggotaViewModel:anggota,IDataErrorInfo
    {

        public user UserLogin { get; }
        public AnggotaContext Angota { get; set; }
        public anggota Selected { get; set; }
        public List<unitkerja> DataUnit { get; set; }

        private AnggotaContext contextAnggota;
        public UnitKerjaContext contextUnitKerja;
        private string error;
        private string _serach;
        private DateTime today;

        public CollectionView SourceView { get; }
        public CommandHandler NewCommand { get; }
        public CommandHandler SaveCommand { get; }
        public CommandHandler EditCommand { get; }
        public CommandHandler DeleteCommand { get; }
        public CommandHandler IjinCommand { get; }
        public CommandHandler SakitCommand { get; }
        public List<Kepercayaan> DataKepercayaan { get; set; }
        public List<Gender> DataGender { get; set; }
        public List<unitkerja> DataUnitKerja  { get; set; }
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

        public string Search
        {
            get
            {
                return _serach;
            }

            set
            {
                SetProperty(ref _serach, value);
                SourceView.Refresh();
            }
        }

        public DateTime Today
        {
            get { return today; }
            set { SetProperty(ref today, value); }
        }



        public AnggotaViewModel(user userLogin)
        {
            this.TglLahir = DateTime.Now;
            DataKepercayaan = new List<Kepercayaan>
            {
                Kepercayaan.Islam,
                Kepercayaan.Protestan,
                Kepercayaan.Katolik,
                Kepercayaan.Hindu,
                Kepercayaan.Budha,
                Kepercayaan.KonghuChu
            };
            DataGender = new List<Gender> { Gender.Pria, Gender.Wanita };
            Today = DateTime.Now;
            this.UserLogin = userLogin;
            contextAnggota = Helpers.GetMainViewModel().Anggota;
            contextUnitKerja = Helpers.GetMainViewModel().UnitKerja;
            DataUnitKerja = contextUnitKerja.Source;
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(contextAnggota.Source);
            SourceView.Filter = FilterfromSearch;
            NewCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = NewCommandAction };
            SaveCommand = new CommandHandler { CanExecuteAction = SaveCommandValidation, ExecuteAction = SaveCommandAction };
            EditCommand = new CommandHandler { CanExecuteAction = EditCommandValidation, ExecuteAction = EditCommandAction };
            DeleteCommand = new CommandHandler { CanExecuteAction = DeleteCommandValidation, ExecuteAction = DeleteCommandAction };
            IjinCommand = new CommandHandler { CanExecuteAction = IjinCommandValidate, ExecuteAction = IjinCommandAction };
            SakitCommand = new CommandHandler { CanExecuteAction = SakitCommandValidate, ExecuteAction = SakitCommandAction };
        }

        private void SakitCommandAction(object obj)
        {
            throw new NotImplementedException();
        }

        private bool SakitCommandValidate(object obj)
        {
            throw new NotImplementedException();
        }

        private bool IjinCommandValidate(object obj)
        {
            throw new NotImplementedException();
        }

        private void IjinCommandAction(object obj)
        {
            throw new NotImplementedException();
        }

        private bool FilterfromSearch(object obj)
        {
            var data = (anggota)obj;
            if (data != null && Search != null)
            {
                if (data.Nama.Contains(Search) || data.IdMahasiswa.Contains(Search))
                {
                    return true;
                }
            }
            else
                return true;
            return false;
        }

        private void EditCommandAction(object obj)
        {
            contextAnggota.Update(this);
            SourceView.Refresh();
            Helpers.ShowSuccessMessage("Berhasil Update");
        }

        private void DeleteCommandAction(object obj)
        {
            contextAnggota.Delete(this.Selected);
            SourceView.Refresh();
            Helpers.ShowSuccessMessage("Berhasil Hapus Data");
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
                return true;
        }

        private void SaveCommandAction(object obj)
        {
            contextAnggota.Add(this.Selected);
            SourceView.Refresh();
            Helpers.ShowSuccessMessage("Berhasil Tambah");
        }

        private bool SaveCommandValidation(object obj)
        {
            if (string.IsNullOrEmpty(error))
                return true;
            else
                return true;
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