namespace ResumeStorage.Models
{
    public class ResumeViewModel : BasicProfileViewModel
    {
        public List<ExperienceViewModel> ExperiencesList { get; set; }

        public List<EducationViewModel> EducationsList { get; set; }
    }
}
