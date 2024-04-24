using System;
using System.Runtime.CompilerServices;

namespace kwld.Xunit.Ordering
{
    /// <summary>
    /// Add to unit test to define its order based on source line number
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OrderedAttribute : Attribute
    {
        /// <summary>
        /// <inheritdoc cref="OrderedAttribute"/>
        /// </summary>
        /// <param name="priority">Set to source file line</param>
        public OrderedAttribute([CallerLineNumber] int priority = 0)
        {
            Priority = priority;
        }

        /// <summary>Test case priority order</summary>
        public int Priority { get; }
    }
}
