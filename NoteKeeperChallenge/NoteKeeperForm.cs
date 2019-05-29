﻿using NoteKeeperChallenge.Operator;
using NoteKeeperChallenge.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace NoteKeeperChallenge
{
    public partial class NoteKeeperForm : Form
    {
        private readonly NoteKeeperOperator _noteKeeperOperator;

        public NoteKeeperForm()
        {
            InitializeComponent();
            try
            {
                _noteKeeperOperator = new NoteKeeperOperator(new XMLStorageService());
                _noteKeeperOperator.OpenLastSavedNote();
                UpdateNoteOnForms();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Ain't nobody got time to catch seven different Exceptions. Pls lookup in the Non-Existing Log-File to see what went wrong (hint: probably problem with directory creation):)!");
                Application.Exit();
            }
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
                _noteKeeperOperator.SaveWithStaticFileName(NoteTitleTextBox.Text, NoteTextBox.Text);
                UpdateNoteOnForms();
                MessageBox.Show("File has been saved!");
            }
            catch (IOException io)
            {
                MessageBox.Show("An Error has occured: \n\n" + io.Message);
            }
        }

        private void UpdateNoteOnForms()
        {
            if(_noteKeeperOperator.Note == null) return;
            NoteTitleTextBox.Text = _noteKeeperOperator.Note.Title;
            NoteTextBox.Text = _noteKeeperOperator.Note.Text;
            CreatedDateLabel.Text = _noteKeeperOperator.Note.Created.ToString();
            LastEditedDateLabel.Text = _noteKeeperOperator.Note.LastEdited.ToString();
        }
    }
}
