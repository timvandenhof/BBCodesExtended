using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class SubscriptTagTests
    {
        [TestMethod]
        public void Can_parse_subscript_tags()
        {
            const string input = "The following text has a [sub]subscript style[/sub] to it.";
            const string expected = "The following text has a <sub>subscript style</sub> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_subscript_tags()
        {
            const string input = "The following text has a [sub]subscript style[/sub] to [sub]it[/sub].";
            const string expected = "The following text has a <sub>subscript style</sub> to <sub>it</sub>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_subscript_tags()
        {
            const string input = "The following text has a [sub][sub]extra[/sub] subscript style[/sub] to it.";
            const string expected = "The following text has a <sub><sub>extra</sub> subscript style</sub> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_subscript_tags()
        {
            const string input = "The following text has no [sub][/sub] subscript style to it.";
            const string expected = "The following text has no  subscript style to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
