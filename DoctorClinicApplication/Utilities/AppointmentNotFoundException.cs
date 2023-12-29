namespace DoctorClinicApplication.Utilities
{
    public class AppointmentNotFoundException:Exception
    {
        string message;
        public AppointmentNotFoundException()
        {
            message = "No Appointment with this ID was found. Sorry";
        }
        public override string Message => message;
    }
}
