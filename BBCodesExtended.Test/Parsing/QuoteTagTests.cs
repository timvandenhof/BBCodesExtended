using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class QuoteTagTests
    {
        [TestMethod]
        public void Can_parse_quote_tags()
        {
            const string input = "The following text [quote]is a single line quote.[/quote] from someone else.";
            const string expected = "The following text <blockquote>is a single line quote.</blockquote> from someone else.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_quote_tags_with_name()
        {
            const string input = "The following text [quote=someone]is a single line quote.[/quote] from someone else.";
            const string expected = "The following text <blockquote cite=\"someone\">is a single line quote.</blockquote> from someone else.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_quote_tags()
        {
            const string input = "The following text [quote]is a single line quote.[/quote] from someone else. [quote]Says someone...[/quote]";
            const string expected = "The following text <blockquote>is a single line quote.</blockquote> from someone else. <blockquote>Says someone...</blockquote>";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_quote_tags()
        {
            const string input = "The following text [quote]is a single line quote.[quote]With another quote inside.[/quote]Madness![/quote] For sure.";
            const string expected = "The following text <blockquote>is a single line quote.<blockquote>With another quote inside.</blockquote>Madness!</blockquote> For sure.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_quote_tags()
        {
            const string input = "The following text has no [quote][/quote] quote to it.";
            const string expected = "The following text has no  quote to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
