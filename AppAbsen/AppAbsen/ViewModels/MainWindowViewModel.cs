using App.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAbsen.ViewModels
{
   public class MainWindowViewModel
    {
        public AbsenContext Absen { get; set; }
        public UserContext User { get; internal set; }

        public MainWindowViewModel()
        {
            Absen = new AbsenContext();
            User = new UserContext();
        }
    }
}
