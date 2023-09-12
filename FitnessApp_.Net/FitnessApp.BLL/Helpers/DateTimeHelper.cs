using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Halpers
{
    static class DateTimeHelper
    {
        public static int GetQuantityDaysInMonth(DateTime dayOfLastPayment) 
        {
            int daysInMonth = DateTime.DaysInMonth(dayOfLastPayment.Year, dayOfLastPayment.Month);

            return daysInMonth;
        }

    }
}   
