using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_NullIJokable_Exception()
        {
            var mockIWritable = new Mock<IWritable>();

            Jester jester = new(null, mockIWritable.Object);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Error_NullIWritable_Exception()
        {
            var MockIJokable = new Mock<IJokable>();

            Jester jester = new(MockIJokable.Object, null);
        }

        [TestMethod]
        public void WriteJoke_Success()
        {
            StringWriter stringWriter =  new();
            Console.SetOut(stringWriter);

            string joke = "Joke without he who will not be named (Nhuck Chorris)";
            var mockIJokable = new Mock<IJokable>();
            mockIJokable.SetupSequence(mock => mock.GetJoke()).Returns("Chuck Norris").Returns("cHuCk NoRrIs").Returns(joke);

            JokeWriter jokeWriter = new JokeWriter();
            jokeWriter.SetTextWriter(Console.Out);

            Jester jester = new(mockIJokable.Object, jokeWriter);

            jester.TellJoke();

            Assert.AreEqual<string>($"{joke}{Environment.NewLine}", stringWriter.ToString());
        }
    }
}
