using DTI.Core.Infrastructure.Out.Bus.Kafka;

namespace EShopOnContainer.Catalog.Infra.Out.Bus.Kafka
{
    public class CatalogKafkaBusService : CoreKafkaBusService
    {
        public CatalogKafkaBusService(string connectionString, string applicationGroup) : base(connectionString, applicationGroup)
        {
        }
    }
}