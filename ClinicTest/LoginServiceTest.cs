using DoctorClinicApplication.Contexts;
using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Repositories;
using DoctorClinicApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicTest
{
    public class Tests
    {
        ClinicContext context;
        //gets executed for every test
        [SetUp]
        public void Setup()
        {
            var DbContextOptions = new DbContextOptionsBuilder<ClinicContext>().UseInMemoryDatabase(databaseName : "dbDummyClinic").Options;
            context = new ClinicContext(DbContextOptions);
        }

        [Test]
        public void LoginTest()
        {
            //Arrange
            IRepository<int,Patient> patientRepository=new PatientRepository(context);    
            var patient= new Patient { Id= 1,Name="Anjali",Age=22,Email="abc.xyz@gmail.com",Phone="9798969594" };
            patientRepository.Add(patient);
            ILoginService loginService = new LoginService(patientRepository);

            //Action
            var result = loginService.Login(new LoginDTO { Id = 1, Password = "9798969594" });

            //Assert
            Assert.That(result.Id, Is.EqualTo(1));
        }
    }
}