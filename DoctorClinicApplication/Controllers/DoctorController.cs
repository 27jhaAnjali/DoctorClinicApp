using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using DoctorClinicApplication.Models.DTOs;
using DoctorClinicApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using System.Numerics;

namespace DoctorClinicApplication.Controllers
{
    public class DoctorController : Controller
    {
        List<SelectListItem> specialities=new List<SelectListItem>()
        {
            new SelectListItem{Value="Dentist",Text="Dentist"},
            new SelectListItem{Value="Neurology",Text="Neurology"},
            new SelectListItem{Value="Surgery",Text="Surgery"},
            new SelectListItem{Value="Dermatologist",Text="Dermatologist"},
            new SelectListItem{Value="Cardiologist",Text="Cardiologist"},
            new SelectListItem{Value="Pediatrician",Text="Pediatrician"}
        };
        private readonly IDoctorServices _doctorServices;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorServices doctorServices,ILogger<DoctorController> logger)
        {
            _doctorServices = doctorServices;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.ErrorMessage = "";
            var doctors = new List<Doctor>();
            try
            {
              //  string username = TempData.Peek("userName")?.ToString()??String.Empty;
                if(TempData.Peek("userName") == null)
                {
                    return RedirectToAction("UserLogin", "Login");
                }
                ViewBag.Username = TempData.Peek("userName").ToString();
                doctors = _doctorServices.GetAllDoctors().ToList();
             
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogError("Unable to get doctors' list" + DateTime.Now.ToString());
            }
            return View(doctors);
        
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.ErrorMessage = "";
            try
            {
                var doc = _doctorServices.GetAllDoctors().SingleOrDefault(x => x.Id == id);
                return View(doc);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogError("Unable to get doctor's details" + DateTime.Now.ToString());
            }
            return View();

        }
        [HttpGet] 
        public IActionResult Create() 
        {
            ViewBag.Specialities = specialities;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            ViewBag.ErrorMessage = "";
            ViewBag.Specialities = specialities;
            try
            {
                //entity.Pic = $"/images/{entity.Pic}";
                doctor.Pic = $"/images/{doctor.Pic}";
                var myDoctor = _doctorServices.Add(doctor);
                _logger.LogInformation("Doctor Records created.");
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogError("Unable to add doctor" + DateTime.Now.ToString());
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Specialities = specialities;
            var doc = _doctorServices.GetAllDoctors().SingleOrDefault(x => x.Id == id);
            var doctor = new DoctorSpecialDTO { Id = id, Speciality = doc.Speciality };
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Update(int id, DoctorSpecialDTO doctor)
        {
            ViewBag.ErrorMessage ="";
            ViewBag.Specialities=specialities;
        
            try
            {
               var result= _doctorServices.UpdateSpecialization(doctor);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogError("Unable to Update doctor Speciality" + DateTime.Now.ToString());
            }


            return View(doctor);
        }


    }
}
