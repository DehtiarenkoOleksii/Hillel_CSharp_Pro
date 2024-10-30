using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Domain.Exceptions;

namespace DoctorAppointmentDemo.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor Create(Doctor doctor)
        {
            if (!doctor.Validate(out IList<string> validationMessages))
            {
                throw new ValidationException(validationMessages);
            }

            return _doctorRepository.Create(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor Update(int id, Doctor doctor)
        {
            if (!doctor.Validate(out IList<string> validationMessages))
            {
                throw new ValidationException(validationMessages);
            }

            return _doctorRepository.Update(id, doctor);
        }
    }
}
