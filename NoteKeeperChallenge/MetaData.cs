using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeperChallenge
{
    [Serializable]
    public class MetaData
    {
  
        public string SavedFilePath { get; }

        public string SavedFileTitle { get; }

        public DateTime CreatedText { get; }

        public DateTime LastEdited { get; }

        public MetaData(string savedFilePath, string savedFileTitle, DateTime createdText, DateTime lastEdited)
        {
            SavedFilePath = savedFilePath;
            SavedFileTitle = savedFileTitle;
            CreatedText = createdText;
            LastEdited = lastEdited;
        }
    }
}
