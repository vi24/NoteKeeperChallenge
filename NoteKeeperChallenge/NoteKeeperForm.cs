using NoteKeeperChallenge.Model.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace NoteKeeperChallenge
{
    public partial class NoteKeeperForm : Form
    {
        NoteKeeperOperator _noteKeeperOperator;
        private string _title;
        private string _text;
        private string _created;
        private string _lastEdited;

        public NoteKeeperForm()
        {
            InitializeComponent();
            _noteKeeperOperator = new NoteKeeperOperator(new JSONStorageService(typeof(Note)));
            _noteKeeperOperator.OpenLastSavedNote();
            UpdateNoteMetaDataOnForms();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NoteTitleTextBox.Text))
            {
                MessageBox.Show("Title is empty!");
                return;
            }
            try
            {
                _noteKeeperOperator.Save(NoteTitleTextBox.Text, NoteTextBox.Text);
                UpdateNoteMetaDataOnForms();
                MessageBox.Show("File has been saved!");
            }
            catch (IOException io)
            {
                MessageBox.Show("An Error has occured: \n\n" + io.Message);
            }
        }

        private void UpdateNoteMetaDataOnForms()
        {
            _noteKeeperOperator.LoadContentFromNote(out _title, out _text, out _created, out _lastEdited);
            NoteTitleTextBox.Text = _title;
            NoteTextBox.Text = _text;
            CreatedDateLabel.Text = _created;
            LastEditedDateLabel.Text = _lastEdited;
        }
    }
}
