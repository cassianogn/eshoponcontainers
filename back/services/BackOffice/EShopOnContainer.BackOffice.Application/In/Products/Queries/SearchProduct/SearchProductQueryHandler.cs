using Cassiano.EShopOnContainers.BackOffice.Domain.Products;
using Cassiano.EShopOnContainers.Core.Application.In.Queries.SearchNamedEntity;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopOnContainer.BackOffice.Application.In.Products.Queries.SearchProduct
{
    internal class SearchProductQueryHandler : SearchNamedEntityQueryHandler<Product, IProductRepository, SearchProductQuery, SearchProductViewModel>
    {
        public SearchProductQueryHandler(IMediator mediator, IProductRepository repository) : base(mediator, repository)
        {
        }

    }
}
