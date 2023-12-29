using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;

namespace DoctorClinicApplication.Interfaces
{
    public interface IAppointmentServices:IAddingEntity<Appointment>
    {
        public bool CheckAvailability(AppointmentCheckDTO appointment);
        public IList<Appointment> GetAll();
    }
}
