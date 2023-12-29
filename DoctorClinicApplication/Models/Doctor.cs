using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DoctorClinicApplication.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Doctor name is mandatory")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Doctor Experience is mandatory")]
        [Range(0,22,ErrorMessage ="Invalid number of Experience")]
        public int Experience { get; set; }
        public string? Speciality { get; set; }

        [Required(ErrorMessage = "Doctor Phone number is mandatory")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})",
                           ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        public string? Pic { get; set; }

        public ICollection<Appointment> Appointments { get; set; } //collection of appointments as 1 doctor can be mapped to multiple appointments
                                                                          //one-many relationship
    }
}
