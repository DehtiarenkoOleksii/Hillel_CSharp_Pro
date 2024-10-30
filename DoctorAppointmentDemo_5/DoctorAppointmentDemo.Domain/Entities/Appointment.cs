using DoctorAppointmentDemo.Domain.Interfaces;

namespace DoctorAppointmentDemo.Domain.Entities
{
    public class Appointment : Auditable, IValidatable
    {
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string? Description { get; set; }

        public bool Validate(out IList<string> validationMessages)
        {
            validationMessages = new List<string>();

            if (DateTimeTo < DateTimeFrom)
            {
                validationMessages.Add("DateTimeTo must be after DateTimeFrom");
            }

            return !validationMessages.Any();
        }

        public override string ToString()
        {
            return $"\nAppointment ID: {Id}, Doctor: {Doctor?.Name} {Doctor?.Surname}, " +
                   $"Patient: {Patient?.Name} {Patient?.Surname}, From: {DateTimeFrom}, To: {DateTimeTo}, " +
                   $"Description: {Description}";
        }
    }
}
