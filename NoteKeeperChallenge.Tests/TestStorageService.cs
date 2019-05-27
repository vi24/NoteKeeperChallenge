using NoteKeeperChallenge.Model.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteKeeperChallenge.Tests
{
    public class TestStorageService : IStorageService
    {
        public string TestTitle { get; private set; }
        public string TestText { get; private set; }

        public string TestPath { get; private set; }

        private const string FILE_FORMAT = ".txt";

        public Note OpenFile(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(Note note, string path)
        {
            TestTitle = note.Title;
            TestText = note.Text;
            TestPath = path + TestTitle + FILE_FORMAT;
        }
    }
}
