namespace kwld.Xunit.Ordering.Tests;

/// <summary>
/// Un-ordered cases execute first.
/// </summary>
[TestCaseOrderer(LineOrderedTests.TypeName, LineOrderedTests.AssemName)]
public class TestWithUnOrderedTest(State state) 
    : IClassFixture<State>
{
    [Ordered, Fact]
    public void Test1(){Assert.Equal(5, state.Counter++); }

    [Ordered, Fact]
    public void Test2() {Assert.Equal(6, state.Counter); }

    [Fact]
    public void Test3()
    {
        Assert.Equal(0, state.Counter);
        state.Counter = 5;

    }
}