using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_Disk;
using System.IO;

namespace Unit_Test_CheckDisk
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Sprawdz_miejsce_na_dysku_ReturnsTrue()
        {
            Logika l = new Logika();
            Assert.IsTrue(l.SprawdzMiejsceNaDysku(2097152,@"c:\\"));
        }

        [TestMethod]
        public void Test_Tworzenia_Folderu()
        {
            Logika l = new Logika();
            l.CreateFolder(@"c:\\");
            Assert.IsTrue(Directory.Exists(@"c:\\testowepliki"));
        }

        [TestMethod]
        public void Test_Usuwania_Folderu()
        {
            Logika l = new Logika();
            l.DeleteTestFileFolder(@"c:\\testowepliki");
            Assert.IsFalse(Directory.Exists(@"c:\\testowepliki"));
        }
    }
}
