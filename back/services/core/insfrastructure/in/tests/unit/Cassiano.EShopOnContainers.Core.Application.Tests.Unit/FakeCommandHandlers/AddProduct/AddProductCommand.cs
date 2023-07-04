using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.AddProduct
{
    internal class AddProductCommand : NamedEntityDTO, IAppMessage<Guid?>
    {
        public AddProductCommand()
        {
        }

        public string Description { get; set; }
    }
}
