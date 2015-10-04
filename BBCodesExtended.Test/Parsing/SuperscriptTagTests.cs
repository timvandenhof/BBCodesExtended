using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class SuperscriptTagTests
    {
        [TestMethod]
        public void Can_parse_superscript_tags()
        {
            const string input = "The following text has a [sup]superscript style[/sup] to it.";
            const string expected = "The following text has a <sup>superscript style</sup> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_superscript_tags()
        {
            const string input = "The following text has a [sup]superscript style[/sup] to [sup]it[/sup].";
            const string expected = "The following text has a <sup>superscript style</sup> to <sup>it</sup>.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_nested_superscript_tags()
        {
            const string input = "The following text has a [sup][sup]extra[/sup] superscript style[/sup] to it.";
            const string expected = "The following text has a <sup><sup>extra</sup> superscript style</sup> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_superscript_tags()
        {
            const string input = "The following text has no [sup][/sup] superscript style to it.";
            const string expected = "The following text has no  superscript style to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
