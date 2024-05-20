using System.ComponentModel.DataAnnotations;

namespace BussinessLayer.ViewModels
{
    public class CandidateVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string? GitHubURL { get; set; }
        public string? LinkedinURL { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime? TimeInterval { get; set; }

    }
}
