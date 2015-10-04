using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class EmailTagTests
    {
        [TestMethod]
        public void Can_parse_email_tags()
        {
            const string input = "We have an email link to [email]info@website.example[/email].";
            const string expected = "We have an email link to <a href=\"mailto:info@website.example\">info@website.example</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_email_tags_with_text()
        {
            const string input = "We have an email link to [email=info@website.example]here[/email].";
            const string expected = "We have an email link to <a href=\"mailto:info@website.example\">here</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_email_tags()
        {
            const string input = "We have an email link to [email=info@website.example]here[/email] and another one [email=contact@website.example]over here[/email].";
            const string expected = "We have an email link to <a href=\"mailto:info@website.example\">here</a> and another one <a href=\"mailto:contact@website.example\">over here</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_email_tags()
        {
            const string input = "We have an email link to [email=info@website.example]here [email=contact@website.example]with this subemail[/email][/email].";
            const string expected = "We have an email link to <a href=\"mailto:info@website.example\">here <a href=\"mailto:contact@website.example\">with this subemail</a></a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_email_tags()
        {
            const string input = "The following text has no [email][/email] email to it.";
            const string expected = "The following text has no  email to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
