﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeperChallenge
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

        public Note (string title, string text)
        {
            Title = title;
            Text = text;
            Created = DateTime.Now;
            LastEdited = DateTime.Now;
        }

        public Note (string title, string text, DateTime created, DateTime lastEdited)
        {
            Title = title;
            Text = text;
            Created = created;
            LastEdited = lastEdited;
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
