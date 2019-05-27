using NoteKeeperChallenge.ViewModel;
using System;
using Xunit;

namespace NoteKeeperChallenge.Tests
{

    public class StorageServiceTest
    {
        private const string PATH = @"C:\Users\raviv\Documents\GitHub\NoteKeeperChallenge\";

        [Fact]
        public void SaveToFile_GivenTitleAndText_WhenSavingFile_ThenTheContentShouldBeEqual()
        {
            //Arrange
            TestStorageService testStorage = new TestStorageService();
            NoteViewModel note = new NoteViewModel(testStorage);
            //Act
            note.SaveFile("Titel", "Lorem ipsum");
            //Assert
            Assert.Equal("Titel", testStorage.TestTitle);
            Assert.Equal("Lorem ipsum", testStorage.TestText);
            Assert.Equal(PATH + "Titel.txt", testStorage.TestPath);
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

        }

        [Fact]
        public void SaveToFile_GivenTitle_WhenSavingFile_ThenFileNameShouldBeDifferent()
        {

        }
    }
}
