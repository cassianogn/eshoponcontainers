using EShopOnContainer.BackOffice.Domain.Products.ValueObjects.DTOs;
using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

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
