using System;

namespace NoteKeeperChallenge.Services
{
    public interface IStorageService
    {
        void SaveToFile(Object obj, string path);
        Object OpenFile(string path);
    }
}
