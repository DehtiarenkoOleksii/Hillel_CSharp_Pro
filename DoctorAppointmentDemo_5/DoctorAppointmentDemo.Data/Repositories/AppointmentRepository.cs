using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using System;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get;}

        public AppointmentRepository(ISerializationService serializer, string path) : base(serializer)
        {
            Path = path;
        }
 
    }
}
