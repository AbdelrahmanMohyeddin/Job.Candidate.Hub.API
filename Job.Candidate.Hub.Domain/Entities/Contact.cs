

using System.ComponentModel.DataAnnotations;

namespace Job.Candidate.Hub.Domain.Entities
{
    public class Contact
    {
        [Key]
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string? PhoneNumber { get; set; }
        
        public DateTime? TimeInterval { get; set; }

        public string? LinkedInProfileURL { get; set; }
        
        public string? GithubProfileURL { get; set; }
        
        public string Remarks { get; set; }
    }
}
