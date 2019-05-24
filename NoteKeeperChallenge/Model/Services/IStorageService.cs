using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteKeeperChallenge.Model.Services
{
    public interface IStorageService
    {
        void SaveToFile(Note note, string path);
        void OpenFile(string path);
    }
}
