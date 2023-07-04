using Cassiano.EShopOnContainers.Core.Domain.Entities;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.Cars
{
    internal class Car : Entity<Car>
    {
        public Car(Guid id) : base(id)
        {
        }

        public string Name { get; private set; }
        public string Description { get; private set; }


        protected override void SetValidationRules()
        {
            base.SetValidationRules();
            AddDomainValidationPolicy(new CarValidation(this));
            AddDomainValidationPolicy(new CarValidation2(this));
        }

    }
}
