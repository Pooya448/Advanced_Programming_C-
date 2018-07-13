using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class CsvLogFormatter : XsvFormatter
    {
        private CsvLogFormatter() : base (',') { }

        private static CsvLogFormatter _Instance;

        public static CsvLogFormatter Instance => _Instance ?? (_Instance = new CsvLogFormatter());

    }
}
