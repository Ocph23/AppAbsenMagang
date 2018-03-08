using AppAbsen.ViewModels;
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

namespace AppAbsen.Views
{
    /// <summary>
    /// Interaction logic for Anggota.xaml
    /// </summary>
    public partial class Anggota : Window
    {        
        public Anggota()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text != null && !string.IsNullOrEmpty(text.Text))
            {
                var ViewModel = (AnggotaViewModel)this.DataContext;
                ViewModel.Search = text.Text;
            }
        }
    }
}
