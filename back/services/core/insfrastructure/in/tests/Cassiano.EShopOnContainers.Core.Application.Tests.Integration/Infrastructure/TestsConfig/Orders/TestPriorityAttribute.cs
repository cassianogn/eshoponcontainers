using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.Orders
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestPriorityAttribute : Attribute
    {
        public TestPriorityAttribute(double priority)
        {
            Priority = priority;
        }

        public double Priority { get; }
    }
}
