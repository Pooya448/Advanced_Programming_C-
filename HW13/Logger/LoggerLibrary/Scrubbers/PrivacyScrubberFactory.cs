namespace Logger
{
    public static class PrivacyScrubberFactory
    {
        public static IPrivacyScrubber ScrubOnlyNumbers() => new PrivacyScrubber(
               PhoneNumberScrubber.Instance,
               IDScrubber.Instance,
               CCScrubber.Instance
           );

        public static IPrivacyScrubber ScrubOnlyLetters() => new PrivacyScrubber(
               FullNameScrubber.Instance,
               EmailScrubber.Instance
           );

        public static IPrivacyScrubber ScrubAll() => new PrivacyScrubber(
                PhoneNumberScrubber.Instance,
                IDScrubber.Instance,
                FullNameScrubber.Instance,
                CCScrubber.Instance,
                EmailScrubber.Instance
            );
    }
}