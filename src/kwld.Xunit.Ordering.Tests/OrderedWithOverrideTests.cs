namespace kwld.Xunit.Ordering.Tests;

[TestCaseOrderer(LineOrderedTests.TypeName, LineOrderedTests.AssemName)]
public class OrderedWithOverrideTests(State state) : IClassFixture<State>
{
    [Ordered, Fact]
    public void Test1() { Assert.Equal(0, state.Counter++); }

    /// <summary>
    /// Can over-ride by explicitly setting the order priority
    /// (rather than just using its line-number
    /// </summary>
    [Ordered(10000), Fact]
    public void Test2() { Assert.Equal(2, state.Counter); }

    [Ordered, Fact]
    public void Test3()
    {
        Assert.Equal(1, state.Counter++);
    }
}