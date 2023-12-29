using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;

namespace DoctorClinicApplication.Interfaces
{
    public interface IPatientService: IAddingEntity<Patient>
    {
        public Patient UpdatePhoneNum(PatientDTO patient);
        public IList<Patient> GetAllPatients();
    }
}
