using System.ComponentModel;

namespace ResumeStorage.Models
{
    public class EducationViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name Of School")]
        public string NameOfSchool { get; set; }

        [DisplayName("Field Of Study")]
        public string FieldOfStudy { get; set; }

        [DisplayName("Date From")]
        public DateTime DateFrom { get; set; }

        [DisplayName("Date To")]
        public DateTime? DateTo { get; set; }

        public string Degree { get; set; }

        public int BasicProfileId { get; set; }
    }
}
