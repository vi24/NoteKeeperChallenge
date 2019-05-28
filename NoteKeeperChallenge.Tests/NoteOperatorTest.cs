using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace NoteKeeperChallenge.Tests
{
    public class NoteOperatorTest
    {
        private string _noteFilesDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\SerializedNotes"));
        private string GenerateFileName(string title)
        {
            return Regex.Replace(title, @"\s+", "") + ".json";
        }

        private string GetFullPathName(string title)
        {
            return Path.Combine(_noteFilesDirectory, GenerateFileName(title));
        }

        [Fact]
        public void GenerateFileName_GivenATitle_WhenGenerated_ThenFileNameShouldHaveNoSpaces()
        {
            string title = "Hallo    Wie Geht ess??";
            string generated = GenerateFileName(title);
            Assert.Equal("HalloWieGehtess??.json", generated);
            string title1 = "Hallo ";
            string generated1 = GenerateFileName(title1);
            Assert.Equal("Hallo.json", generated1);
            string title2 = "   Hallo ";
            string generated2 = GenerateFileName(title2);
            Assert.Equal("Hallo.json", generated2);
        }

        [Fact]
        public void GetFullPathName_GivenATitle_WhenGettingFullPathName_ThenPathShouldBeCorrect()
        {
            string title = " Hey ";
            string expected = @"C:\GitHub\NoteKeeperChallenge\SerializedNotes" + @"\Hey.json";
            Assert.Equal(expected, GetFullPathName(title));
        }
    }
}
