using DoctorAppointmentDemo.Domain.Enums;

namespace DoctorAppointmentDemo.Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnessTypes IllnessType { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Address { get; set; }      
        public override string ToString()
        {
            return $"\nPatient ID: {Id}, Name: {Name} {Surname}, Illness: {IllnessType}, " +
                   $"Phone: {Phone}, Email: {Email}, Address: {Address}, Additional Info: {AdditionalInfo}";
        }
    }
}
