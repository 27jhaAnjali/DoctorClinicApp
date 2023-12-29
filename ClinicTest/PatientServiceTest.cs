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
    // public Patient UpdatePhoneNum(PatientDTO patient);
    // public IList<Patient> GetAllPatients();
    public class PatientServiceTest
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

        public void PatientTestPhone()
        {
            //Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            IPatientService patientService = new PatientService(patientRepository);
            var patient = new Patient { Id = 1, Name = "Anjali", Age = 22, Email = "abc.xyz@gmail.com", Phone = "9798969594" };
            //Action
            Patient myPatient=patientService.Add(patient);
            Patient result = patientService.UpdatePhoneNum(new PatientDTO { Id = 1, Name = "Anjali", Phone = "9798969593" });

            //Assert
            Assert.AreEqual(result.Phone, myPatient.Phone);
        }
        [Test]
        public void PatientTestAdd()
        {
            //Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            IPatientService patientService = new PatientService(patientRepository);
            var patient = new Patient { Id = 11, Name = "Rishav", Age = 24, Email = "mbc.xyz@gmail.com", Phone = "9796669594" };
            //Action
            var myPatient = patientService.Add(patient);
            Patient result = new Patient { Id = 11, Name = "Rishav", Age = 24, Email = "mbc.xyz@gmail.com", Phone = "9796669594" };

            //Assert
            Assert.AreEqual(result.Id, myPatient.Id);
        }

        [Test]
        public void PatientTestGetAll()
        {
            //Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            IPatientService patientService = new PatientService(patientRepository);
            Patient patient1 = new Patient { Id = 14, Name = "Shivam", Age = 22, Email = "akc.xyz@gmail.com", Phone = "9794969594" };
            Patient patient2 = new Patient { Id = 12, Name = "Ajit", Age = 25, Email = "bdc.xyz@gmail.com", Phone = "9798969444" };
            Patient patient3 = new Patient { Id = 13, Name = "Nishant", Age = 26, Email = "alc.xyz@gmail.com", Phone = "9744969594" };
            //Action
            patientService.Add(patient1);
            patientService.Add(patient2);
            patientService.Add(patient3);
            IList<Patient> myPatients = new List<Patient>();    
                myPatients=patientService.GetAllPatients();

            //Assert
            Assert.AreEqual(3,myPatients.Count);
        }

    }
}
