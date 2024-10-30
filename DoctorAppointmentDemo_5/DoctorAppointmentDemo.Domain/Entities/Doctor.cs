using DoctorAppointmentDemo.Domain.Enums;

namespace DoctorAppointmentDemo.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorTypes DoctorType { get; set; }
        public byte Experience { get; set; }
        public decimal Salary { get; set; }


        public bool Validate(out IList<string> validationMessages)
        {
            validationMessages = new List<string>();

            if (Experience < 0 || Experience > 50)
            {
                validationMessages.Add("Experience should be between 0 and 50 years");
            }

            if (Salary <= 0)
            {
                validationMessages.Add("Doctors need salary for their work!");
            }

            return !validationMessages.Any();
        }

        public override string ToString()
        {
            return $"\nDoctor ID: {Id}, Name: {Name} {Surname}, Type: {DoctorType}, " +
                   $"Experience: {Experience} years, Salary: {Salary:C}";
        }
    }
}
