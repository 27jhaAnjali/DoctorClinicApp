using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DoctorClinicApplication.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context) //taking the injection
        {
            _context=context;
        }
        public Doctor Add(Doctor entity)
        {

            _context.doctor.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Doctor Delete(int key)
        {
            var doctor = GetById(key);
            if (doctor != null)
            {
                _context.doctor.Remove(doctor);
                _context.SaveChanges();
                return doctor;
            }
            throw new DoctorNotFoundException();
        }

        public ICollection<Doctor> GetAll()
        {
            var doctor= _context.doctor;
            if (doctor.Count() == 0)
                throw new NoDoctorsAvailableException();
            return doctor.ToList();
        }

        public Doctor GetById(int key)
        {
            var doctor = _context.doctor.FirstOrDefault(a => a.Id == key);
            if (doctor != null)
                return doctor;
            throw new DoctorNotFoundException();
        }

        public Doctor Update(Doctor entity)
        {
            var doctor= GetById(entity.Id);
            if (doctor != null)
            {
                _context.Entry<Doctor>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new DoctorNotFoundException();    
        }
    }
}
