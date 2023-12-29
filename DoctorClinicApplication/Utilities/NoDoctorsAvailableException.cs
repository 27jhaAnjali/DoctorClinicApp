namespace DoctorClinicApplication.Utilities
{
    public class NoDoctorsAvailableException:Exception
    {
        string message;
        public NoDoctorsAvailableException()
        {
            message = "Sorry.No Doctors available at this moment.";
        }
        public override string Message => message;
    }
}
