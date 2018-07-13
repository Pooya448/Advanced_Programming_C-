using System;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTest
{
    [TestClass]
    public class PrivacyScrubberTest 
    {
        [TestMethod]
        public void SinglePhoneNumberTest()
        {
            string piiNum = "(517)303-5279";
            string scrubbedPII = "(XXX)XXX-XXXX";
            string testString = $"My phone number is {piiNum}";
            string scrubbedString = $"My phone number is {scrubbedPII}";
            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void MultiplePhoneNumbersTest()
        {
            string pii1 = "(517)303-5279";
            string pii2 = "206-323-1212";
            string scrubbedPII1 = "(XXX)XXX-XXXX";
            string scrubbedPII2 = "XXX-XXX-XXXX";
            string testString = $"My phone number was {pii1} but it is {pii2} now";
            string scrubbedString = $"My phone number was {scrubbedPII1} but it is {scrubbedPII2} now";

            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void IDTest()
        {
            string testString = "Ali's SSN is  432-12-3232";
            string expectedString = "Ali's SSN is  XXX-XX-XXXX";

            string testStringIr = "Ali's SSN is  127-295625-3";
            string expectedStringIr = "Ali's SSN is  XXX-XXXXXX-X";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            string scrubbedStringIr = IDScrubber.Instance.Scrub(testStringIr);

            Assert.AreEqual(expectedStringIr, scrubbedStringIr);
            Assert.AreEqual(expectedString,scrubbedString);

        }
        // email test added
        [TestMethod]
        public void EmailTest()
        {
            string testString = "Ali's Email is  ali_test@gmail.com";
            string expectedString = "Ali's Email is  xxx_xxxx@xxxxx.xxx";

            string scrubbedString = EmailScrubber.Instance.Scrub(testString);

            Assert.AreEqual(expectedString, scrubbedString);
        }
        // cc test added
        [TestMethod]
        public void CCTest()
        {
            string testString = "Ali's CC is  1234567891234567 and 1234-1223-1234-1234";
            string expectedString = "Ali's CC is  XXXXXXXXXXXXXXXX and XXXX-XXXX-XXXX-XXXX";

            string scrubbedString = CCScrubber.Instance.Scrub(testString);

            Assert.AreEqual(expectedString, scrubbedString);
        }

        [TestMethod]
        public void FullNameTest()
        {
            string testString = "Mr. Bill Gates failed the exam.";
            string expectedString = "Xx. Xxxx Xxxxx failed the exam.";

            string maskedString = FullNameScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }


    }

}
