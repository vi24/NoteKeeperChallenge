using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace NoteKeeperChallenge.Model.Services
{
    public class JSONStorageService : IStorageService
    {
        private DataContractJsonSerializer _serializer;
        public JSONStorageService(Type type)
        {
            _serializer = new DataContractJsonSerializer(type);
        }

        public Object OpenFile(string path)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                using (var reader = JsonReaderWriterFactory.CreateJsonReader(stream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max, null))
                {
                    Object obj = _serializer.ReadObject(reader);
                    return obj;
                }
            }
        }

        public void SaveToFile(Object obj, string path)
        {
            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8))
                {
                    _serializer.WriteObject(writer, obj);
                }
            }
        }
    }
}
