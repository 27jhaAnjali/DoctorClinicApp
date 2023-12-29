using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Repositories;
using DoctorClinicApplication.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTest
{
    public class AppointmentServiceTest
    {
        ClinicContext context;
        //gets executed for every test
        [SetUp]
        public void Setup()
        {
            var DbContextOptions = new DbContextOptionsBuilder<ClinicContext>().UseInMemoryDatabase(databaseName: "dbDummyClinic").Options;
            context = new ClinicContext(DbContextOptions);
        }

        [Test]
        public void GetAllAppointmentsTest()
        {
            //Arrange
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository(context);
            IAppointmentServices appointmentService = new AppointmentService(appointmentRepository);
            DateTime Dt = DateTime.Now;
            Appointment myAppointment = new Appointment { AppointmentNumber = 1, PatientId = 3, DoctorId = 101, AppointmentDateTime = Dt };

            //Action
            appointmentService.Add(myAppointment);
            var list = appointmentService.GetAll();

            //Assert
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void PatientTestAdd()
        {
            //Arrange
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository(context);
            IAppointmentServices appointmentService = new AppointmentService(appointmentRepository);
            DateTime Dt = new DateTime(2023, 12, 30);
            Appointment myAppointment = new Appointment { AppointmentNumber = 3, PatientId = 1, DoctorId = 104, AppointmentDateTime = Dt };

            //Action
            var result=appointmentService.Add(myAppointment);

            //Assert
            Assert.AreEqual(3,result.AppointmentNumber);
        }


        [Test]
        public void CheckAvailabilityTest()
        {
            //Arrange
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository(context);
            IAppointmentServices appointmentService = new AppointmentService(appointmentRepository);
            DateTime Dt = new DateTime(2023,11,30);
            Appointment myAppointment = new Appointment { AppointmentNumber = 2, PatientId = 2, DoctorId = 103, AppointmentDateTime = Dt };
            appointmentService.Add(myAppointment);

            //Action
            AppointmentCheckDTO appointment = new AppointmentCheckDTO { DoctorId = 103, AppointmentDateTime = Dt };
            bool result = appointmentService.CheckAvailability(appointment);

            //Assert
            Assert.AreEqual(false, result);
        }

    }
}
