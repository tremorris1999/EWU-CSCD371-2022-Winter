using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeWriterTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void JokeWriter_NullTextWriterProperty_ThrowsException()
        {
            JokeWriter jokeWriter = new();
            jokeWriter.Write("this should throw, since the TextWriter property is still null.");
        }

        [TestMethod]
        public void JokeWriter_Write_Success()
        {
            StringWriter stringWriter = new();
            JokeWriter jokeWriter = new();
            jokeWriter.setTextWriter(stringWriter);

            string output = "test";

            jokeWriter.Write(output);

            Assert.AreEqual($"{output}{Environment.NewLine}", stringWriter.ToString());
        }
    }
}