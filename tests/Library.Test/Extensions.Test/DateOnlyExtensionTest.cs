using Library.Extensions;

namespace Library.Test.Extensions.Test;

public class DateOnlyExtensionTest
{
    [Fact]
    [Trait("DateOnly", "Difference Between Dates")]
    public void Should_Be_Calculate_Difference_Between_Dates()
    {
        var dateOne = new DateOnly(1995, 08, 30);
        var dateTwo = new DateOnly(2024, 08, 30);

        var difference = dateTwo.DaysDifference(dateOne);

        var equals = difference.Equals(10593);
        equals.Should().BeTrue();
    }
    
    [Fact]
    [Trait("DateOnly", "Difference Between Years")]
    public void Should_Be_Calculate_Difference_Between_Years()
    {
        var date = new DateOnly(1995, 08, 30);
        var difference = date.YearsDifference(10593);

        var equals = difference.Equals(29);
        equals.Should().BeTrue();
    }
    
    [Fact]
    [Trait("DateOnly", "Difference Between Years With CalculateDiferrence Method")]
    public void Should_Be_Calculate_Difference_Between_Years_With_CalculateDiferrence()
    {
        var dateOne = new DateOnly(1995, 08, 30);
        var dateTwo = new DateOnly(2024, 08, 30);

        var difference = dateTwo.CalculateDiferrence(dateOne);
        
        var equals = difference.Equals(29);
        equals.Should().BeTrue();
    }
}