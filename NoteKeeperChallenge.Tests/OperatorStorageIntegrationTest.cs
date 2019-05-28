using NoteKeeperChallenge.Models;
using NoteKeeperChallenge.Services;
using System;
using System.IO;
using Xunit;

namespace NoteKeeperChallenge.Tests
{
    public class OperatorStorageIntegrationTest
    {
        private readonly string PATH = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\SerializedNotes");
        private readonly Type TYPE = typeof(Note);
        private const string JSON_EXTENSION = ".json";
        
        [Fact]
        public void GivenTitleAndText_WhenSavingNewFileAndReadingOut_ThenTheContentShouldBeTheSame()
        {
            //Arrange
            JSONStorageService storageService = new JSONStorageService();
            Note expectedNote = new Note("Titel", "Foo", DateTime.Now, DateTime.Now);
            //Act
            storageService.SaveToFile(expectedNote, Path.Combine(PATH, "test" + JSON_EXTENSION), TYPE);
            Note actualNote = (Note)storageService.OpenFile(Path.Combine(PATH,"test" + JSON_EXTENSION), TYPE);
            //Assert
            Assert.Equal(expectedNote.Title, actualNote.Title);
            Assert.Equal(expectedNote.Text, actualNote.Text);
            Assert.Equal(expectedNote.LastEdited.ToString(), actualNote.LastEdited.ToString());
            Assert.Equal(expectedNote.Created.ToString(), actualNote.Created.ToString());
        }

        [Fact]
        public void SaveWithStaticFileName_GivenTitleAndText_WhenOverridingOldFile_ThenCurrentLastEditedTimeShouldBeGreaterThanPreviousLastEditedTime()
        {
            //Arrange
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new JSONStorageService(), PATH);
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
        public void SaveWithStaticFileName_GivenTitleAndText_WhenOverridingOldFile_ThenLastEditedTimeShouldBeGreaterThanCreatedTime()
        {
            //Arrange
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new JSONStorageService(), PATH);
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
        public void SaveWithStaticFileName_GivenTitleAndText_WhenOverridingOldFile_ThenCreatedTimeShouldStayTheSame()
        {
            //Arrange
            NoteKeeperOperator noteKeeperOperator = new NoteKeeperOperator(new JSONStorageService(), PATH);
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long expectedDateTime = noteKeeperOperator.Note.Created.ToFileTime();
            //Act
            noteKeeperOperator.SaveWithStaticFileName("Titel", "Foo");
            long actualDateTime = noteKeeperOperator.Note.Created.ToFileTime();
            //Assert
            Assert.Equal(expectedDateTime, actualDateTime);

        }

        [Fact]
        public void SaveToFile_GivenNonExistingPath_WhenSavingFile_ThenItShouldThrowDirectoryNotFoundException()
        {
            JSONStorageService storageService = new JSONStorageService();
            Note note = new Note("Titel", "Foo", DateTime.Now, DateTime.Now);
            Assert.Throws<DirectoryNotFoundException>(() => storageService.SaveToFile(note, @"C:\NotExistingPath\A", TYPE));
        }
    }
}
