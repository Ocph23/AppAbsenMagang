using AppAbsen.Library.DTO;
using AppAbsen.Library.Models;
using System;
using System.ComponentModel;
using System.Windows.Data;

namespace AppAbsen.ViewModels
{
    public class UnitKerjaViewModel:unitkerja, IDataErrorInfo
    {
        private string error;

        public user UserLogin { get; }

        private UnitKerjaContext contextUnitKerja;

        public CollectionView SourceView { get; }
        public CommandHandler NewCommand { get; }
        public CommandHandler SaveCommand { get; }
        public CommandHandler EditCommand { get; }
        public CommandHandler DeleteCommand { get; }

        private string search;

        public string Search
        {
            get { return search; }
            set { SetProperty(ref search, value); }
        }


        private unitkerja selectedItem;

        public unitkerja SelectedItem
        {
            get { return selectedItem; }
            set
            {
                this.IdUnitKerja = value.IdUnitKerja;
                this.NamaUnitKerja = value.NamaUnitKerja;
                SetProperty(ref selectedItem, value);
            }
        }


        public UnitKerjaViewModel(user userLogin)
        {
            UserLogin = userLogin;
            contextUnitKerja = Helpers.GetMainViewModel().UnitKerja;
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(contextUnitKerja.Source);
            NewCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = NewCommandAction };
            SaveCommand = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = SaveCommandAction };
            EditCommand = new CommandHandler { CanExecuteAction = EditCommandValidation, ExecuteAction = EditCommandAction };
            DeleteCommand = new CommandHandler { CanExecuteAction = DeleteCommandValidation, ExecuteAction = DeleteCommandAction };
        }

        private void DeleteCommandAction(object obj)
        {
            contextUnitKerja.Delete(this);
            SourceView.Refresh();
            Helpers.ShowSuccessMessage("Unit Kerja Berhasil di Hapus");
        }

        private bool DeleteCommandValidation(object obj)
        {
            if (string.IsNullOrEmpty(IdUnitKerja))
                return false;
            else
                return true;
        }

        private void EditCommandAction(object obj)
        {
            contextUnitKerja.Update(this);
            SourceView.Refresh();
            Helpers.ShowSuccessMessage("Unit Kerja Berhasil di rubah");
        }

        private bool EditCommandValidation(object obj)
        {
            if (string.IsNullOrEmpty(IdUnitKerja) || string.IsNullOrEmpty(NamaUnitKerja))
                return false;
            else
                return true;
        }

        private void SaveCommandAction(object obj)
        {
            if (contextUnitKerja.Add(this) == true)
            {
                SourceView.Refresh();
                Helpers.ShowSuccessMessage("Data Unit Kerja Tersimpan");
            }
            else
                Helpers.ShowErrorMessage("Data Sudah Ada");
        }

        

        private void NewCommandAction(object obj)
        {
            this.IdUnitKerja = string.Empty;
            this.NamaUnitKerja = string.Empty;
        }

        public string Error => error;

        public string this[string columnName] {
            get
            {
                if (columnName == "IdUnitKerja")
                    error = string.IsNullOrEmpty(IdUnitKerja) ? "Unit Kerja Tidak Boleh Null" : null;

                return error;
            }
        }
        
    }
}