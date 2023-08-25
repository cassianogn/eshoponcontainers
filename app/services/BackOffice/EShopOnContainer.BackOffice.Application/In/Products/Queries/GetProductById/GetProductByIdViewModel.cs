using EShopOnContainer.BackOffice.Domain.Products.SubEntities;
using EShopOnContainer.BackOffice.Domain.Products.ValueObjects;
using EShopOnContainer.BackOffice.Domain.Products.ValueObjects.DTOs;
using DTI.Core.Domain.DTOs.Entities;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.GetProductById
{
    public class GetProductByIdViewModel : NamedEntityDTO
    {
        public ProductPriceDTO Price { get; set; }
        public bool Enable { get; set; }
        public string Description { get; set; }
        public DateTime? EnableDate { get; set; }
        public DateTime? DisableDate { get; set; }
        public IEnumerable<NamedEntityDTO> ProductCategories { get;  set; }
        public IEnumerable<ProductColorViewModel> ProductColors { get;  set; }
    }
}
