using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeperChallenge.Model
{
    [DataContract]
    public class MetaData
    {
        [DataMember]
        public string LastSavedNotePath { get; set; }

        public MetaData (string path)
        {
            LastSavedNotePath = path;
        }
    }
}
