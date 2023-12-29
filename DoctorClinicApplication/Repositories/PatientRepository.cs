using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApplication.Repositories
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly ClinicContext _context;

        public PatientRepository(ClinicContext context)
        {
            _context=   context;
        }
        public Patient Add(Patient entity)
        {
            _context.patient.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public Patient Delete(int key)
        {
            var patient = GetById(key);
            if (patient != null)
            {
                _context.patient.Remove(patient);
                _context.SaveChanges();
                return patient;
            }
            throw new PatientNotFoundException();
        }

        public ICollection<Patient> GetAll()
        {
            var patient = _context.patient;
            if (patient.Count() == 0)
                throw new NoPatientAvailableException();
            return patient.ToList();
        }

        public Patient GetById(int key)
        {
            var patient = _context.patient.FirstOrDefault(a => a.Id == key);
            if (patient != null)
                return patient;
            throw new PatientNotFoundException();
        }

        public Patient Update(Patient entity)
        {
            var patient = GetById(entity.Id);
            if (patient != null)
            {
                _context.Entry<Patient>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new PatientNotFoundException();
        }
    }
}
