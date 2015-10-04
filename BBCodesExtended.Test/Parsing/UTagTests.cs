using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class UTagTests
    {
        [TestMethod]
        public void Can_parse_u_tags()
        {
            const string input = "The following text has a [u]underline style[/u] to it.";
            const string expected = "The following text has a <u>underline style</u> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_u_tags()
        {
            const string input = "The following text has a [u]underline style[/u] to [u]it[/u].";
            const string expected = "The following text has a <u>underline style</u> to <u>it</u>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_u_tags()
        {
            const string input = "The following text has a [u][u]extra[/u] underline style[/u] to it.";
            const string expected = "The following text has a <u><u>extra</u> underline style</u> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_u_tags()
        {
            const string input = "The following text has no [u][/u] underline style to it.";
            const string expected = "The following text has no  underline style to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
