using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorClinicApplication.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentNumber { get; set; }

        [Required(ErrorMessage = "Patient's details is mandatory")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor's details is mandatory")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Please choose a date and time")]
        public DateTime AppointmentDateTime { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; } //single object as 1 appoinment is only mapped to 1 patient

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; } //single object as 1 appoinment is only mapped to 1 doctor
    }
}
