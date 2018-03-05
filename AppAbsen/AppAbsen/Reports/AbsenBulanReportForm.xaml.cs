using App.Library.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppAbsen.Reports
{
    /// <summary>
    /// Interaction logic for AbsenBulanReportForm.xaml
    /// </summary>
    public partial class AbsenBulanReportForm : Window
    {
        public DateTime Datapass { get; set; }
        public AbsenBulanReportForm()
        {
            InitializeComponent();
        }
        public void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Datapass = ((DatePicker)sender).SelectedDate.Value;
            var Data = new RekapAbsenContext();
            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource DataSet1 = new ReportDataSource
            {
                Name = "DataSet1", // Name of the DataSet we set in .rdlc
                Value = Data.GetSource(Datapass)
            };
            // reportViewer.LocalReport.DataSources= list;
            reportViewer.LocalReport.ReportEmbeddedResource = "AppAbsen.Reports.AbsenBulanLayout.rdlc";
            reportViewer.LocalReport.DataSources.Add(DataSet1);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = false;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            reportViewer.SetPageSettings(ps);
            reportViewer.RefreshReport();

        }

       
    }
}
