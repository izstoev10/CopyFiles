using System;
using System.IO;

namespace DirectoryChange
{
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }
        public void LogInfo(string message)
        {
            using(var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
