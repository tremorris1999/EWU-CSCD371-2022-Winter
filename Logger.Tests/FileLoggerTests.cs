using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_FileLogger()
        {
            string path = "test.path";
            File.Delete("test.path");
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(path);
            FileLogger logger = (FileLogger)logFactory.CreateLogger(nameof(FileLogger));
            logger.Log(LogLevel.Error, "test message");

            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            sr.Close();
            Assert.IsTrue(line.Contains("Error: test message"));
        }
    }
}
