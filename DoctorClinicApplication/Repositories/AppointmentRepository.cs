using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Utilities;

namespace DoctorClinicApplication.Repositories
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly ClinicContext _context;

        public AppointmentRepository(ClinicContext context)
        {
            _context=context;
        }
        public Appointment Add(Appointment entity)
        {
            _context.appointment.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Appointment Delete(int key)
        {
            var appointment = GetById(key);
            if (appointment == null)
                throw new AppointmentNotFoundException();
            _context.appointment.Remove(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public ICollection<Appointment> GetAll()
        {
            var appointments = _context.appointment;
            if (appointments.Count() == 0)
                throw new NoAppointmentAvailableException();
            return appointments.ToList();
        }

        public Appointment GetById(int key)
        {
            var appointmnet = _context.appointment.SingleOrDefault(app => app.AppointmentNumber == key);
            if (appointmnet != null)
                return appointmnet;
            throw new AppointmentNotFoundException();
        }

        public Appointment Update(Appointment entity)
        {
            var appointmnet = GetById(entity.AppointmentNumber);
            if (appointmnet == null)
                throw new AppointmentNotFoundException();
            appointmnet.PatientId = entity.PatientId;
            appointmnet.DoctorId = entity.DoctorId;
            appointmnet.AppointmentDateTime = entity.AppointmentDateTime;
            _context.SaveChanges();
            return entity;
        }
    }
}
