﻿using NoteKeeperChallenge.Model;
using NoteKeeperChallenge.Operator;
using NoteKeeperChallenge.Services;
using System;
using System.IO;
using Xunit;

namespace NoteKeeperChallenge.Tests
{
    public class OperatorXMLServiceTest
    {
        private readonly string PATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\SerializedNotes");
        private readonly Type TYPE = typeof(Note);
        private const string XML_EXTENSION = ".xml";

        [Fact]
        public void GivenXMLServiceTitleAndText_WhenSavingNewFileAndReadingOut_ThenTheContentShouldBeTheSame()
        {
            //Arrange
            XMLStorageService storageService = new XMLStorageService();
            Note expectedNote = new Note("Titel", "Foo", DateTime.Now, DateTime.Now);
            //Act
            storageService.SaveToFile(expectedNote, Path.Combine(PATH, "test" + XML_EXTENSION), TYPE);
            Note actualNote = (Note)storageService.OpenFile(Path.Combine(PATH, "test" + XML_EXTENSION), TYPE);
            //Assert
            Assert.Equal(expectedNote.Title, actualNote.Title);
            Assert.Equal(expectedNote.Text, actualNote.Text);
            Assert.Equal(expectedNote.LastEdited.ToString(), actualNote.LastEdited.ToString());
            Assert.Equal(expectedNote.Created.ToString(), actualNote.Created.ToString());
        }

        [Fact]
        public void SaveWithStaticFileName_GivenXMLServiceTitleAndText_WhenOverridingOldFile_ThenCurrentLastEditedTimeShouldBeGreaterThanPreviousLastEditedTime()
        {
            //Arrange
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new XMLStorageService(), PATH);
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long previousLastEditedFileTime = noteKeeperOperator.Note.LastEdited.ToFileTime();
            noteKeeperOperator.OpenLastSavedNote();
            //Act
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long currentLastEditedFileTime = noteKeeperOperator.Note.LastEdited.ToFileTime();
            //Assert
            Assert.True(currentLastEditedFileTime > previousLastEditedFileTime);
        }

        [Fact]
        public void SaveWithStaticFileName_GivenXMLServiceTitleAndText_WhenOverridingOldFile_ThenLastEditedTimeShouldBeGreaterThanCreatedTime()
        {
            //Arrange
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new XMLStorageService(), PATH);
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long createdFileTime = noteKeeperOperator.Note.Created.ToFileTime();
            noteKeeperOperator.OpenLastSavedNote();
            //Act
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long lastEditedFileTime = noteKeeperOperator.Note.LastEdited.ToFileTime();
            //Assert
            Assert.True(lastEditedFileTime > createdFileTime);
        }

        [Fact]
        public void SaveWithStaticFileName_GivenXMLServiceTitleAndText_WhenOverridingOldFile_ThenCreatedTimeShouldStayTheSame()
        {
            //Arrange
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new XMLStorageService(), PATH);
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long expectedDateTime = noteKeeperOperator.Note.Created.ToFileTime();
            //Act
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long actualDateTime = noteKeeperOperator.Note.Created.ToFileTime();
            //Assert
            Assert.Equal(expectedDateTime, actualDateTime);
        }

        [Fact]
        public void SaveToFile_GivenXMLServiceAndNonExistingPath_WhenSavingFile_ThenItShouldThrowDirectoryNotFoundException()
        {
            XMLStorageService storageService = new XMLStorageService();
            Note note = new Note("Titel", "Foo", DateTime.Now, DateTime.Now);
            Assert.Throws<DirectoryNotFoundException>(() => storageService.SaveToFile(note, @"C:\NotExistingPath\A", TYPE));
        }

        [Fact]
        public void GivenJSONServiceAndNote_WhenSavingFileAndClosingApp_ThenTheSameNoteShouldBeLoadedViaMetaDataFileNextTimeAfterOpeningApp()
        {
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new XMLStorageService(), PATH);
            noteKeeperOperator.SaveWithDynamicFileName("Titel", "Foo");
            Note expectedNote = noteKeeperOperator.Note;
            noteKeeperOperator = new NoteKeeperOperator(new XMLStorageService(), PATH);
            noteKeeperOperator.OpenLastSaveNoteViaMetaData();
            Note actualNote = noteKeeperOperator.Note;
            Assert.Equal(expectedNote.Title, actualNote.Title);
            Assert.Equal(expectedNote.Text, actualNote.Text);
            Assert.Equal(expectedNote.Created.ToString(), actualNote.Created.ToString());
            Assert.Equal(expectedNote.LastEdited.ToString(), actualNote.LastEdited.ToString());
        }
    }
}
