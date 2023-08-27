using Library.Extensions;

namespace Library.Test.Extensions.Test;

public class StringExtensionTest
{
    [Fact]
    [Trait("Strings", "IsEqual = False")]
    public void Should_Return_False_When_String_Equals()
    {
        string value = NameFaker.Name();
        string valueComparer = NameFaker.FemaleFirstName();
        
        var result = value.IsEqual(valueComparer);

        result.Should().BeFalse();
    }
    
    [Fact]
    [Trait("Strings", "IsEqual = True")]
    public void Should_Return_True_When_String_Equals()
    {
        string name = NameFaker.Name(),
              value = name,
              valueComparer = name;

        var result = value.IsEqual(valueComparer);

        result.Should().BeTrue();
    }
}