

namespace DoctorAppointmentDemo.Domain.Interfaces
{
    public interface IValidatable
    {
        bool Validate(out IList<string> validationMessages);
    }

}
