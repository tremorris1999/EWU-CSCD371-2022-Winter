namespace Logger
{
    public class LogFactory
    {
        private string? path;
        public BaseLogger CreateLogger(string className)
        {
            if (className == null)
                return null!;

            else if (className.CompareTo("FileLogger") == 0)
            {
                if (path == null)
                    return null!;

                return new FileLogger(path);
            }

            else
                return null!;
        }
        
        public void ConfigureFileLogger(string path)
        {
            this.path = path;
        }
    }
}
