using NoteKeeperChallenge.Model;
using System.IO;
using System.Xml.Serialization;

namespace NoteKeeperChallenge.ViewModel
{
    public class NoteViewModel
    {
        public FileFormat FileFormat { get; set; }
        public void SaveToFile(string title, string text)
        {
            Note note = new Note(title, text);
            XmlSerializer serializer = new XmlSerializer(typeof(Note));
            using (TextWriter tw = new StreamWriter(@"C:\GitHub\NoteKeeperChallenge\NoteXML.xml"))
            {
                serializer.Serialize(tw, note);
            }
        }
    }
}
