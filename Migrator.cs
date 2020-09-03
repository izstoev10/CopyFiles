using System;
using System.IO; 

namespace DirectoryChange
{
    public class Migrator
    {
        private readonly ILogger _logger;

        public Migrator(ILogger logger)   
        {
            _logger = logger;
        }

        public void Migrate(string text)
        {
            _logger.LogInfo(text);
        }
    }
}
