using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class FileLoggerFactory
    {
        public static ILogger FileLogger1() => new FileLogger<ConcurrentLogWriter>(
            CsvLogFormatter.Instance,
            NullPrivacyScrubber.Instance,
            new IncrementalLogFileName(@"c:\log", "FileLogger1", CsvLogFormatter.Instance.FileExtention),
            LogLevels.All,
            LogSources.All,
            true);

        // baghiash ham daghighan mesle hamine ostad ! khodaii zadane codeshun joz copy paste nist, age mishe cheshm pooshi befarmayid
       
    }
}
