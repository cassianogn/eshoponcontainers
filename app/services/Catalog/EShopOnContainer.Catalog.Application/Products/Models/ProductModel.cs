using DTI.Core.Domain.DTOs.Entities;

namespace EShopOnContainer.Catalog.Application.Products.Entities
{
    public class ProductModel : NamedEntityDTO
    {
        public ProductModel()
        {
            
        }
        public ProductModel(Guid id, string name, string description, double price) : base(id, name)
        {
            Description = description;
            Price = price;
        }

        public string Description { get; set; }
        public double Price{ get; set; }
    }
}
