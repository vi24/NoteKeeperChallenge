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
        public JSONStorageService()
        {
            _serializer = new DataContractJsonSerializer(typeof(Note));
        }

        public Note OpenFile(string path)
        {
            using (var stream = File.Open(path, FileMode.Open))
            //using (var reader = JsonReaderWriterFactory.CreateJsonReader(stream))
            {
                Note note = (Note)_serializer.ReadObject(stream);
                return note;
            }
        }

        public void SaveToFile(Note note, string path)
        {
            using (var stream = File.Open(path + ".json", FileMode.Create))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8))
                {
                    _serializer.WriteObject(writer, note);
                }
            }
        }
    }
}
