using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoteKeeperChallenge.Model.Services
{
    public class XMLStorageService : IStorageService
    {
        private XmlSerializer _serializer;
        public XMLStorageService()
        {
            _serializer = new XmlSerializer(typeof(Note));
        }

        public void OpenFile(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(Note note, string path)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                _serializer.Serialize(tw, note);
            }
        }
    }
}
