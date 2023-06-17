using GrossMarginApp.BaseClasses;

namespace GrossMarginApp.Tests
{
    public class ValuesBaseTests
    {
        [Test]
        public void WhenWritesValueInFile_ShouldFileExists()
        {
            // arrange
            ValuesBase values = new ValuesBase("Data", "Tests_");
            FileUtils.DeleteFileIfExists(values.ValuesFilePath);

            // act
            values.WriteValueInFile(100);

            // assert
            Assert.AreEqual(true, File.Exists(values.ValuesFilePath));
        }

        [Test]
        public void WhenWritesValuesInFile_ShouldReturnCorrectSum()
        {
            // arrange
            ValuesBase values = new ValuesBase("Data", "Tests_");
            FileUtils.DeleteFileIfExists(values.ValuesFilePath);

            // act
            values.WriteValueInFile(100);
            values.WriteValueInFile("150");
            values.ReadValuesFromFile();

            // assert
            Assert.AreEqual(250, values.Sum);
        }
    }
}