using System;
using System.Runtime.Serialization;

namespace NoteKeeperChallenge.Models
{
    [DataContract]
    public class Note
    {
        private string _title;
        private string _text;
        private DateTime _created;
        private DateTime _lastEdited;

        [DataMember]
        public string Text { get => _text; set => _text = value; }
        [DataMember]
        public string Title { get => _title; set => _title = value; }
        [DataMember]
        public DateTime Created { get => _created; set => _created = value; }
        [DataMember]
        public DateTime LastEdited { get => _lastEdited; set => _lastEdited = value; }

        public Note (string title, string text, DateTime created, DateTime lastEdited)
        {
            Title = title;
            Text = text;
            Created = created;
            LastEdited = lastEdited;
        }
    }
}
