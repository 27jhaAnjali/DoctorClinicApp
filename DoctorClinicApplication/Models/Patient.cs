using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DoctorClinicApplication.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Patient's name is mandatory")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Patient's Age is mandatory")]
        [Range(0, 100, ErrorMessage = "Invalid Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Doctor Phone number is mandatory")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})",ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        public ICollection<Appointment> Appointments { get; set; } //collection of appointments as 1 patient can be mapped to multiple appointments
                                                                  //one-many relationship

    }
}
