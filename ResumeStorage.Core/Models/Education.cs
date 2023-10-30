using System.ComponentModel.DataAnnotations;

namespace ResumeStorage.Core.Models
{
    public class Education : Entity
    {
        public int BasicProfileId { get; set; }

        [MaxLength(50)]
        public string NameOfSchool { get; set; }

        [MaxLength(50)]
        public string FieldOfStudy { get; set; }

        [MaxLength(50)]
        public string Degree { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public BasicProfile BasicProfile { get; set; }
    }
}
