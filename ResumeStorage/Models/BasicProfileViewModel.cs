using System.ComponentModel;

namespace ResumeStorage.Models
{
    public class BasicProfileViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string? MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        public string? Street { get; set; }

        [DisplayName("Apartment Number")]
        public string? ApartmentNumber { get; set; }

        public string FullName => $"{FirstName} {(MiddleName != null ? $"{MiddleName} " : "")} {LastName}";

        public string Location => $"{Country} {City} {(Street != null ? $"{Street} " : "")}{(ApartmentNumber != null ? $"{ApartmentNumber} " : "")}{PostalCode}";

        public string DisplayDate => DateOfBirth.ToString("dd-MM-yyyy");
    }
}
