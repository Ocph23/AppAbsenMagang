using AppAbsen.Library.DTO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppAbsen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.VM = new ViewModels.MenuUtamaViewModel();
            this.DataContext = VM;
        }

        public MenuUtamaViewModel VM { get; private set; }

        internal void ShowErrorMessage(string v)
        {
            MessageBox.Show(v, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        internal void ShowSuccessMessage(string v)
        {
            MessageBox.Show(v, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Text = sender as TextBox;
            this.VM.IdAnggota = Text.Text;

        }
    }
}
