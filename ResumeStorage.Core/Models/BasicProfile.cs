using System.ComponentModel.DataAnnotations;

namespace ResumeStorage.Core.Models
{
    public class BasicProfile : Entity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(25)]
        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(25)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string? Street { get; set; }

        [MaxLength(25)]
        public string? ApartmentNumber { get; set; }

        public List<Experience> ExperiencesList { get; set; }

        public List<Education> EducationsList { get; set; }
    }
}
