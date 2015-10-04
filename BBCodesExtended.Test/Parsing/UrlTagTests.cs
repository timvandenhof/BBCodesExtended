using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class UrlTagTests
    {
        [TestMethod]
        public void Can_parse_url_tags()
        {
            const string input = "We have a link to [url]http://www.website.example[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">http://www.website.example</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_link_tags()
        {
            const string input = "We have a link to [link]http://www.website.example[/link].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">http://www.website.example</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_url_tags_with_text()
        {
            const string input = "We have a link to [url=http://www.website.example]here[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">here</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_link_tags_with_text()
        {
            const string input = "We have a link to [link=http://www.website.example]here[/link].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">here</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_url_tags()
        {
            const string input = "We have a link to [url=http://www.website.example]here[/url] or [url=http://other.website.example]maybe here[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">here</a> or <a href=\"http://other.website.example\">maybe here</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_link_tags()
        {
            const string input = "We have a link to [link=http://www.website.example]here[/link] or [link=http://other.website.example]maybe here[/link].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">here</a> or <a href=\"http://other.website.example\">maybe here</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_url_tags()
        {
            const string input = "We have a link to [url=http://www.website.example]here or [url=http://other.website.example]maybe here[/url]?[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">here or <a href=\"http://other.website.example\">maybe here</a>?</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_link_tags()
        {
            const string input = "We have a link to [link=http://www.website.example]here or [link=http://other.website.example]maybe here[/link]?[/link].";
            const string expected = "We have a link to <a href=\"http://www.website.example\">here or <a href=\"http://other.website.example\">maybe here</a>?</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_url_tags()
        {
            const string input = "The following text has no [url][/url] url to it.";
            const string expected = "The following text has no  url to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_link_tags()
        {
            const string input = "The following text has no [link][/link] link to it.";
            const string expected = "The following text has no  link to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
