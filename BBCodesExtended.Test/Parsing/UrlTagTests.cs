using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Web.Security.AntiXss;

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

        [TestMethod]
        public void Can_parse_url_tags_with_parameterized_url_single()
        {
            const string input = "We have a link to [url]http://www.website.example/?id=1337[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example/?id=1337\">http://www.website.example/?id=1337</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_url_tags_with_parameterized_url_multiple()
        {
            const string input = "We have a link to [url]http://www.website.example/?id=1337&second=2&third=3[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example/?id=1337&amp;second=2&amp;third=3\">http://www.website.example/?id=1337&amp;second=2&amp;third=3</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_url_tags_with_parameterized_url_with_html_param_encoded()
        {
            var parameterValue = "<b>tricky</b>";

            //var parameterEscaped = WebUtility.UrlEncode(parameterValue);
            
            var parameterEscaped = AntiXssEncoder.UrlEncode(parameterValue);
            var url = "http://www.website.example/?param=" + parameterEscaped;

            System.Diagnostics.Trace.WriteLine("URL = " + url);

            string input = "We have a link to [url]" + url + "[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example/?param=%3Cb%3Etricky%3C%2Fb%3E\">http://www.website.example/?param=%3Cb%3Etricky%3C%2Fb%3E</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_url_tags_with_parameterized_url_with_html_param_not_encoded()
        {
            var parameterValue = "<b>tricky</b>";
            var url = "http://www.website.example/?param=" + parameterValue;

            System.Diagnostics.Trace.WriteLine("URL = " + url);

            string input = "We have a link to [url]" + url + "[/url].";
            const string expected = "We have a link to <a href=\"http://www.website.example/?param=&lt;b&gt;tricky&lt;/b&gt;\">http://www.website.example/?param=&lt;b&gt;tricky&lt;/b&gt;</a>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }



        //http://www.website.example/?param=&lt;b&gt;tricky&lt;/b&gt;
    }
}
