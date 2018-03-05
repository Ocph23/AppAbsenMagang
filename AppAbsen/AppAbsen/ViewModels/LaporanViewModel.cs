using System;

namespace AppAbsen.ViewModels
{
    internal class LaporanViewModel
    {
        public CommandHandler LaporanAnggora { get; set; }
        public CommandHandler LaporanUnitKerja { get; set; }
        public CommandHandler LaporanAbsenTanggal { get; set; }
        public CommandHandler LaporanAbsenBulan { get; set; }
        public LaporanViewModel(global::AppAbsen.Library.DTO.user userLogin)
        {
            LaporanAnggora = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = ActionFormLaporanAnggota };
            LaporanUnitKerja = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = ActionFormLaporanUnitKerja };
            LaporanAbsenTanggal = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = ActionFormLaporanAbsenTanggal };
            LaporanAbsenBulan = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = ActionFormLaporanAbsenBulan };
        }

        private void ActionFormLaporanAbsenBulan(object obj)
        {
            var form = new Reports.AbsenBulanReportForm();
            form.ShowDialog();
        }

        private void ActionFormLaporanAbsenTanggal(object obj)
        {
            var form = new Reports.AbsenTanggalReportForm();
            form.ShowDialog();
        }

        private void ActionFormLaporanUnitKerja(object obj)
        {
            var form = new Reports.UnitKerjaReportForm();
            form.ShowDialog();
        }

        private void ActionFormLaporanAnggota(object obj)
        {
            var form = new Reports.AnggotaReportForm();
            form.ShowDialog();
        }
    }
}