﻿using NoteKeeperChallenge.Model.Services;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NoteKeeperChallenge
{
    public class NoteKeeperOperator
    {
        private IStorageService _storageService;
        private Note _note;
        private const string FILE_NAME_WITHOUT_EXTENSION = "foo";
        private const string FILE_NAME = "foo.json";
        private static NoteKeeperOperator _noteOperator;

        private readonly string PATH = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\SerializedNotes"));

        private NoteKeeperOperator(IStorageService service)
        {
            _storageService = service;
        }

        public static NoteKeeperOperator GetInstance()
        {
            if(_noteOperator == null)
            {
                _noteOperator = new NoteKeeperOperator(new JSONStorageService(typeof(Note)));
            }
            return _noteOperator;
        }

        public void Save(string title, string text)
        {
            if (File.Exists(Path.Combine(PATH, FILE_NAME)))
            {
                _note.Title = title;
                _note.Text = text;
                _note.LastEdited = DateTime.Now;
                _storageService.SaveToFile(_note, Path.Combine(PATH, FILE_NAME_WITHOUT_EXTENSION));
            }
            else
            {
                _note = new Note(title, text, DateTime.Now, DateTime.Now);
                _storageService.SaveToFile(_note, Path.Combine(PATH, FILE_NAME_WITHOUT_EXTENSION));
            }
        }

        public void OpenLastSavedNote()
        {
            if (!File.Exists(Path.Combine(PATH, FILE_NAME))) return;
            _note = (Note)_storageService.OpenFile(Path.Combine(PATH, FILE_NAME));
        }

        public void LoadContentFromNote(out string title, out string text, out string createdText, out string lastEditedText)
        {
            if(_note != null)
            {
                title = _note.Title;
                text = _note.Text;
                createdText = _note.Created.ToString();
                lastEditedText = _note.LastEdited.ToString();
            }
            else
            {
                title = String.Empty;
                text = String.Empty;
                createdText = String.Empty;
                lastEditedText = String.Empty;
            }

        }
    }
}
