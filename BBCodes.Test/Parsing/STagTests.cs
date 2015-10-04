using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodes.Parsing.Test
{
    [TestClass]
    public class STagTests
    {
        [TestMethod]
        public void Can_parse_s_tags()
        {
            const string input = "The following text has a [s]strikethrough style[/s] to it.";
            const string expected = "The following text has a <s>strikethrough style</s> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_s_tags()
        {
            const string input = "The following text has a [s]strikethrough style[/s] to [s]it[/s].";
            const string expected = "The following text has a <s>strikethrough style</s> to <s>it</s>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_s_tags()
        {
            const string input = "The following text has a [s][s]extra[/s] strikethrough style[/s] to it.";
            const string expected = "The following text has a <s><s>extra</s> strikethrough style</s> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_s_tags()
        {
            const string input = "The following text has no [s][/s] strikethrough style to it.";
            const string expected = "The following text has no  strikethrough style to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
