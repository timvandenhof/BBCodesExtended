using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BBCodesExtended.Parsing.Test
{
    [TestClass]
    public class ImageTagTests
    {
        [TestMethod]
        public void Can_parse_image_tags()
        {
            const string input = "The following text contains an image: [img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_image_tags_with_width_and_height_combined()
        {
            const string input = "The following text contains an image: [img=272x92]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" width=\"272\" height=\"92\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_image_tags_with_width_and_height_seperate()
        {
            const string input = "The following text contains an image: [img width=272 height=92]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" width=\"272\" height=\"92\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_parse_multiple_image_tags()
        {
            const string input = "The following text contains an image: [img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img] and another one: [img]https://fake.url/logo.png[/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" /> and another one: <img src=\"https://fake.url/logo.png\" alt=\"https://fake.url/logo.png\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Nested image tags, should only take the url and skip other child nodes to prevent HTML corruption 
        /// due to child tags being rendered inside the url and alt.
        /// </summary>
        [TestMethod]
        public void Does_skip_nested_image_tags()
        {
            const string input = "The following text contains an image: [img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[img]https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png[/img][/img].";
            const string expected = "The following text contains an image: <img src=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" alt=\"https://www.google.nl/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png\" />.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_skip_empty_image_tags()
        {
            const string input = "The following text contains an empty image: [img][/img].";
            const string expected = "The following text contains an empty image: .";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_escape_image_tags_url_to_prevent_html_injection_in_body_simple()
        {
            const string input = "The following text has an image [img]<b>http://website.example/picture.png</b>[/img] to it.";
            // XSS: The following text had an image <img src="<b>http://website.example/picture.png</b>" alt="<b>http://website.example/picture.png</b>" /> to it.";
            const string expected = "The following text has an image <img src=\"&lt;b&gt;http://website.example/picture.png&lt;/b&gt;\" alt=\"&lt;b&gt;http://website.example/picture.png&lt;/b&gt;\" /> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Does_escape_image_tags_url_to_prevent_html_injection_in_body_simple_using_bbcode()
        {
            const string input = "The following text has an image [img][b]http://website.example/picture.png[/b][/img] to it.";
            // XSS: The following text had an image <img src="<b>http://website.example/picture.png</b>" alt="<b>http://website.example/picture.png</b>" /> to it.";
            const string expected = "The following text has an image <img src=\"&lt;b&gt;http://website.example/picture.png&lt;/b&gt;\" alt=\"&lt;b&gt;http://website.example/picture.png&lt;/b&gt;\" /> to it.";

            var actual = BBCode.Parse(input);

            Assert.AreEqual(expected, actual);
        }



        //[TestMethod]
        //public void Does_escape_email_tags_address_to_prevent_html_injection_in_body_and_url_simple()
        //{
        //    const string input = "The following text has an [email]<strong>email@mail.example</strong>[/email] to it.";
        //    // XSS: The following text has an <a href=\"mailto:<strong>email@mail.example</strong>\"><strong>email@mail.example</strong></a> to it.";
        //    const string expected = "The following text has an <a href=\"mailto:&lt;strong&gt;email@mail.example&lt;/strong&gt;\">&lt;strong&gt;email@mail.example&lt;/strong&gt;</a> to it.";

        //    var actual = BBCode.Parse(input);

        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Does_escape_email_tags_address_to_prevent_html_injection_in_url_simple()
        //{
        //    const string input = "The following text has an [email=<strong>email@mail.example</strong>]email@mail.example[/email] to it.";
        //    // XSS: The following text has an <a href=\"mailto:<strong>email@mail.example</strong>\">email@mail.example</a> to it.";
        //    const string expected = "The following text has an <a href=\"mailto:&lt;strong&gt;email@mail.example&lt;/strong&gt;\">email@mail.example</a> to it.";

        //    var actual = BBCode.Parse(input);

        //    Assert.AreEqual(expected, actual);
        //}

        ///// <summary>
        ///// Framework does not allow this kind of construction, throws parse exception in stead of escaping all the rubbish.
        ///// </summary>
        //[TestMethod]
        //[ExpectedException(typeof(Exceptions.BBCodeParseException))]
        //public void Does_escape_email_tags_address_to_prevent_html_injection_using_attribute_bypass()
        //{
        //    const string input = "The following text has an [email=email@mail.example\" style=\"color:red]email@mail.example[/email] to it.";
        //    // XSS: The following text has an <a href="mailto:email@mail.example" style="color:red">email@mail.example</a> to it.";
        //    //const string expected = "The following text has an <a href=\"mailto:email@mail.example\">email@mail.example</a> to it.";
        //    const string expectedMessage = "No node found for type 'email=email@mail.example\"'!";

        //    try
        //    {
        //        var actual = BBCode.Parse(input);
        //    }
        //    catch (Exceptions.BBCodeParseException parseEx)
        //    {

        //        Assert.AreEqual(expectedMessage, parseEx.Message);
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Framework does not allow this kind of construction, throws parse exception in stead of escaping all the rubbish.
        ///// </summary>
        //[TestMethod]
        //[ExpectedException(typeof(Exceptions.BBCodeParseException))]
        //public void Does_escape_email_tags_address_to_prevent_javascript_injection_using_attribute_bypass()
        //{
        //    const string input = "The following text has an [email=email@mail.example\" onload=\"alert('xss');]email@mail.example[/email] to it.";
        //    // XSS: The following text has an <a href="mailto:email@mail.example" onload="alert('XSS');">email@mail.example</a> to it.";
        //    //const string expected = "The following text has an <a href=\"mailto:email@mail.example\">email@mail.example</a> to it.";
        //    const string expectedMessage = "No node found for type 'email=email@mail.example\"'!";

        //    try
        //    {
        //        var actual = BBCode.Parse(input);
        //    }
        //    catch (Exceptions.BBCodeParseException parseEx)
        //    {

        //        Assert.AreEqual(expectedMessage, parseEx.Message);
        //        throw;
        //    }
        //}
    }
}
