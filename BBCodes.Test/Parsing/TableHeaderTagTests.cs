using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodes.Parsing.Test
{
    [TestClass]
    public class TableHeaderTagTests
    {
        [TestMethod]
        public void Can_parse_tableheader_tags()
        {
            const string input = "The following text has a [th]table header[/th] to it.";
            const string expected = "The following text has a <th>table header</th> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_tableheader_tags()
        {
            const string input = "The following text has multiple [th]table[/th][th]header[/th] to it.";
            const string expected = "The following text has multiple <th>table</th><th>header</th> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_tableheader_tags()
        {
            const string input = "The following text has nested [th]table [th]header[/th][/th] to it.";
            const string expected = "The following text has nested <th>table <th>header</th></th> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_keep_empty_tableheader_tags()
        {
            const string input = "The following text has empty [th][/th] table header to it.";
            const string expected = "The following text has empty <th></th> table header to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
