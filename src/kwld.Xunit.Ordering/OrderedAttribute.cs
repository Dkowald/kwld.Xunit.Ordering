using System;
using System.Runtime.CompilerServices;

namespace kwld.Xunit.Ordering
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OrderedAttribute : Attribute
    {
        public OrderedAttribute([CallerLineNumber] int priority = 0)
        {
            Priority = priority;
        }

        public int Priority { get; }
    }
}
