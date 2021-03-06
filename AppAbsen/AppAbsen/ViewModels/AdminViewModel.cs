﻿using AppAbsen.Library;
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
   public class AdminViewModel:BaseNotify
    {
        public CollectionView SourceView { get; set; }
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

        private bool FilterNama(object obj)
        {
            var data = (absen)obj;
            if (data != null && Search != null)
            {
                if (data.Anggota.Nama.Contains(Search) || data.Anggota.IdMahasiswa.Contains(Search))
                {
                    return true;
                }
            }
            else
                return true;
            return false;
        }

        public AdminViewModel(user userLogin)
        {
            UserLogin = userLogin;
            absenContex = Helpers.GetMainViewModel().Absen;
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(absenContex.Source);
            SourceView.Filter = FilterNama;
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
        private string _serach;

        public CommandHandler UnitKerjaCommandView { get; }
        public CommandHandler AnggotaViewCommand { get; }
        public CommandHandler LaporanViewCommand { get; }
    }
}
