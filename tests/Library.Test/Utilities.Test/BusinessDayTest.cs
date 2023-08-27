namespace Library.Test.Utilities.Test;

public class BusinessDayTest
{
    private readonly DateTime _currentDate = DateTime.UtcNow;
    private readonly int _currentYear = DateTime.UtcNow.Year;

    [Fact]
    [Trait("BusinessDay", "Get Html Content From Url")]
    public void Should_Be_Return_True_For_Weekend()
    {
        var nextWeekend = BusinessDay.GetNextWeekend(_currentDate);

        var result = BusinessDay.IsWeekend(nextWeekend);

        result.Should().BeTrue();
    }
}