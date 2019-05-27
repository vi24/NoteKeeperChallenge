using NoteKeeperChallenge.Exceptions;
using NoteKeeperChallenge.Model;
using NoteKeeperChallenge.Model.Services;
using NoteKeeperChallenge.ViewModel;
using System;
using System.IO;

namespace NoteKeeperChallenge
{
    public interface IStorageService
    {
        void SaveToFile(Note note, string path);
        Note OpenFile(string path);
    }

    public class NoteViewModel
    {
        private readonly IStorageService _storageService;
        private readonly string PATH = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\SerializedNotes"));

        public NoteViewModel() { }

        public NoteViewModel(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void SaveFile(string title, string text)
        {
            Note note = new Note(title, text);
            _storageService.SaveToFile(note, Path.Combine(PATH, title.Replace(" ", "") + note.Created.Ticks));
        }

        public void OpenFile(string path)
        {
            _storageService.OpenFile(path);
        }

    }

    public class NoteKeeperOperator
    {
        private static NoteViewModel _noteViewModel;
        private FileFormat _format;
        private static NoteKeeperOperator _noteOperator;

        private NoteKeeperOperator() { }

        public static NoteKeeperOperator GetInstance()
        {
            if(_noteOperator == null)
            {
                _noteOperator = new NoteKeeperOperator();
            }
            return _noteOperator;

        }

        public void PrepareService(FileFormat fileFormat)
        {
            _format = fileFormat;
            switch (_format)
            {
                case FileFormat.JSON:
                    _noteViewModel = new NoteViewModel(new JSONStorageService());
                    break;
                case FileFormat.XML:
                    _noteViewModel = new NoteViewModel(new XMLStorageService());
                    break;
            }
        }

        public void Save(string title, string text)
        {
            if(_noteViewModel != null)
            {
                _noteViewModel.SaveFile(title, text);
            }
            else
            {
                throw new FileFormatNotDefinedException("Choose File format first!");
            }
        }
    }
}
