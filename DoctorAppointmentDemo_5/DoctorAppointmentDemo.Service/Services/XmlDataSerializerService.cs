using DoctorAppointmentDemo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Service.Services
{
    public class XmlDataSerializerService : ISerializationService
    {
        public void Serialize<T>(string path, T data)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, data);
            }
        }

        public T Deserialize<T>(string path)
        {
            if (!File.Exists(path) || new FileInfo(path).Length == 0)
            {
                return Activator.CreateInstance<T>();
            }

            using (var reader = new StreamReader(path, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
