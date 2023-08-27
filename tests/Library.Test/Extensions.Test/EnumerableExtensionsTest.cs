using Library.Extensions;

namespace Library.Test.Extensions.Test;

public class EnumerableExtensionsTest
{
    [Fact]
    [Trait("Enumerable", "CollectionIsNull")]
    public void Should_True_If_Collection_Is_Null()
    {
        var collection = new List<char>(0);

        collection.IsNullOrEmpty().Should().BeTrue();
    }

    [Fact]
    [Trait("Enumerable", "CollectionIsEmpty")]
    public void Should_True_If_Collection_Is_Empty()
    {
        var collection = new List<char>(0);

        collection.IsNullOrEmpty().Should().BeTrue();
    }

    [Fact]
    [Trait("Enumerable", "CollectionNotIsNullOrEmpty")]
    public void Should_False_If_Collection_Not_Is_Empty_And_Not_Null()
    {
        List<char> collection = new() { 'a', 'b', 'c' };

        collection.IsNullOrEmpty().Should().BeFalse();
    }
}