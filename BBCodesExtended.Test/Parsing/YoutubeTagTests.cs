using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class YoutubeTagTests
    {
        [TestMethod]
        public void Can_parse_youtube_tags()
        {
            const string input = "The following text has a youtube video [youtube]QH2-TGUlwu4[/youtube] in it.";
            const string expected = "The following text has a youtube video <iframe width=\"420\" height=\"315\" src=\"http://youtube.com/embed/QH2-TGUlwu4\" frameborder=\"0\" allowfullscreen></iframe> in it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_youtube_tags()
        {
            const string input = "The following text has multiple youtube videos [youtube]QH2-TGUlwu4[/youtube][youtube]jI-kpVh6e1U[/youtube] in it.";
            const string expected = "The following text has multiple youtube videos <iframe width=\"420\" height=\"315\" src=\"http://youtube.com/embed/QH2-TGUlwu4\" frameborder=\"0\" allowfullscreen></iframe><iframe width=\"420\" height=\"315\" src=\"http://youtube.com/embed/jI-kpVh6e1U\" frameborder=\"0\" allowfullscreen></iframe> in it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_youtube_tags()
        {
            const string input = "The following text has empty [youtube][/youtube] youtube video to it.";
            const string expected = "The following text has empty  youtube video to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_nested_youtube_tags()
        {
            const string input = "The following text has nested youtube videos [youtube]QH2-TGUlwu4[youtube]QH2-TGUlwu4[/youtube][/youtube] in it.";
            const string expected = "The following text has nested youtube videos <iframe width=\"420\" height=\"315\" src=\"http://youtube.com/embed/QH2-TGUlwu4\" frameborder=\"0\" allowfullscreen></iframe> in it."; // Only the first one is rendered

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
