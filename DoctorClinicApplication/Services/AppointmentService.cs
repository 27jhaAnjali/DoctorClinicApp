using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Utilities;
using NuGet.Protocol.Core.Types;

namespace DoctorClinicApplication.Services
{
    public class AppointmentService : IAppointmentServices
    {
        private readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentService(IRepository<int,Appointment> repository)
        {
            _appointmentRepository= repository;
            
        }
        public Appointment Add(Appointment entity)
        {
            AppointmentCheckDTO appointmentDTO = new AppointmentCheckDTO
            {
                AppointmentDateTime = entity.AppointmentDateTime,
                 DoctorId = entity.DoctorId
            };
            if(CheckAvailability(appointmentDTO)==true)
            {
                var appointment = _appointmentRepository.Add(entity);
                return appointment;
            }
            throw new DoctorNotFreeException();
            
        }

        public bool CheckAvailability(AppointmentCheckDTO appointment)
        {
            try
            {
                var appointments = _appointmentRepository.GetAll();
                var checkAppointment = appointments
                                      .FirstOrDefault
                                      (
                                       a => a.DoctorId == appointment.DoctorId &&
                                       a.AppointmentDateTime == appointment.AppointmentDateTime
                                      );
                return checkAppointment == null;
            }
            catch(NoAppointmentAvailableException e)
            {
                return true;
            }
            catch(DoctorNotFreeException e)
            {
                return true;
            }
        }

        public IList<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll().ToList();
        }
    }
}
