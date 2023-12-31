﻿using System.ComponentModel;

namespace ResumeStorage.Models
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }

        public string Jobtitle { get; set; }

        public string Employer { get; set; }

        [DisplayName("Date From")]
        public DateTime DateFrom { get; set; }

        [DisplayName("Date To")]
        public DateTime? DateTo { get; set; }

        public string? Description { get; set; }

        public int BasicProfileId { get; set; }
    }
}
