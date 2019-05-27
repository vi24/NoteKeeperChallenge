using NoteKeeperChallenge.Exceptions;
using NoteKeeperChallenge.Model;
using NoteKeeperChallenge.Model.Services;
using NoteKeeperChallenge.ViewModel;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NoteKeeperChallenge
{
    public class NoteKeeperOperator
    {
        private const string META_DATA_FILENAME = "metadata.dat";
        private const string FILE_NAME = "foo.json";
        private static NoteViewModel _noteViewModel;
        private FileFormat _format;
        private static NoteKeeperOperator _noteOperator;
        private readonly string PATH = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\SerializedNotes"));
        public MetaData MetaData { get; private set; }
        private BinaryFormatter _formatter = new BinaryFormatter();


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

        public Note Save(string title, string text)
        {
            if(_noteViewModel == null)
            {
                throw new FileFormatNotDefinedException("Choose File format first!");
            }
            DateTime dateTime = DateTime.Now;
            string filename = Path.Combine(PATH, title.Replace(" ", "")) + dateTime.Ticks;
            _noteViewModel.SaveFile(title, text, filename, dateTime, dateTime);
            WriteToMetaDataFile(dateTime, title, filename);
            return _noteViewModel.Note;
        }

        private void WriteToMetaDataFile(DateTime dateTime, string title, string path)
        {
            if (MetaData == null)
            {
                MetaData = new MetaData(path, title, dateTime, dateTime);
            }
            if (MetaData.SavedFileTitle == title)
            {
                MetaData = new MetaData(MetaData.SavedFilePath, title, MetaData.CreatedText, dateTime);
            }
            else
            {
                MetaData = new MetaData(MetaData.SavedFilePath, title, dateTime, dateTime);
            }
            using (Stream output = File.Create(META_DATA_FILENAME))
            {
                _formatter.Serialize(output, MetaData);
            }
        }

        public void OpenLastFile()
        {
            //Note note = _noteViewModel.OpenFile(PATH + FILE_NAME);
        }

        public void OpenMetaDataFile()
        {
            if (File.Exists(META_DATA_FILENAME))
            {
                using (Stream input = File.OpenRead(META_DATA_FILENAME))
                {
                    MetaData = (MetaData)_formatter.Deserialize(input);
                }
                
            }
        }
    }
}
