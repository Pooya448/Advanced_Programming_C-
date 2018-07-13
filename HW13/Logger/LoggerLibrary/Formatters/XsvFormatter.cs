using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class XsvFormatter : ILogFormatter
    {
        public XsvFormatter(char delimiter)
        {
            this.Delimiter = delimiter;
        }
        protected char Delimiter;

        public string Header => $"level{this.Delimiter}date{this.Delimiter}source{this.Delimiter}threadId{this.Delimiter}ProcessId{this.Delimiter}message{this.Delimiter}name:value pairs";

        public string Footer => string.Empty;

        public string FileExtention => "log";

        public string Format(LogEntry entry)
        {
            return $"{entry.Level.ToString()}{this.Delimiter}{entry.DateTime.ToString()}{this.Delimiter}{entry.Source.ToString()}{this.Delimiter}" +
                   $"{entry.ThreadId.ToString()}{this.Delimiter}{entry.ProcessId}{this.Delimiter}{entry.Message}{this.Delimiter}" +
                    string.Join($"{this.Delimiter}", entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'"));
        }
    }
}
