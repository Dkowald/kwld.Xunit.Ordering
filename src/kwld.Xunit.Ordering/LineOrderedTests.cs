using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace kwld.Xunit.Ordering
{
    /// <summary>
    /// Test case order using <see cref="OrderedAttribute"/>.
    /// </summary>
    public class LineOrderedTests : ITestCaseOrderer
    {
        /// <summary>Assembly name</summary>
        public const string AssemName = "kwld.Xunit.Ordering";
        /// <summary>TEst case order name</summary>
        public const string TypeName = "kwld.Xunit.Ordering.LineOrderedTests";

        /// <inheritdoc cref="ITestCaseOrderer.OrderTestCases{TTestCase}"/>
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            var ordered = testCases
                .Select(x => new { Priority = Priority(x.TestMethod), Item = x})
                .OrderBy(x => x.Priority)
                .ToArray();

            return ordered.Select(x => x.Item).ToArray();
        }

        private int Priority(ITestMethod op)
        {
            var line = op.Method.GetCustomAttributes(typeof(OrderedAttribute))
                .LastOrDefault()
                ?.GetNamedArgument<int>(nameof(OrderedAttribute.Priority)) ?? 0;

            return line;
        }
    }
}
