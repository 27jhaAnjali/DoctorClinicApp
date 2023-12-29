using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;
using System.Numerics;

namespace DoctorClinicApplication.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<int, Patient> _repository;

        public PatientService(IRepository<int,Patient> repository)
        {
            _repository=repository;
        }
        public Patient Add(Patient entity)
        {
            var patient = _repository.Add(entity);
            return patient;
        }

        public IList<Patient> GetAllPatients()
        {
            return _repository.GetAll().ToList();
        }

        public Patient UpdatePhoneNum(PatientDTO patient)
        {
            var myPatient = _repository.GetById(patient.Id);
            myPatient.Phone = patient.Phone;
            _repository.Update(myPatient);
            return myPatient;
        }
    }
}
