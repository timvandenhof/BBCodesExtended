using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Test
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void Can_parse_text()
        {
            const string input = "The following text is just plain text.";
            const string expected = "The following text is just plain text.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_escape_HTML_in_text()
        {
            const string input = "The following text is <b>just plain text</b>.";
            const string expected = "The following text is &lt;b&gt;just plain text&lt;/b&gt;.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_escape_javascript_in_text()
        {
            const string input = "The following text is <script>alert();</script> just plain text.";
            const string expected = "The following text is &lt;script&gt;alert();&lt;/script&gt; just plain text.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_not_convert_newline_to_html_newlines_in_text()
        {
            const string input = @"The following text is on 
two separate lines.";// there is a space after on
            const string expected = "The following text is on two separate lines.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_not_convert_newline_to_html_newlines_in_text_extended()
        {
            const string input = @"The following text is on one
two
three
four separate lines.";// no spaces after them
            const string expected = "The following text is on onetwothreefour separate lines.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
