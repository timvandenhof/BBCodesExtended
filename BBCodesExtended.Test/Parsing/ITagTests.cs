using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class ITagTests
    {
        [TestMethod]
        public void Can_parse_i_tags()
        {
            const string input = "The following text has a [i]italic style[/i] to it.";
            const string expected = "The following text has a <i>italic style</i> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_i_tags()
        {
            const string input = "The following text has a [i]italic style[/i] to [i]it[/i].";
            const string expected = "The following text has a <i>italic style</i> to <i>it</i>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_i_tags()
        {
            const string input = "The following text has a [i][i]extra[/i] italic style[/i] to it.";
            const string expected = "The following text has a <i><i>extra</i> italic style</i> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_i_tags()
        {
            const string input = "The following text has no [i][/i] italic style to it.";
            const string expected = "The following text has no  italic style to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
