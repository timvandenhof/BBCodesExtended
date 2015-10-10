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

        [TestMethod]
        public void Does_escape_email_tags_address_to_prevent_html_injection_in_body()
        {
            const string input = "The following text has an [email=email@mail.example]<strong>email@mail.example</strong>[/email] to it.";
            // XSS: The following text had an <a href=\"mailto:email@mail.example\"><strong>email@mail.example</strong></a> to it.";
            const string expected = "The following text has an <a href=\"mailto:email@mail.example\">&lt;strong&gt;email@mail.example&lt;/strong&gt;</a> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod] // Is no injection, just a strange html order
        public void Does_escape_email_tags_address_to_prevent_html_injection_in_body_using_bbcode()
        {
            const string input = "The following text has an [email=email@mail.example][b]email@mail.example[/b][/email] to it.";
            // XSS: The following text had an <a href=\"mailto:email@mail.example\"><b>email@mail.example</b></a> to it.";
            const string expected = "The following text has an <a href=\"mailto:email@mail.example\"><b>email@mail.example</b></a> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_escape_email_tags_address_to_prevent_html_injection_in_body_and_url_simple()
        {
            const string input = "The following text has an [email]<strong>email@mail.example</strong>[/email] to it.";
            // XSS: The following text has an <a href=\"mailto:<strong>email@mail.example</strong>\"><strong>email@mail.example</strong></a> to it.";
            const string expected = "The following text has an <a href=\"mailto:email@mail.example\">&lt;strong&gt;email@mail.example&lt;/strong&gt;</a> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_escape_email_tags_address_to_prevent_html_injection_in_url_simple()
        {
            const string input = "The following text has an [email=<strong>email@mail.example</strong>]email@mail.example[/email] to it.";
            // XSS: The following text has an <a href=\"mailto:<strong>email@mail.example</strong>\">email@mail.example</a> to it.";
            const string expected = "The following text has an <a href=\"mailto:email@mail.example\">email@mail.example</a> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Framework does not allow this kind of construction, throws parse exception in stead of escaping all the rubbish.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exceptions.BBCodeParseException))]
        public void Does_escape_email_tags_address_to_prevent_html_injection_using_attribute_bypass()
        {
            const string input = "The following text has an [email=email@mail.example\" style=\"color:red]email@mail.example[/email] to it.";
            // XSS: The following text has an <a href="mailto:email@mail.example" style="color:red">email@mail.example</a> to it.";
            //const string expected = "The following text has an <a href=\"mailto:email@mail.example\">email@mail.example</a> to it.";
            const string expectedMessage = "No node found for type 'email=email@mail.example\"'!";

            try
            {
                var actual = BBCode.Parse(input);
            }
            catch (Exceptions.BBCodeParseException parseEx)
            {

                Assert.AreEqual(expectedMessage, parseEx.Message);
                throw;
            }
        }

        /// <summary>
        /// Framework does not allow this kind of construction, throws parse exception in stead of escaping all the rubbish.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exceptions.BBCodeParseException))]
        public void Does_escape_email_tags_address_to_prevent_javascript_injection_using_attribute_bypass()
        {
            const string input = "The following text has an [email=email@mail.example\" onload=\"alert('xss');]email@mail.example[/email] to it.";
            // XSS: The following text has an <a href="mailto:email@mail.example" onload="alert('XSS');">email@mail.example</a> to it.";
            //const string expected = "The following text has an <a href=\"mailto:email@mail.example\">email@mail.example</a> to it.";
            const string expectedMessage = "No node found for type 'email=email@mail.example\"'!";

            try
            {
                var actual = BBCode.Parse(input);
            }
            catch (Exceptions.BBCodeParseException parseEx)
            {

                Assert.AreEqual(expectedMessage, parseEx.Message);
                throw;
            }
        }
    }
}
