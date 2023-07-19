using Cassiano.EShopOnContainers.BackOffice.Domain.Products.ValueObjects.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace EShopOnContainer.BackOffice.Application.In.Products.Commands.Shared
{
    public class BaseProductDTO : NamedEntityDTO
    {
        public ProductPriceDTO Price { get; set; }
        public string Description { get; set; }
        public IReadOnlyCollection<EntityDTO> ProductCategories { get; set; }
        public IReadOnlyCollection<ProductColorDTO> ProductColors { get; set; }
    }
}
