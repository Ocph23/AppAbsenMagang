using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAbsen
{
    public static class MyExtentions
    {

        public static bool IsEqualToday(this DateTime date)
        {
            DateTime Tanggal = DateTime.Now;
            if (date.Year == Tanggal.Year && date.Month == Tanggal.Month && date.Day == Tanggal.Day)
                return true;
            else
                return false;
        }
    }



}
