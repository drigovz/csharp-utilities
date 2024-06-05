using Library.Extensions;

namespace Library.Test.Extensions.Test;

public class TimeOnlyExtensionTest
{
    [Fact]
    [Trait("TimeOnly", "Should Add Seconds To Time Only")]
    public void Should_Add_Seconds_To_Time_Only()
    {
        var time = new TimeOnly(10, 20);

        time = time.AddSeconds(15);
        
        time.Should().NotBe(null);
        time.Second.Should().Be(15);
    }
    
    [Fact]
    [Trait("TimeOnly", "Should Add Milliseconds To Time Only")]
    public void Should_Add_Milliseconds_To_Time_Only()
    {
        var time = new TimeOnly(10, 20, 30);

        time = time.AddMilliseconds(15);
        
        time.Should().NotBe(null);
        time.Millisecond.Should().Be(15);
    }
}