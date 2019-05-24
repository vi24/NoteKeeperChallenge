using NoteKeeperChallenge.Model;
using NoteKeeperChallenge.Model.Services;
using System.IO;
using System.Xml.Serialization;

namespace NoteKeeperChallenge.ViewModel
{
    public class NoteViewModel
    {
        private readonly IStorageService _storageService;

        public NoteViewModel(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void SaveFile(string title, string text, string path)
        {
            Note note = new Note(title, text);
            _storageService.SaveToFile(note, path);
        }
    }
}
