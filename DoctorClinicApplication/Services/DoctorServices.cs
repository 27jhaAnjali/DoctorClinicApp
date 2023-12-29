using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;

namespace DoctorClinicApplication.Services
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IRepository<int, Doctor> _repository;

        public DoctorServices(IRepository<int,Doctor> repository)
        {
            _repository=repository;
        }
        public Doctor Add(Doctor entity)
        {
            //entity.Pic= $"/images/{entity.Pic}";
            var doctor = _repository.Add(entity);
            return doctor;
        }

        public IList<Doctor> GetAllDoctors()
        {
            return _repository.GetAll().ToList();
        }

        public Doctor UpdateSpecialization(DoctorSpecialDTO doctor)
        {
            var myDoctor = _repository.GetById(doctor.Id);
            myDoctor.Speciality = doctor.Speciality;
            _repository.Update(myDoctor);
            return myDoctor;    
        }
    }
}
