using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Models
{
    public class VereficationUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int VereficationCode { get; set; }
    }
}
