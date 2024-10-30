namespace DoctorAppointmentDemo.UI.Prompters
{
    using DoctorAppointmentDemo.Domain.Entities;
    using DoctorAppointmentDemo.Domain.Enums;
    using System;

    public static class PatientPrompter
    {
        public static Patient PromptForPatient()
        {
            return PromptForPatient(null);
        }

        public static Patient PromptForPatient(Patient patient)
        {
            patient ??= new Patient();

            Console.Write("Enter patient's name: ");
            patient.Name = Console.ReadLine();

            Console.Write("Enter patient's surname: ");
            patient.Surname = Console.ReadLine();

            Console.Write("Enter patient's phone (XXX-XXX-XXXX): ");
            patient.Phone = Console.ReadLine();

            Console.Write("Enter patient's email: ");
            patient.Email = Console.ReadLine();

            // Вибір типу хвороби
            Console.WriteLine("Choice illness type:");
            foreach (var type in Enum.GetValues(typeof(IllnessTypes)))
            {
                Console.WriteLine($"{(int)type} - {type}");
            }

            int illnessTypeChoice;
            do
            {
                Console.Write("Enter number, which according to illness type: ");
            } while (!int.TryParse(Console.ReadLine(), out illnessTypeChoice) || !Enum.IsDefined(typeof(IllnessTypes), illnessTypeChoice));

            patient.IllnessType = (IllnessTypes)illnessTypeChoice;

            Console.Write("Enter add info");
            patient.AdditionalInfo = Console.ReadLine();

            Console.Write("Enter patient's address: ");
            patient.Address = Console.ReadLine();

            return patient;
        }
    }
}
