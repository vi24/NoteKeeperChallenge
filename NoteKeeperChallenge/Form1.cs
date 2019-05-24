using NoteKeeperChallenge.ViewModel;
using System;
using System.Windows.Forms;

namespace NoteKeeperChallenge
{
    public partial class Form1 : Form
    {
        NoteViewModel _noteViewModel;
        public Form1()
        {
            InitializeComponent();
            _noteViewModel = new NoteViewModel();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _noteViewModel.SaveToFile(NoteTitleTextBox.Text, NoteTextBox.Text);
        }
    }
}
