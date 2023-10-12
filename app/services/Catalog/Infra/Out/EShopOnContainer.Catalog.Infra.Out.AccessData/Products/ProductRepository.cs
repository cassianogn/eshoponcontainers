using DTI.Core.Domain.Helpers.Exceptions;
using Elastic.Clients.Elasticsearch;
using EShopOnContainer.Catalog.Application.Products.Entities;
using EShopOnContainer.Catalog.Application.Products.Interfaces;

namespace EShopOnContainer.Catalog.Infra.Out.AccessData.Products
{
    internal class ProductRepository : IProductRepository
    {
        private const string INDEX_NAME = "catalog_products";
        private readonly ElasticsearchClient _elasticsearchClient;

        public ProductRepository(ElasticsearchClient elasticsearchClient)
        {
            _elasticsearchClient = elasticsearchClient;
            if (!ExistIndex())
                CreateIndex();
        }

        private void CreateIndex()
        {
            try
            {
                var response = _elasticsearchClient.Indices.CreateAsync(INDEX_NAME).Result;
                if (!response.IsSuccess())
                    throw new ApplicationCoreException("the response not return success, error: " + response.ElasticsearchServerError!.Error.Reason.ToString());
            }
            catch (Exception error)
            {
                throw new ApplicationCoreException("can't create index on elastic search", error);
            }
        }

        public async Task Add(ProductModel product)
        {
            try
            {
                var response = await _elasticsearchClient.IndexAsync(product, INDEX_NAME);
                if (!response.IsSuccess())
                    throw new ApplicationCoreException("the response not return success, error: " + response.ElasticsearchServerError!.Error.Reason.ToString());
            }
            catch (Exception error)
            {
                throw new ApplicationCoreException("error on add product on elastic", error);
            }   
        }

        public async Task<ProductModel?> GetById(Guid id)
        {

            var response = await _elasticsearchClient.GetAsync<ProductModel>(id, idx => idx.Index(INDEX_NAME));
            return response.Source;
        }

        public async Task<IReadOnlyCollection<ProductModel>> Search(int page, string? name = null, string? description = null, double? price = null)
        {
            var counter = 20;
            var counterInPage = counter * page;
            var pageFrom = counterInPage - counter;
            var pageTo = counter;

            var response = await _elasticsearchClient.SearchAsync<ProductModel>(searchDescription => searchDescription
                .Index(INDEX_NAME)
                .From(pageFrom)
                .Size(pageTo)
                .Query(query =>
                {
                    if (!string.IsNullOrEmpty(name))
                        query.Term(term => term.Field(field => field.Name).Value(name));
                    if (!string.IsNullOrEmpty(description))
                        query.Term(term => term.Field(field => field.Description).Value(name));
                    if (price.HasValue)
                        query.Term(term => term.Field(field => field.Price).Value(price.Value));
                }));

            return response.Documents;
        }

        public bool ExistIndex()
        {
            try
            {
                var result = _elasticsearchClient.Indices.Exists(INDEX_NAME);
                return result.Exists;
            }
            catch (Exception error)
            {

                throw new ApplicationCoreException("error on search if indecis exist on elastic", error);
            }
        }
    }
}
