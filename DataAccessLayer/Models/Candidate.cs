using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? GitHubURL { get; set; }
        public string? LinkedinURL { get; set; }
        public string Comment { get; set; }
        public DateTime? TimeInterval { get; set; }





    }
}
