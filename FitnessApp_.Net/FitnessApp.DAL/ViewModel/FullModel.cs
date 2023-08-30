using FitnessApp.DAL.Models;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.ViewModel
{
    public class FullModel
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public Trening Trening { get; set; }
        public string Times { get; set; }
        public User User { get; set; }
        public Diet Diet { get; set; }
        public int Month { get; set; }

    }
}
