using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class TableDataTagTests
    {
        [TestMethod]
        public void Can_parse_tabledata_tags()
        {
            const string input = "The following text has a [td]table data[/td] to it.";
            const string expected = "The following text has a <td>table data</td> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_tabledata_tags()
        {
            const string input = "The following text has multiple [td]table[/td][td]data[/td] to it.";
            const string expected = "The following text has multiple <td>table</td><td>data</td> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_tabledata_tags()
        {
            const string input = "The following text has nested [td]table [td]data[/td][/td] to it.";
            const string expected = "The following text has nested <td>table <td>data</td></td> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_keep_empty_tabledata_tags()
        {
            const string input = "The following text has empty [td][/td] table data to it.";
            const string expected = "The following text has empty <td></td> table data to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
