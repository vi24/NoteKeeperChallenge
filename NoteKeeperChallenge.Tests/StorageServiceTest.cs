using NoteKeeperChallenge.Model.Services;
using System;
using System.IO;
using Xunit;

namespace NoteKeeperChallenge.Tests
{

    public class StorageServiceTest
    {
        private readonly string PATH = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\SerializedNotes"));
        private const string JSON_EXTENSION = ".json";

        [Fact]
        public void SaveToFile_GivenTitleAndText_WhenSavingNewFileAndReadingOut_ThenTheContentShouldBeTheSame()
        {
            //Arrange
            JSONStorageService storageService = new JSONStorageService(typeof(Note));
            Note expectedNote = new Note("Titel", "Foo", DateTime.Now, DateTime.Now);
            //Act
            storageService.SaveToFile(expectedNote, Path.Combine(PATH, "test" + JSON_EXTENSION));
            Note actualNote = (Note)storageService.OpenFile(Path.Combine(PATH,"test" + JSON_EXTENSION));
            //Assert
            Assert.Equal(expectedNote.Title, actualNote.Title);
            Assert.Equal(expectedNote.Text, actualNote.Text);
            Assert.Equal(expectedNote.LastEdited, actualNote.LastEdited);
            Assert.Equal(expectedNote.Created, actualNote.Created);
        }

        [Fact]
        public void SaveToFile_GivenTitleAndText_WhenOverridingOldFile_ThenLastEditedTimeShouldBeGreaterThanCreatedTime()
        {
            //Arrange
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new JSONStorageService(typeof(Note)), PATH);
            noteKeeperOperator.Save("Titel", "Foo");
            string expectedDateTime = noteKeeperOperator.Note.LastEdited.ToString();
            noteKeeperOperator.OpenLastSavedNote();
            //Act
            noteKeeperOperator.Save("Titel", "Foo");
            string actualDateTime = noteKeeperOperator.Note.LastEdited.ToString();
            //Assert
            Assert.NotEqual(expectedDateTime, actualDateTime);

        }

        //[Fact]
        //public void OpenFile_GivenTitleAndText_WhenOpeningFile_ThenTheContentShouldBeEqual()
        //{
        //    //Arrange
        //    TestStorageService testStorage = new TestStorageService();
        //    NoteViewModel note = new NoteViewModel(testStorage);
        //    //Act
        //    note.OpenFile()
        //    //Assert
        //    Assert.Equal("Titel", testStorage.TestTitle);
        //    Assert.Equal("Lorem ipsum", testStorage.TestText);
        //    Assert.Equal(PATH + "Titel.txt", testStorage.TestPath);
        //}

        [Fact]
        public void SaveToFile_GivenNonExistingPath_WhenSavingFile_ThenItShouldThrowException()
        {
            JSONStorageService storageService = new JSONStorageService(typeof(Note));
        }

        [Fact]
        public void SaveToFile_GivenTitle_WhenSavingFile_ThenFileNameShouldBeDifferent()
        {

        }
    }
}
