using DoctorClinicApplication.Interfaces;
using DoctorClinicApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorClinicApplication.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentServices _appointmentService;
        private readonly IDoctorServices _doctorService;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IAppointmentServices appointmentService, 
            IDoctorServices doctorServices,
            ILogger<AppointmentController> logger)
        {
            _appointmentService=appointmentService;
            _doctorService=doctorServices;  
            _logger=logger; 
        }
        public IActionResult Index()
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                appointments = _appointmentService.GetAll().ToList();
                return View(appointments);
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                //logging for programmer
                _logger.LogInformation("There were no appointments.");
            }
            return View(appointments);
        }
        [HttpGet]
        [Route("BookAppointments/{id}")]
        public IActionResult Create(int id)
        {
            ViewBag.doctors = GetDoctors();
            Appointment appointment= new Appointment();
            appointment.AppointmentDateTime = DateTime.Now;
            appointment.DoctorId= id;
            return View(appointment);
        }

        [HttpPost]

        [Route("{controller}/BookAppointments/{id}")]

        public IActionResult Create(int id,Appointment appointment)
        {
            ViewBag.doctors = GetDoctors();
            if (ModelState.IsValid)
            {
                try
                {
                    var myAppointment = _appointmentService.Add(appointment);
                    ViewBag.Registered = myAppointment.AppointmentNumber;
                    return View(myAppointment);


                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    //logging for programmer
                    _logger.LogInformation("There were no appointments.");
                }
            }
            return View(appointment);
        }

        private List<SelectListItem> GetDoctors()
        {
            List<SelectListItem> doctors = new List<SelectListItem>();
            foreach (var item in _doctorService.GetAllDoctors())
            {
                var li = new SelectListItem
                {
                    Text = item.Name+"-"+item.Speciality,
                    Value = item.Id.ToString()
                 };
            doctors.Add(li);
            }
            return doctors;
        }
        }
    }

