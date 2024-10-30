using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace DoctorAppointmentDemo.Service.Services
{
    public class JsonDataSerializerService : ISerializationService
    {
        public void Serialize<T>(string path, T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);

            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.Write(json);
            }
        }

        public T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
