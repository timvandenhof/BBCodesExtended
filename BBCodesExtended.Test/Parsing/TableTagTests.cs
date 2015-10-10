using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class TableTagTests
    {
        [TestMethod]
        public void Can_parse_nested_table_tags_with_items()
        {
            const string input = "The following text has a table [table][tr][th]header 1[/th][th]header 2[/th][/tr][tr][td]data 1.1[/td][td]data 2.1[/td][/tr][tr][td]data 1.2[/td][td]data 2.2[/td][/tr][/table] to it.";
            const string expected = "The following text has a table <table><tr><th>header 1</th><th>header 2</th></tr><tr><td>data 1.1</td><td>data 2.1</td></tr><tr><td>data 1.2</td><td>data 2.2</td></tr></table> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_table_tags_with_items_multiline()
        {
            const string input = @"The following text has a table
[table]
[tr]
[th]header 1[/th]
[th]header 2[/th]
[/tr]
[tr]
[td]data 1.1[/td]
[td]data 2.1[/td]
[/tr]
[tr]
[td]data 1.2[/td]
[td]data 2.2[/td]
[/tr]
[/table]
to it.";
            const string expected = @"The following text has a table<table><tr><th>header 1</th><th>header 2</th></tr><tr><td>data 1.1</td><td>data 2.1</td></tr><tr><td>data 1.2</td><td>data 2.2</td></tr></table>to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_table_tags()
        {
            const string input = "The following text has no [table][/table] table to it.";
            const string expected = "The following text has no  table to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
