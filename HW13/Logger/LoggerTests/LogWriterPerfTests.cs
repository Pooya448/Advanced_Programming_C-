using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Logger.Tests
{
    [TestClass()]
    public class LogWriterPerfTests
    {
        /// <summary>
        /// Table of Times
        /// Locked          Concurrent          Locked Queue            No. of Threads
        /// "0.5597012"     "0.8561135"         "0.4664703"             1
        /// "0.6662706"     "0.5401509"         "0.6473057"             2
        /// "1.3060879"     "0.7964175"         "0.8557244"             5
        /// "3.0602316"     "1.6961902"         "1.4950606"             10
        /// "8.554043"      "3.7672149"         "3.7787247"             20
        /// "50.0491141"    "6.4110072"         "6.4398484"             50
        /// "176.5547765"   "14.0700345"        "14.2237124"            100
        /// 
        /// Concurrent log writer uses threads and multi threading with a ConcurrentQueue to maximum the performance by using multiple threads of cpu at once
        /// 
        /// 
        /// </summary>

        [TestMethod()]
        public void LockedLogWriterPerfTest()
        {
            var time = PerfTest<LockedLogWriter>(threadCount:25, linePerThread:1000);
        }

        [TestMethod()]
        public void ConcurrentLogWriterPerfTest()
        {
            var time = PerfTest<ConcurrentLogWriter>(threadCount: 25, linePerThread: 1000);
        }

        [TestMethod()]
        public void LockedQueueLogWriterPerfTest()
        {
            var time = PerfTest<LockedQueuetLogWriter>(threadCount: 100, linePerThread: 1000);
        }


        // methode estefade shode dar in test thread-safe nist, baraye hamin test failed mishe chonke chanta thread hamzaman data exchange mikonand bedune hich lock ii
        //[TestMethod()]
        //public void NoLockPerfTest()
        //{
        //    var time = PerfTest<NoLockLogWriter>(threadCount: 25, linePerThread: 1000);
        //}

        private string PerfTest<_LogWriter>(int threadCount, int linePerThread)
            where _LogWriter: GuardedLogWriter, new()
        {
            string logDir = Path.GetTempFileName();
            File.Delete(logDir);
            string logPrefix = "sauleh_all";
            string time = string.Empty;
            using (FileLogger<_LogWriter> logger = new FileLogger<_LogWriter>(
                    XmlLogFormatter.Instance,
                    new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                    new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
                    LogLevels.All,
                    LogSources.All,
                    false))
            {
                var threads = Enumerable.Range(0, threadCount)
                                        .Select(n => new Thread(
                                            new ThreadStart(() => LogRandomMessages(linePerThread, logger))))
                                        .ToList();

                Stopwatch sw = Stopwatch.StartNew();
                threads.ForEach(t => t.Start());
                threads.ForEach(t => t.Join());
                sw.Stop();

                time = sw.Elapsed.TotalSeconds.ToString();
                
            }

            int actualLogLines = CountLogLines(logDir, pattern: $"{logPrefix}*.{XmlLogFormatter.Instance.FileExtention}");

            Assert.AreEqual(linePerThread * threadCount + 2, actualLogLines); // plus 2 for header and footer

            return time;
        }

        private int CountLogLines(string logDir, string pattern)
        {
            return Directory.GetFiles(logDir, pattern).Sum(f => File.ReadAllLines(f).Length);
        }

        private void LogRandomMessages(int count, ILogger logger)
        {
            for (int i=0; i<count; i++)
            {
                LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                    $"student {i} created", ("FirstName", $"Pegah_{i}"), ("LastName", $"Ayati_{i}"));
                logger.Log(logEntry);
            }
        }
    }
}