using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
                throw new ArgumentNullException("Logger is null");
            logger.Log(LogLevel.Error, String.Format(message, args));
        }

        public static void Warning(this BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
                throw new ArgumentNullException("Logger is null");
            logger.Log(LogLevel.Warning, String.Format(message, args));
        }

        public static void Information(this BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
                throw new ArgumentNullException("Logger is null");
            logger.Log(LogLevel.Information, String.Format(message, args));
        }


        public static void Debug(this BaseLogger logger, string message, params object[] args)
        {
            if (logger == null)
                throw new ArgumentNullException("Logger is null");
            logger.Log(LogLevel.Debug, String.Format(message, args));
        }
    }
}
