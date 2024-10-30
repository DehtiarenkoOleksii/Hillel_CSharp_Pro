using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.UI.Helpers;


namespace DoctorAppointmentDemo.UI
{
    public class DoctorAppointment
    {
        public IDoctorService DoctorService { get; }
        public IAppointmentService AppointmentService { get; }
        public IPatientService PatientService { get; }

        public DoctorAppointment(string appSettingsPath, ISerializationService configSerializerService, ISerializationService dataSerializerService)
        {
            var appSettings = configSerializerService.Deserialize<AppSettings>(appSettingsPath);

            if (appSettings == null || appSettings.Database == null)
            {
                throw new Exception("Error for get settings");
            }

            var doctorRepository = new DoctorRepository(dataSerializerService, appSettings.Database.Doctors.Path);
            var patientRepository = new PatientRepository(dataSerializerService, appSettings.Database.Patients.Path);
            var appointmentRepository = new AppointmentRepository(dataSerializerService, appSettings.Database.Appointments.Path);

            DoctorService = new DoctorService(doctorRepository);
            PatientService = new PatientService(patientRepository);
            AppointmentService = new AppointmentService(appointmentRepository);
        }

        public static DoctorAppointment InitializeStorage()
        {
            Console.Clear();

            int storageChoice = MenuHelper.MultipleChoice(true, new StorageType());
            StorageType selectedStorageType = (StorageType)storageChoice;

            string appSettingsPath;
            ISerializationService dataSerializerService;

            switch (selectedStorageType)
            {
                case StorageType.JSON:
                    appSettingsPath = Constants.JSON_DB_SETTINGS_PATH;
                    dataSerializerService = new JsonDataSerializerService();
                    break;
                case StorageType.XML:
                    appSettingsPath = Constants.XML_DB_SETTINGS_PATH;
                    dataSerializerService = new XmlDataSerializerService();
                    break;
                default:
                    throw new InvalidOperationException("Incorrect FileStorage");
            }

            var configSerializerService = new JsonDataSerializerService();

            return new DoctorAppointment(appSettingsPath, configSerializerService, dataSerializerService);
        }
    }
}
