using NoteKeeperChallenge.Model.Services;
using System;
using System.IO;
using Xunit;

namespace NoteKeeperChallenge.Tests
{

    public class StorageServiceTest
    {
        private const string PATH = @"C:\GitHub\NoteKeeperChallenge\NoteKeeperChallenge\SerializedNotes";

        [Fact]
        public void SaveToFile_GivenTitleAndText_WhenSavingNewFileAndReadingOut_ThenTheContentShouldBeTheSame()
        {
            //Arrange
            JSONStorageService storageService = new JSONStorageService(typeof(Note));
            //Act
            Note savedNote = new Note("Titel", "Foo", DateTime.Now, DateTime.Now); 
            storageService.SaveToFile(savedNote, Path.Combine(PATH, "test.json"));
            Note noteToRead = (Note)storageService.OpenFile(Path.Combine(PATH, "test.json"));
            //Assert
            Assert.Equal(savedNote.Title, noteToRead.Title);
            Assert.Equal(savedNote.Text, noteToRead.Text);
            Assert.Equal(savedNote.Created, noteToRead.Created);
            Assert.Equal(savedNote.LastEdited, noteToRead.LastEdited);
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
