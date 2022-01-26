using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_Unconfigured_ReturnsNull()
        {
            LogFactory logFactory = new LogFactory();
            BaseLogger logger = logFactory.CreateLogger(nameof(FileLogger));

            Assert.IsNull(logger);
        }

        [TestMethod]
        public void CreateLogger_Configured_ReturnsBaseLogger()
        {
            LogFactory loggerFactory = new LogFactory();
            loggerFactory.ConfigureFileLogger("test.path");
            BaseLogger logger = loggerFactory.CreateLogger(nameof(FileLogger));

            Assert.IsInstanceOfType(logger, typeof(BaseLogger));
        }
    }
}
