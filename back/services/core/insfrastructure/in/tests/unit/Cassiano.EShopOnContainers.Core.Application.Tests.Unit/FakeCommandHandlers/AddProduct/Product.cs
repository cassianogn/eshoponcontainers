using Cassiano.EShopOnContainers.Core.Domain.Entities;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.AddProduct
{
    public class Product : Entity<Product>
    {
        public Product(Guid id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected override void SetValidationRules()
        {
            base.SetValidationRules();
            AddDomainValidationPolicy(new ProductValidation(this));
        }
    }
}
