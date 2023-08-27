namespace Library.Test.Utilities.Test;

public class HtmlUtilitiesTest
{
    [Fact]
    [Trait("HTML", "Get Html Content From Url")]
    public void Should_Return_Html_Content_From_Url()
    {
        const string URL = "https://www.google.com.br/";

        var responde = HtmlUtilities.ReturnHtmlContentFromUrl(URL);

        responde.Should().NotBeNull();
        responde.Should().NotBeEmpty();
        responde.Should().Contain("<!doctype html>");
        responde.Should().Contain("<body");
        responde.Should().Contain("</body>");
        responde.Should().Contain("</html>");
    }
    
    [Fact]
    [Trait("HTML", "Get Html Content From Url")]
    public void Should_Return_False_From_Broked_Url()
    {
        const string URL = "www.gooooooogle";

        var responde = HtmlUtilities.ReturnHtmlContentFromUrl(URL);

        responde.Should().NotBeNull();
        responde.Should().BeEmpty();
        responde.Should().NotContain("<!doctype html>");
        responde.Should().NotContain("<body");
        responde.Should().NotContain("</body>");
        responde.Should().NotContain("</html>");
    }
}