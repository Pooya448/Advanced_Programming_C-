using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class WeekDayLogFileName : LogFileNamePolicy
    {
        public WeekDayLogFileName(string logDir, string logPrefix, string logExt) : base (logDir,logPrefix,logExt)
        {

        }
        public override string NextFileName()
            => Path.Combine(LogDir, $"{LogPrefix}_{DateTime.Today.DayOfWeek.ToString()}.{LogExt}");
    }
}
