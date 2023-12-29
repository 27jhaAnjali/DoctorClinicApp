namespace DoctorClinicApplication.Utilities
{
    public class NoAppointmentAvailableException:Exception
    {
        string message;
        public NoAppointmentAvailableException()
        {
            message = "No bookings available at this time.Please choose another time slot.";
        }
        public override string Message => message;
    }
}
