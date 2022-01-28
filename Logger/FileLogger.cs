using System.IO;
using System;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string path;

        public FileLogger(string path)
        {
            this.path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            DateTimeOffset dt = DateTimeOffset.Now;
            StreamWriter file = new StreamWriter(this.path, append: true);
            file.WriteLine(dt.ToString("g") + " " + this.ClassName + " " + logLevel + ": " + message);
            file.Close();
        }
    }
}