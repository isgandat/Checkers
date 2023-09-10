using CheckersMinimax.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;

namespace CheckersMinimax
{
    public class SimpleLogger
    {
        private static readonly Settings Settings = Settings.Default;
        private static readonly object Lock = new object();
        private static SimpleLogger instance;

        private readonly string datetimeFormat;

        // Gets or sets the filename.
       
        public string Filename { get; set; }

        // Gets the simple logger instance
        // returns=singleton instance of the simple logger
        public static SimpleLogger GetSimpleLogger()
        {
            if (instance == null)
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new SimpleLogger(true);
                    }
                }
            }

            return instance;
        }

        // Log a debug message
        // <param name="text">Message to write</param>
        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.DEBUG, text);
        }

        // Log an error message
        // <param name="text">Message to write</param>
        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
        }

        
        /// Log a fatal error message

        /// <param name="text">Message to write</param>
        public void Fatal(string text)
        {
            WriteFormattedLog(LogLevel.FATAL, text);
        }

        
        /// Log an info message

        /// <param name="text">Message to write</param>
        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }

        
        /// Log a trace message

        /// <param name="text">Message to write</param>
        public void Trace(string text)
        {
            WriteFormattedLog(LogLevel.TRACE, text);
        }

        
        /// Log a waning message

        /// <param name="text">Message to write</param>
        public void Warning(string text)
        {
            WriteFormattedLog(LogLevel.WARNING, text);
        }

        
        /// Initialize a new instance of SimpleLogger class.
        /// Log file will be created automatically if not yet exists, else it can be either a fresh new file or append to the existing file.
        /// Default is create a fresh new log file.

        /// <param name="append">True to append to existing log file, False to overwrite and create new log file</param>
        private SimpleLogger(bool append = false)
        {
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            Filename = FileNameHelper.GetExecutingDirectory() + Assembly.GetExecutingAssembly().GetName().Name + "_" + GetCurrentDateString() + ".log";

            // Log file header line
            string logHeader = Filename + " is created.";
            if (!File.Exists(Filename))
            {
                WriteLine(DateTime.Now.ToString(datetimeFormat) + " " + logHeader, false);
            }
            else
            {
                if (append == false)
                {
                    WriteLine(DateTime.Now.ToString(datetimeFormat) + " " + logHeader, false);
                }
            }
        }

        
        /// Gets the current date string.

        /// returns= Current date string
        private string GetCurrentDateString()
        {
            return DateTime.Now.ToShortDateString().Replace("/", "_");
        }

        
        /// Format a log message based on log level

        /// <param name="level">Log level</param>
        /// <param name="text">Log message</param>
        private void WriteFormattedLog(LogLevel level, string text)
        {
            if ((int)level < Settings.MinimumLogLevel)
            {
                return;
            }

            string pretext;
            switch (level)
            {
                case LogLevel.TRACE:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [TRACE]   ";
                    break;
                case LogLevel.INFO:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [INFO]    ";
                    break;
                case LogLevel.DEBUG:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [DEBUG]   ";
                    break;
                case LogLevel.WARNING:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [WARNING] ";
                    break;
                case LogLevel.ERROR:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [ERROR]   ";
                    break;
                case LogLevel.FATAL:
                    pretext = DateTime.Now.ToString(datetimeFormat) + " [FATAL]   ";
                    break;
                default:
                    pretext = string.Empty;
                    break;
            }

            WriteLine(pretext + text);
        }

        
        /// Write a line of formatted log message into a log file. If a failure happens when logging, this method silently fails

        /// <param name="text">Formatted log message</param>
        /// <param name="append">True to append, False to overwrite the file</param>
        private void WriteLine(string text, bool append = true)
        {
            lock (Lock)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(Filename, append, Encoding.UTF8))
                    {
                        if (text != string.Empty)
                        {
                            writer.WriteLine(text);
                            Console.WriteLine(text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error saving the log file: " + ex.Message);
                }
            }
        }

        
        /// Supported log level

        [Serializable]
        private enum LogLevel
        {
            TRACE = 0,
            DEBUG = 1,
            INFO = 2,
            WARNING = 3,
            ERROR = 4,
            FATAL = 5
        }
    }
}
