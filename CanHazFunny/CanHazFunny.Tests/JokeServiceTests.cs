using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void JokeService_GetJoke_ReturnsString()
        {
            JokeService jokeService = new();
            string? joke = jokeService.GetJoke();
            Assert.IsInstanceOfType(joke, typeof(string));
        }
    }
}
