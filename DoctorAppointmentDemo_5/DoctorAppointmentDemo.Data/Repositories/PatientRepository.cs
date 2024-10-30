using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using System;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; }

        public PatientRepository(ISerializationService serializer, string path) : base(serializer)
        {
            Path = path;
        }

    }
}
