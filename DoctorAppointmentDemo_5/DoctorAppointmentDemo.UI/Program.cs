using System;
using DoctorAppointmentDemo.UI.Enums;
using DoctorAppointmentDemo.UI.Helpers;
using DoctorAppointmentDemo.UI.Prompters;

namespace DoctorAppointmentDemo.UI
{
    
    public static class Program
    {
        
        internal static DoctorAppointment _doctorAppointment;

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _doctorAppointment = DoctorAppointment.InitializeStorage();
            OpenMenu();
        }

        static void OpenMenu()
        {
            while (true)
            {
                int mainInput = MenuHelper.MultipleChoice(true, new MainMenu());

                switch ((MainMenu)mainInput)
                {
                    case MainMenu.Doctors:
                    case MainMenu.Patients:
                    case MainMenu.Appointments:
                        {
                            OpenSubMenu((MainMenu)mainInput);
                            break;
                        }
                    case MainMenu.Exit:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }

        // Sub menu with actions which depend on main menu choice
        static void OpenSubMenu(MainMenu menu)
        {
            int subInput = MenuHelper.MultipleChoice(true, new SubMenu());

            if (subInput == (int)SubMenu.Back) return;

            switch ((SubMenu)subInput)
            {
                case SubMenu.Create:
                    switch (menu)
                    {
                        case MainMenu.Doctors:
                            EntityManager.CreateEntity(
                                promptFunction: DoctorPrompter.PromptForDoctor,
                                saveFunction: _doctorAppointment.DoctorService.Create);
                            break;

                        case MainMenu.Patients:
                            EntityManager.CreateEntity(
                                promptFunction: PatientPrompter.PromptForPatient,
                                saveFunction: _doctorAppointment.PatientService.Create);
                            break;

                        case MainMenu.Appointments:
                            EntityManager.CreateEntity(
                                promptFunction: () => AppointmentPrompter.PromptForAppointment(_doctorAppointment.DoctorService, _doctorAppointment.PatientService),
                                saveFunction: _doctorAppointment.AppointmentService.Create);
                            break;

                        default:
                            throw new InvalidOperationException("Incorrect Entity");
                    }
                    break;

                case SubMenu.Update:
                    switch (menu)
                    {
                        case MainMenu.Doctors:
                            EntityManager.UpdateEntity(
                                getFunction: _doctorAppointment.DoctorService.Get,
                                promptFunction: DoctorPrompter.PromptForDoctor,
                                updateFunction: _doctorAppointment.DoctorService.Update);
                            break;

                        case MainMenu.Patients:
                            EntityManager.UpdateEntity(
                                getFunction: _doctorAppointment.PatientService.Get,
                                promptFunction: PatientPrompter.PromptForPatient,
                                updateFunction: _doctorAppointment.PatientService.Update);
                            break;

                        case MainMenu.Appointments:
                            EntityManager.UpdateEntity(
                                getFunction: _doctorAppointment.AppointmentService.Get,
                                promptFunction: appointment => AppointmentPrompter.PromptForAppointment(appointment, _doctorAppointment.DoctorService, _doctorAppointment.PatientService),
                                updateFunction: _doctorAppointment.AppointmentService.Update);
                            break;

                        default:
                            throw new InvalidOperationException("Incorrect Entity");
                    }
                    break;

                case SubMenu.Delete:
                    switch (menu)
                    {
                        case MainMenu.Doctors:
                            EntityManager.DeleteEntity(_doctorAppointment.DoctorService.Delete);
                            break;
                        case MainMenu.Patients:
                            EntityManager.DeleteEntity(_doctorAppointment.PatientService.Delete);
                            break;
                        case MainMenu.Appointments:
                            EntityManager.DeleteEntity(_doctorAppointment.AppointmentService.Delete);
                            break;
                    }
                    break;

                case SubMenu.Get:
                    switch (menu)
                    {
                        case MainMenu.Doctors:
                            EntityManager.GetEntity(_doctorAppointment.DoctorService.Get);
                            break;
                        case MainMenu.Patients:
                            EntityManager.GetEntity(_doctorAppointment.PatientService.Get);
                            break;
                        case MainMenu.Appointments:
                            EntityManager.GetEntity(_doctorAppointment.AppointmentService.Get);
                            break;
                    }
                    break;

                case SubMenu.GetAll:
                    switch (menu)
                    {
                        case MainMenu.Doctors:
                            EntityManager.GetAllEntities(_doctorAppointment.DoctorService.GetAll);
                            break;
                        case MainMenu.Patients:
                            EntityManager.GetAllEntities(_doctorAppointment.PatientService.GetAll);
                            break;
                        case MainMenu.Appointments:
                            EntityManager.GetAllEntities(_doctorAppointment.AppointmentService.GetAll);
                            break;
                    }
                    break;
            }
        }
    }
}
