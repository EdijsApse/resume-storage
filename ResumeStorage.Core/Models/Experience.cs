using System.ComponentModel.DataAnnotations;

namespace ResumeStorage.Core.Models
{
    public class Experience : Entity
    {
        public int BasicProfileId { get; set; }

        [MaxLength(50)]
        public string Jobtitle { get; set; }

        [MaxLength(50)]
        public string Employer { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public BasicProfile BasicProfile { get; set; }
    }
}
