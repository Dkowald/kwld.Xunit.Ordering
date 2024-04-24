
# Xunit simple ordering

A small project to order xUnit tests.

Simple Xunit test ordering, 
where the order is defined by the test-class, unit test declaration order.

[src](https://github.com/Dkowald/kwld.Xunit.Ordering) / [nuget](https://www.nuget.org/packages/kwld.Xunit.Ordering/)

# Usage

``` cs
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
    /// Ordering for a Theory matches the order of generated
    /// tests.
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
```

# Why?

There are more feature rich xunit ordering packages out there,
 such as 
[Xunit.Extensions.Ordering](https://www.nuget.org/packages/Xunit.Extensions.Ordering) and
[Dangl.Xunit.Extensions.Ordering](https://www.nuget.org/packages/Dangl.Xunit.Extensions.Ordering#dependencies-body-tab)

But sometimes; a simpler approach that fits can be easier to work with.

This adds a simple OrderedAttribute that records
the test method's line-number. 
This is then used to sort test from top to bottom (declaration order).

This package only handles ordering per test-class; and is focused 
on ordering based on test method declaration order.
