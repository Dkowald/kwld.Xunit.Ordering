namespace kwld.Xunit.Ordering.Tests;

using kwld.Xunit.Ordering;

/// <summary>
/// Add <see cref="TestCaseOrdererAttribute"/> to use the line orderer
/// </summary>
[TestCaseOrderer(LineOrderedTests.TypeName, LineOrderedTests.AssemName)]
public class UsageExample(UsageExample.State state): IClassFixture<UsageExample.State>
{
    public class State { public int Counter; }

    /// <summary>
    /// Add <see cref="OrderedAttribute"/> to include in sort order.
    /// First declared ordered test runs first.
    /// </summary>
    [Ordered, Fact]
    public void Test1()
    {
        Assert.Equal(1, state.Counter++);
    }

    /// <summary>
    /// Ordering for a Theory matches the order of generated tests.
    /// </summary>
    [Ordered, Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void Test2(int expected)
    {
        Assert.Equal(expected, state.Counter++);
    }

    /// <summary>
    /// Tests without <see cref="OrderedAttribute"/> run first
    /// </summary>
    [Fact]
    public void TestUnordered()
    {
        Assert.Equal(0, state.Counter++);
    }

}