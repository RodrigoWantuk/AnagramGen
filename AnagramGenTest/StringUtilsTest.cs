using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnagramaGen;

namespace AnagramGenTest
{
    [TestClass]
    public class StringUtilsTest
    {
        [TestMethod]
        public void ReplaceFirstTest()
        {
            String testString = "lakelakeriverlake";

            Assert.AreEqual("lakeriverlake", StringUtils.ReplaceFirst(testString, "lake", ""));

            Assert.AreEqual("lakelakelake", StringUtils.ReplaceFirst(testString, "river", ""));

            Assert.AreEqual("akelakeriverlake", StringUtils.ReplaceFirst(testString, "l", ""));

            testString = "LaKelakeRiverlake";

            Assert.AreEqual("aKelakeRiverlake", StringUtils.ReplaceFirst(testString, "L", ""));

            Assert.AreEqual("LaKeakeRiverlake", StringUtils.ReplaceFirst(testString, "l", ""));
        }

        [TestMethod]
        public void IsAnagramTest()
        {
            Assert.IsTrue(StringUtils.IsAnagram("A", "A"));

            Assert.IsTrue(StringUtils.IsAnagram("A", "a"));

            Assert.IsTrue(StringUtils.IsAnagram("Elvis", "Lives"));

            Assert.IsTrue(StringUtils.IsAnagram("dusty", "STUDY"));

            Assert.IsFalse(StringUtils.IsAnagram("Elvis", "STUDY"));

            Assert.IsFalse(StringUtils.IsAnagram("a", "b"));

            Assert.IsFalse(StringUtils.IsAnagram("Saved", "Vase"));

        }

        [TestMethod]
        public void CountVowelsTest()
        {
            Assert.AreEqual(1, StringUtils.CountVowels("a"));

            Assert.AreEqual(0, StringUtils.CountVowels("xyzkkly"));

            Assert.AreEqual(2, StringUtils.CountVowels("apple"));

            Assert.AreEqual(2, StringUtils.CountVowels("Apple"));

            Assert.AreEqual(2, StringUtils.CountVowels("ApplE"));
        }
    }
}
