using NoteKeeperChallenge.Model.Services;
using System;
using Xunit;

namespace NoteKeeperChallenge.Tests
{

    public class StorageServiceTest
    {
        private const string PATH = @"C:\GitHub\NoteKeeperChallenge\NoteKeeperChallenge\SerializedNotes";

        [Fact]
        public void SaveToFile_GivenTitleAndText_WhenSavingFile_ThenTheContentShouldBeEqual()
        {
            //Arrange
            TestStorageService testStorage = new TestStorageService();
            NoteKeeperOperator noteKeeper = NoteKeeperOperator.GetInstance();
            //Act
            noteKeeper.Save("Titel", "Lorem ipsum");
            //Assert
            Assert.Equal("Titel", testStorage.TestTitle);
            Assert.Equal("Lorem ipsum", testStorage.TestText);
            Assert.Equal(PATH + "Titel", testStorage.TestPath);
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
