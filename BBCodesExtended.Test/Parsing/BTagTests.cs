using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class BTagTests
    {
        [TestMethod]
        public void Can_parse_b_tags()
        {
            const string input = "The following text has a [b]bold style[/b] to it.";
            const string expected = "The following text has a <b>bold style</b> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_b_tags()
        {
            const string input = "The following text has a [b]bold style[/b] to [b]it[/b].";
            const string expected = "The following text has a <b>bold style</b> to <b>it</b>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_b_tags()
        {
            const string input = "The following text has a [b][b]extra[/b] bold style[/b] to it.";
            const string expected = "The following text has a <b><b>extra</b> bold style</b> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_b_tags()
        {
            const string input = "The following text has no [b][/b] bold style to it.";
            const string expected = "The following text has no  bold style to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
