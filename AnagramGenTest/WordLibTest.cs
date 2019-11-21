using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using AnagramaGen;

namespace AnagramGenTest
{
    [TestClass]
    public class WordLibTest
    {
        [TestMethod]
        public void LoadLibTest()
        {
            String tmpFile = Path.GetTempFileName();
            File.Delete(tmpFile);
            File.AppendAllText(tmpFile, "A" + Environment.NewLine);
            File.AppendAllText(tmpFile, "APPLE" + Environment.NewLine);
            File.AppendAllText(tmpFile, "STIL" + Environment.NewLine);
            File.AppendAllText(tmpFile, "SILT" + Environment.NewLine);
            File.AppendAllText(tmpFile, "SLIT" + Environment.NewLine);

            WordLib lib = new WordLib(tmpFile);

            Assert.AreEqual(5, lib.TotalWords);

            Assert.AreEqual("A", lib.DicLib[1][1][0].Value);

            File.Delete(tmpFile);
            File.AppendAllText(tmpFile, "A" + Environment.NewLine);
            File.AppendAllText(tmpFile, "APPLE" + Environment.NewLine);
            File.AppendAllText(tmpFile, "STIL" + Environment.NewLine);
            File.AppendAllText(tmpFile, "SILT" + Environment.NewLine);
            File.AppendAllText(tmpFile, "SLIT" + Environment.NewLine);

            lib = new WordLib(tmpFile, 4);

            Assert.AreEqual(3, lib.TotalWords);
        }
    }
}
