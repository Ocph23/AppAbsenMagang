using AppAbsen.Library.DTO;
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
        private user Datauser;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.MenuUtamaViewModel(Datauser);
        }

        internal void ShowErrorMessage(string v)
        {
            MessageBox.Show(v, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
