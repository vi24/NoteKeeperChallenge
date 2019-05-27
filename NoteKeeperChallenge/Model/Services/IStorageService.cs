using System;

namespace NoteKeeperChallenge.Model.Services
{
    public interface IStorageService
    {
        void SaveToFile(Object obj, string path);
        Object OpenFile(string path);
    }
}
