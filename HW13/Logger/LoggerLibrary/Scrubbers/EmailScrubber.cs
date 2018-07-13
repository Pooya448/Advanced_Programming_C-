using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Logger
{
    public class EmailScrubber : AbstractScrubber
    {
        private EmailScrubber() { }

        private static EmailScrubber _Instance;

        public static EmailScrubber Instance => _Instance ?? (_Instance = new EmailScrubber());

        /// <summary>
        /// Regular expression for Email:
        /// pooya_kabiri@yahoo.com
        /// </summary>
        protected override Regex PIIRegEx => new Regex(Pattern);

        private string Pattern = @"\w*\@\w*\.com";

        public override string Scrub(string content) => this.MaskPII(content, this.MaskLetters);
    }
}
