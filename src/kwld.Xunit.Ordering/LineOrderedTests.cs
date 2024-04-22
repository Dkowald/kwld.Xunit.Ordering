using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace kwld.Xunit.Ordering
{
    public class LineOrderedTests : ITestCaseOrderer
    {
        public const string AssemName = "kwld.Xunit.Ordering";
        public const string TypeName = "kwld.Xunit.Ordering.LineOrderedTests";

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
