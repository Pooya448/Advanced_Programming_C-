using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Logger
{
    public class CCScrubber : AbstractScrubber
    {
        public CCScrubber()
        {

        }

        private static CCScrubber _Instance;

        public static CCScrubber Instance => _Instance ?? (_Instance = new CCScrubber());

        /// <summary>
        /// Regular expression for ID:
        /// 521-32-1212
        /// \(?[0-9]{3}\)?[ -]*[0-9]{2}[ -]*[0-9]{4}
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"\d{16}|" + @"\(?[0-9]{4}\)?[ -]*[0-9]{4}[ -]*[0-9]{4}[ -]*[0-9]{4}");

        public override string Scrub(string content) => this.MaskPII(content, this.MaskNumbers);
    }
}
