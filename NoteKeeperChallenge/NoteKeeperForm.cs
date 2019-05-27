using NoteKeeperChallenge.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace NoteKeeperChallenge
{
    public partial class NoteKeeperForm : Form
    {
        NoteKeeperOperator _noteKeeperOperator;


        public NoteKeeperForm()
        {
            InitializeComponent();
            _noteKeeperOperator = new NoteKeeperOperator(new JSONStorageService());
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
            if(_noteKeeperOperator.Note == null) return;
            NoteTitleTextBox.Text = _noteKeeperOperator.Note.Title;
            NoteTextBox.Text = _noteKeeperOperator.Note.Text;
            CreatedDateLabel.Text = _noteKeeperOperator.Note.Created.ToString();
            LastEditedDateLabel.Text = _noteKeeperOperator.Note.LastEdited.ToString();
        }
    }
}
