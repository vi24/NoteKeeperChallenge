using NoteKeeperChallenge.Model;
using NoteKeeperChallenge.Model.Services;
using NoteKeeperChallenge.ViewModel;

namespace NoteKeeperChallenge
{
    public class NoteOperator
    {
        private NoteViewModel _note;
        private FileFormat _format;
        private static NoteOperator _noteOperator;

        private NoteOperator() { }

        public static NoteOperator GetInstance()
        {
            if(_noteOperator == null)
            {
                _noteOperator = new NoteOperator();
            }
            return _noteOperator;
        }

        public void PrepareService(FileFormat fileFormat)
        {
            _format = fileFormat;
            switch (_format)
            {
                case FileFormat.JSON:
                    _note = new NoteViewModel(new JSONStorageService());
                    break;
                case FileFormat.XML:
                    _note = new NoteViewModel(new XMLStorageService());
                    break;
            }
        }

        public void Save()
        {

        }
    }
}
