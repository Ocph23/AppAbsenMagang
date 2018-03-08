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
    /// Interaction logic for UnitKerjaReportForm.xaml
    /// </summary>
    public partial class UnitKerjaReportForm : Window
    {
        public UnitKerjaReportForm()
        {
            InitializeComponent();
            this.Loaded += UnitKerjaReportForm_Loaded;
        }

        private void UnitKerjaReportForm_Loaded(object sender, RoutedEventArgs e)
        {
            var Data = Helpers.GetMainViewModel().UnitKerja;
            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource DataSet1 = new ReportDataSource
            {
                Name = "DataSet1", // Name of the DataSet we set in .rdlc
                Value = Data.Source
            };
            // reportViewer.LocalReport.DataSources= list;
            reportViewer.LocalReport.ReportEmbeddedResource = "AppAbsen.Reports.UnitKerjaLayout.rdlc";
            reportViewer.LocalReport.DataSources.Add(DataSet1);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings
            {
                Landscape = false,
                PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170)
            };
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            
            reportViewer.SetPageSettings(ps);
            reportViewer.RefreshReport();
        }
    }
}
