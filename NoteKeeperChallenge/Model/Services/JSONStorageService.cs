using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

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
            //using (var reader = JsonReaderWriterFactory.CreateJsonReader(stream))
            {
                Object obj= _serializer.ReadObject(stream);
                return obj;
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
