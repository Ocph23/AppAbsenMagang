using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAbsen.Library.Models;
using AppAbsen.ViewModels;

namespace AppAbsen
{
    public class Helpers
    {
        internal static MainWindowViewModel GetMainViewModel()
        {
            if (App.Current == null)
                return new MainWindowViewModel();
            return App.Current.Windows[0].DataContext as MainWindowViewModel;
        }
    }
}
