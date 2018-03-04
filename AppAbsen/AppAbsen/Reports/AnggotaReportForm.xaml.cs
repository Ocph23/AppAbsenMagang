﻿using Microsoft.Reporting.WinForms;
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
    /// Interaction logic for AnggotaReportForm.xaml
    /// </summary>
    public partial class AnggotaReportForm : Window
    {
        public AnggotaReportForm()
        {
            InitializeComponent();
            this.Loaded += AnggotaReportForm_Loaded;
        }

        private void AnggotaReportForm_Loaded(object sender, RoutedEventArgs e)
        {
            var Data = Helpers.GetMainViewModel();
            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource DataSet1 = new ReportDataSource();
            DataSet1.Name = "DataSet1"; // Name of the DataSet we set in .rdlc
            DataSet1.Value = Data.Anggota.Source;
            // reportViewer.LocalReport.DataSources= list;
            reportViewer.LocalReport.ReportEmbeddedResource = "AppAbsen.Reports.AnggotaLayout.rdlc";
            reportViewer.LocalReport.DataSources.Add(DataSet1);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            ps.Margins.Top = 1;
            ps.Margins.Bottom = 1;
            ps.Margins.Left = 1;
            ps.Margins.Right = 1;
            reportViewer.SetPageSettings(ps);
            reportViewer.RefreshReport();
        }
    }
}
