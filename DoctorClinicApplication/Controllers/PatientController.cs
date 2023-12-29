using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorClinicApplication.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService,ILogger<PatientController> logger)
        {
            _patientService=patientService;
            _logger=logger;
        }
        public IActionResult Index()
        {
            ViewBag.ErrorMessage = "";
            var patients = new List<Patient>();
            try
            {
                patients = _patientService.GetAllPatients().ToList();
                
                return View(patients);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogError("Unable to get Patients' list" + DateTime.Now.ToString());
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            ViewBag.ErrorMessage = "";
           
            try
            {
                var myPatient = _patientService.Add(patient);
                _logger.LogInformation("Doctor Records created.");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogError("Unable to add patient" + DateTime.Now.ToString());
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var myPatient = _patientService.GetAllPatients().SingleOrDefault(x => x.Id == id);
            var patient= new PatientDTO{ Id = id, Phone = myPatient.Phone,Name= myPatient.Name };
            return View(patient);
        }

        [HttpPost]
        public IActionResult Update(int id, PatientDTO patient)
        {
            ViewBag.ErrorMessage = "";
            try
            {
                var result = _patientService.UpdatePhoneNum(patient);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogError("Unable to Update Patients Phone Number" + DateTime.Now.ToString());
            }


            return View(patient);
        }
    }
}
