namespace DoctorAppointmentDemo.UI.Prompters
{
    using DoctorAppointmentDemo.Domain.Entities;
    using DoctorAppointmentDemo.Domain.Enums;
    using System;

    public static class DoctorPrompter
    {
        public static Doctor PromptForDoctor()
        {
            return PromptForDoctor(null);
        }

        public static Doctor PromptForDoctor(Doctor doctor)
        {
            doctor ??= new Doctor();

            Console.Write("\nEnter doctor's name: ");
            doctor.Name = Console.ReadLine();

            Console.Write("Enter doctor's surname: ");
            doctor.Surname = Console.ReadLine();

            Console.WriteLine("Choice doctor's type:");
            foreach (var type in Enum.GetValues(typeof(DoctorTypes)))
            {
                Console.WriteLine($"{(int)type} - {type}");
            }

            int doctorTypeChoice;
            do
            {
                Console.Write("Enter number, which according to doctor type: ");
            } while (!int.TryParse(Console.ReadLine(), out doctorTypeChoice) || !Enum.IsDefined(typeof(DoctorTypes), doctorTypeChoice));

            doctor.DoctorType = (DoctorTypes)doctorTypeChoice;

            Console.Write("Enter doctor's expirience: ");
            doctor.Experience = byte.TryParse(Console.ReadLine(), out var exp) ? exp : (byte)0;

            Console.Write("Enter doctor's salary: ");
            doctor.Salary = decimal.TryParse(Console.ReadLine(), out var salary) ? salary : 0;

            return doctor;
        }
    }
}
