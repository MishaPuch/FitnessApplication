using FitnessApp.DAL.Models;
using FitnessApp.Models;

namespace FitnessApp.DAL.ViewModel
{
    public class FullModel
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public ICollection<Trening> Trening { get; set; }
        public User User { get; set; }
        public ICollection<Diet> Diet { get; set; }

    }
}
