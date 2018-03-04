using System;

namespace AppAbsen.ViewModels
{
    internal class LaporanViewModel
    {
        public CommandHandler LaporanAnggora { get; set; }
        public LaporanViewModel(global::AppAbsen.Library.DTO.user userLogin)
        {
            LaporanAnggora = new CommandHandler { CanExecuteAction = x => true, ExecuteAction = ActionFormLaporanAnggota };
        }

        private void ActionFormLaporanAnggota(object obj)
        {
            var form = new Reports.AnggotaReportForm();
            form.ShowDialog();
        }
    }
}