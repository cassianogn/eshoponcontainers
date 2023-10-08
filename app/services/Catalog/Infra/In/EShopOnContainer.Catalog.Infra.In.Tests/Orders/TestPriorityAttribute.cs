namespace EShopOnContainer.Catalog.Infra.In.Tests.Orders
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
