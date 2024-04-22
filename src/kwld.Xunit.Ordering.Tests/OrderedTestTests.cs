namespace kwld.Xunit.Ordering.Tests;

[TestCaseOrderer(LineOrderedTests.TypeName, LineOrderedTests.AssemName)]
public class OrderedTestTests(State state) 
    : IClassFixture<State>
{
    [Ordered, Fact]
    public void Test1()
    { Assert.Equal(0, state.Counter++); }

    [Ordered, Fact]
    public void Test2()
    {Assert.Equal(1, state.Counter++); }

    [Ordered, Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void Test3(int expected)
    { Assert.Equal(expected, state.Counter++); }
}