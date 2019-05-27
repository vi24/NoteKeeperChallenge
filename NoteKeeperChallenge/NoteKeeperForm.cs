using NoteKeeperChallenge.Exceptions;
using NoteKeeperChallenge.Model;
using NoteKeeperChallenge.ViewModel;
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
            _noteKeeperOperator = NoteKeeperOperator.GetInstance();
            NoteFormat.Items.Add(FileFormat.JSON);
            NoteFormat.Items.Add(FileFormat.XML);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NoteTextBox.Text))
            {
                MessageBox.Show("Title is empty!");
                return;
            }
            try
            {
                _noteKeeperOperator.Save(NoteTitleTextBox.Text, NoteTextBox.Text);
                MessageBox.Show("File has been saved!");
            }
            catch (IOException io)
            {
                MessageBox.Show("An Error has occured: \n\n" + io.Message);
            }
            catch (FileFormatNotDefinedException ff)
            {
                MessageBox.Show(ff.Message);
            }
            
        }

        private void NoteFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(NoteFormat.SelectedItem.ToString() == FileFormat.XML.ToString())
            {
                _noteKeeperOperator.PrepareService(FileFormat.XML);
            }
            if(NoteFormat.SelectedItem.ToString() == FileFormat.JSON.ToString())
            {
                _noteKeeperOperator.PrepareService(FileFormat.JSON);
            }
        }
    }
}
