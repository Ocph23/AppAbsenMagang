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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LoginAdminViewModel ViewModel;
        public Login()
        {
            InitializeComponent();
            ViewModel = new LoginAdminViewModel() { WindowClose = Close, WindowHide = Hide };
            this.DataContext = ViewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.context.Password=((PasswordBox)sender).Password;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Text = sender as TextBox;
            this.ViewModel.context.UserName = Text.Text;
        }
    }
}
