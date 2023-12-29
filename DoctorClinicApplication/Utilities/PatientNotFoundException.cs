namespace DoctorClinicApplication.Utilities
{
    public class PatientNotFoundException:Exception
    {
        string message;
        public PatientNotFoundException()
        {
            message = "No PAtient with this ID was found. Sorry";
        }
        public override string Message => message;
    }
}
