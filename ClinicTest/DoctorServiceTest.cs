using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Models;
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
    public class DoctorServiceTest
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
        public void AddDoctorTest()
        {
            //Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);
            IDoctorServices doctorServices = new DoctorServices(doctorRepository);
            var doctor = new Doctor
{ Id = 101, Name = "Rishav", Experience = 10, Speciality = "Neurology", Phone = "1234567898", Email = "rish.kum@xyz.com", Pic = "/images/doctor1.jpg" };
            //Action
            Doctor result = doctorServices.Add(doctor);
            Doctor myDoctor = new Doctor 
{ Id = 101, Name = "Rishav", Experience = 10, Speciality = "Neurology", Phone = "1234567898", Email = "rish.kum@xyz.com", Pic = "/images/doctor1.jpg" };
            //Assert
            Assert.AreEqual(myDoctor.Id, result.Id);
        }

        [Test]
        public void UpdateDoctorSpecializationTest()
        {
            //Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);
            IDoctorServices doctorServices = new DoctorServices(doctorRepository);
            var doctor = new Doctor
  { Id = 101,Name = "Rishav",Experience = 10,Speciality = "Neurology",Phone = "1234567898",Email = "rish.kum@xyz.com",Pic = "/images/doctor1.jpg" };

            //Action
            Doctor doc = doctorServices.Add(doctor);
            Doctor myDoctor =doctorServices.UpdateSpecialization( new DoctorSpecialDTO{Id = 101,Speciality = "Surgery",});

            //Assert
            Assert.AreEqual(myDoctor.Speciality, doc.Speciality);
        }

        [Test]
        public void GetAllDoctorsTest()
        {
            //Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);
            IDoctorServices doctorServices = new DoctorServices(doctorRepository);
            var doctor1 = new Doctor
 { Id = 1, Name = "Rishav", Experience = 10, Speciality = "Neurology", Phone = "1234567898", Email = "rish.kum@xyz.com", Pic = "/images/doctor1.jpg" };
            var doctor2 = new Doctor
 { Id = 2, Name = "Rishav", Experience = 10, Speciality = "Neurology", Phone = "1234567898", Email = "rish.kum@xyz.com", Pic = "/images/doctor1.jpg" };
            var doctor3 = new Doctor
 { Id = 3, Name = "Rishav", Experience = 10, Speciality = "Neurology", Phone = "1234567898", Email = "rish.kum@xyz.com", Pic = "/images/doctor1.jpg" };
            //Action
            doctorServices.Add(doctor1);
            doctorServices.Add(doctor2);
            doctorServices.Add(doctor3);
            IList<Doctor> myDoctors = new List<Doctor>();
            myDoctors = doctorServices.GetAllDoctors();

            //Assert
            Assert.AreEqual(3, myDoctors.Count);
        }

    }
}
