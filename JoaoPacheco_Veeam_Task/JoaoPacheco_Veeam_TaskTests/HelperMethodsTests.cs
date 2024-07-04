namespace JoaoPacheco_Veeam_Task.Tests
{
    [TestClass()]
    public class HelperMethodsTests
    {
        [TestMethod()]
        public void CompareMD5TestFail()
        {
            var testFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles\\");
            Assert.IsFalse(HelperMethods.CompareMD5(testFolder + "EqualFile1.txt", testFolder + "DifferentFile.txt"), "Different files have different MD5 hash");
        }

        [TestMethod()]
        public void CompareMD5TestSuccess()
        {
            var testFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles\\");
            Assert.IsTrue(HelperMethods.CompareMD5(testFolder + "EqualFile1.txt", testFolder + "EqualFile2.txt"), "Equal files have MD5 hash");
        }
        
        [TestMethod()]
        public void CompareMD5TestBinaryFileFail()
        {
            var testFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles\\");
            Assert.IsFalse(HelperMethods.CompareMD5(testFolder + "EqualBinaryFile1.jpg", testFolder + "DifferentBinaryFile.jpg"), "Different binary files have different MD5 hash");
        }

        [TestMethod()]
        public void CompareMD5TestBinaryFileSuccess()
        {
            var testFolder = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles\\");
            Assert.IsTrue(HelperMethods.CompareMD5(testFolder + "EqualBinaryFile1.jpg", testFolder + "EqualBinaryFile2.jpg"), "Equal binary files have MD5 hash");
        }
    }
}