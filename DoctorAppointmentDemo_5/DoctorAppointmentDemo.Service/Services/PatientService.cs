using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Domain.Exceptions;

namespace DoctorAppointmentDemo.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient Create(Patient patient)
        {
            if (!patient.Validate(out IList<string> validationMessages))
            {
                throw new ValidationException(validationMessages);
            }
            return _patientRepository.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient Update(int id, Patient patient)
        {
            if (!patient.Validate(out IList<string> validationMessages))
            {
                throw new ValidationException(validationMessages);
            }

            return _patientRepository.Update(id, patient);
        }
    }
}
