using ResumeStorage.Core.Models;

namespace ResumeStorage.Models
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }

        public string Jobtitle { get; set; }

        public string Employer { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string? Description { get; set; }

        public int BasicProfileId { get; set; }
    }
}
