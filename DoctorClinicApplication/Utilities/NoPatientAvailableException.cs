namespace DoctorClinicApplication.Utilities
{
    public class NoPatientAvailableException:Exception
    {
        string message;
        public NoPatientAvailableException()
        {
            message = "No Patients bookings right now";
        }
        public override string Message => message;
    }
}
