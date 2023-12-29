using System.ComponentModel.DataAnnotations;

namespace DoctorClinicApplication.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="User ID is mandatory")]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Password is mandatory")]
        public string Password { get; set; }
    }
}
