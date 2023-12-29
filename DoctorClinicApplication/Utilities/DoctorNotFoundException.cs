namespace DoctorClinicApplication.Utilities
{
    public class DoctorNotFoundException:Exception
    {
        string message;
        public DoctorNotFoundException()
        {
            message = "No Doctor with this ID was found. Sorry";
        }
        public override string Message => message;
    }
}
