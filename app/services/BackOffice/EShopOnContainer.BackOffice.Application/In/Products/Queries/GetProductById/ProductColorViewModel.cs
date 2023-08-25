using DTI.Core.Domain.DTOs.Entities;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.GetProductById
{
    public class ProductColorViewModel : NamedEntityDTO
    {
        public int StockQuantity { get; set; }
    }
}