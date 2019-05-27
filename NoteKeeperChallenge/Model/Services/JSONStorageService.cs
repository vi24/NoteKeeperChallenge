using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeperChallenge.Model.Services
{
    public class JSONStorageService : IStorageService
    {
        //private JsonSerializer _serializer;
        public JSONStorageService()
        {

        }

        public Note OpenFile(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(Note note, string path)
        {
            throw new NotImplementedException();
        }
    }
}
