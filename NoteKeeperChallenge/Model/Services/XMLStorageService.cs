using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NoteKeeperChallenge.Model.Services
{
    public class XMLStorageService : IStorageService
    {
        private DataContractSerializer _serializer;
        public XMLStorageService()
        {
            _serializer = new DataContractSerializer(typeof(Note));
        }

        public Note OpenFile(string path)
        {
            using(Stream stream = File.OpenRead(path))
            {
                Note note = (Note)_serializer.ReadObject(stream);
                return note;
            }
        }

        public void SaveToFile(Note note, string path)
        {
            using (var output = new StreamWriter(path + ".xml"))
            using (var writer = new XmlTextWriter(output) {Formatting = Formatting.Indented})
            {
                _serializer.WriteObject(writer, note);
            }
        }
    }
}
