using Microsoft.VisualStudio.TestTools.UnitTesting;
using Check_Disk;

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
    }
}
