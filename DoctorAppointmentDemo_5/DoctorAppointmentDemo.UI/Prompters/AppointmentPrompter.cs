namespace DoctorAppointmentDemo.UI.Prompters
{
    using DoctorAppointmentDemo.Domain.Entities;
    using DoctorAppointmentDemo.Service.Interfaces;
    using System;

    public static class AppointmentPrompter
    {
        public static Appointment PromptForAppointment(IDoctorService doctorService, IPatientService patientService)
        {
            return PromptForAppointment(null, doctorService, patientService);
        }

        public static Appointment PromptForAppointment(Appointment appointment, IDoctorService doctorService, IPatientService patientService)
        {
            appointment ??= new Appointment();

            Console.Write("Enter patient ID: ");
            int patientId = int.TryParse(Console.ReadLine(), out var patId) ? patId : 0;
            appointment.Patient = patientService.Get(patientId);
            if (appointment.Patient == null)
            {
                Console.WriteLine("Patient not found");
            }

            Console.Write("Enter doctor ID: ");
            int doctorId = int.TryParse(Console.ReadLine(), out var docId) ? docId : 0;
            appointment.Doctor = doctorService.Get(doctorId);
            if (appointment.Doctor == null)
            {
                Console.WriteLine("Doctor not found");
            }

            Console.Write("Enter Date and Time for appointment start (yyyy-MM-dd HH:mm): ");
            appointment.DateTimeFrom = DateTime.TryParse(Console.ReadLine(), out var dateFrom) ? dateFrom : DateTime.Now;

            Console.Write("Enter Date and Time for appointment end (yyyy-MM-dd HH:mm): ");
            appointment.DateTimeTo = DateTime.TryParse(Console.ReadLine(), out var dateTo) ? dateTo : appointment.DateTimeFrom.AddHours(1);

            Console.Write("Enter appointment description: ");
            appointment.Description = Console.ReadLine();

            return appointment;
        }
    }
}
