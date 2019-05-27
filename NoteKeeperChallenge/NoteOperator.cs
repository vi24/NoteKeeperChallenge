using NoteKeeperChallenge.Model.Services;
using System;
using System.IO;

namespace NoteKeeperChallenge
{
    public class NoteKeeperOperator
    {
        private IStorageService _storageService;
        public Note Note { get; private set; }
        private const string FILE_NAME = "foo";
        private const string FILE_EXTENSION = ".json";

        private readonly string _noteFilesDirectory;

        public NoteKeeperOperator(IStorageService service)
        {
            _storageService = service;
            _noteFilesDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\SerializedNotes"));
        }

        public NoteKeeperOperator(IStorageService service, string noteFilesDirectory)
        {
            _storageService = service;
            _noteFilesDirectory = noteFilesDirectory;
        }

        public void Save(string title, string text)
        {
            if (File.Exists(Path.Combine(_noteFilesDirectory, FILE_NAME + FILE_EXTENSION)))
            {
                OpenLastSavedNote();
                Note.Title = title;
                Note.Text = text;
                Note.LastEdited = DateTime.Now;
                _storageService.SaveToFile(Note, Path.Combine(_noteFilesDirectory, FILE_NAME + FILE_EXTENSION));
            }
            else
            {
                Note = new Note(title, text, DateTime.Now, DateTime.Now);
                _storageService.SaveToFile(Note, Path.Combine(_noteFilesDirectory, FILE_NAME + FILE_EXTENSION));
            }
        }

        public void OpenLastSavedNote()
        {
            if (!File.Exists(Path.Combine(_noteFilesDirectory, FILE_NAME + FILE_EXTENSION))) return;
            Note = (Note)_storageService.OpenFile(Path.Combine(_noteFilesDirectory, FILE_NAME + FILE_EXTENSION));
        }
    }
}
