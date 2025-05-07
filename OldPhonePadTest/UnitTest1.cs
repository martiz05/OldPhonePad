using Microsoft.VisualStudio.TestTools.UnitTesting;
using OldPhonePad.Services;
using System;

namespace OldPhonePadTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStringAssert()
        {
            string result = new DecoderService().DecodeInput("8 88777444666*664#");
            Assert.AreEqual("TURING", result);
        }

        [TestMethod]
        public void TestStringNotAssert()
        {
            string result = new DecoderService().DecodeInput("8 88777444666*664#");
            Assert.AreNotEqual("TURNG", result);
        }
    }
}
