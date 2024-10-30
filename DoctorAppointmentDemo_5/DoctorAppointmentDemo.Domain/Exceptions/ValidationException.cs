using System;
using System.Collections.Generic;


namespace DoctorAppointmentDemo.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IList<string> ValidationErrors { get; }

        public ValidationException(string message) : base(message)
        {
            ValidationErrors = new List<string> { message };
        }

        public ValidationException(IList<string> validationErrors) : base(string.Join("; ", validationErrors))
        {
            ValidationErrors = validationErrors;
        }
    }
}
