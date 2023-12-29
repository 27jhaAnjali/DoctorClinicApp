namespace DoctorClinicApplication.Utilities
{
    public class DoctorNotFreeException:Exception
    {
        string message;
        public DoctorNotFreeException()
        {
            message = "Sorry.Doctor not free at this slot";
        }
        public override string Message => message;
    }
}
