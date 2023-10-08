using DTI.Core.Infra.Out.Bus.Kafka;

namespace EShopOnContainer.Catalog.Infra.Out.Bus.Kafka
{
    public class CatalogKafkaBusService : CoreKafkaBusService
    {
        public CatalogKafkaBusService(string connectionString, string applicationGroup) : base(connectionString, applicationGroup)
        {
        }
    }
}