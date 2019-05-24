using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeperChallenge
{
    [Serializable]
    public class Note: ISerializable
    {
        private string _title;
        private string _text;
        private DateTime _created;
        private DateTime _lastEdited;

        public string Text { get => _text; set => _text = value; }
        public string Title { get => _title; set => _title = value; }
        public DateTime Created { get => _created; set => _created = value; }
        public DateTime LastEdited { get => _lastEdited; set => _lastEdited = value; }

        public Note (string title, string text)
        {
            Title = title;
            Text = text;
            Created = DateTime.Now;
            LastEdited = DateTime.Now;
        }

        public Note() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Text", Text);
            info.AddValue("Created", Created.ToLongDateString());
            info.AddValue("LastEdited", Created.ToLongDateString());
        }
    }
}
