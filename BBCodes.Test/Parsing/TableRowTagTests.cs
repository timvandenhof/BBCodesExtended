using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodes.Parsing.Test
{
    [TestClass]
    public class TableRowTagTests
    {
        [TestMethod]
        public void Can_parse_tablerow_tags()
        {
            const string input = "The following text has a [tr]table row[/tr] to it.";
            const string expected = "The following text has a <tr>table row</tr> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_tablerow_tags()
        {
            const string input = "The following text has multiple [tr]table[/tr][tr]rows[/tr] to it.";
            const string expected = "The following text has multiple <tr>table</tr><tr>rows</tr> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_tablerow_tags()
        {
            const string input = "The following text has nested [tr]table [tr]rows[/tr][/tr] to it.";
            const string expected = "The following text has nested <tr>table <tr>rows</tr></tr> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_keep_empty_tablerow_tags()
        {
            const string input = "The following text has empty [tr][/tr] table row to it.";
            const string expected = "The following text has empty <tr></tr> table row to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
