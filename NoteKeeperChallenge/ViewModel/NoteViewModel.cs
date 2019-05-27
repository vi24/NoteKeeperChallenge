using NoteKeeperChallenge.Model;
using NoteKeeperChallenge.Model.Services;
using System;
using System.IO;
using System.Xml.Serialization;

namespace NoteKeeperChallenge.ViewModel
{
    public class NoteViewModel
    {
        private readonly IStorageService _storageService;
        public Note Note { get; private set; }

        public NoteViewModel() { }

        public NoteViewModel(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void SaveFile(string title, string text, string filename, DateTime created, DateTime lastEdited)
        {
            Note = new Note(title, text, created, lastEdited);
            _storageService.SaveToFile(Note, filename);
        }

        public void OpenFile(string path)
        {
            _storageService.OpenFile(path);
        }

    }
}
