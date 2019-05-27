using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace NoteKeeperChallenge.Model.Services
{
    public class XMLStorageService : IStorageService
    {
        private DataContractSerializer _serializer;
        public XMLStorageService(Type type)
        {
            _serializer = new DataContractSerializer(type);
        }

        public void SaveToFile(object obj, string path)
        {
            using (var output = new StreamWriter(path + ".xml"))
            {
                using (var writer = new XmlTextWriter(output) { Formatting = Formatting.Indented })
                {
                    _serializer.WriteObject(writer, obj);
                }
            }
        }

        object IStorageService.OpenFile(string path)
        {
            using (Stream stream = File.OpenRead(path))
            {
                Note note = (Note)_serializer.ReadObject(stream);
                return note;
            }
        }
    }
}
