using DoctorAppointmentDemo.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace DoctorAppointmentDemo.Domain.Entities
{
    public abstract class UserBase : Auditable, IValidatable
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string? Phone {  get; set; }       

        public string? Email {  get; set; }

        public bool Validate(out IList<string> validationMessages)
        {
            validationMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                validationMessages.Add("Name is required");
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                validationMessages.Add("Surname is required");
            }

            if (!string.IsNullOrEmpty(Phone) && !Regex.IsMatch(Phone, @"^\d{3}-\d{3}-\d{4}$"))
            {
                validationMessages.Add("Phone number should be in format XXX-XXX-XXXX");
                return false;
            }

            if (!string.IsNullOrEmpty(Email) && (!Email.Contains("@")))
            {
                validationMessages.Add("Invalid email format");
                return false;
            }

            return !validationMessages.Any();
        }
    }
}
