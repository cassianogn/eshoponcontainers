using DTI.Core.Infrastructure.Out.Bus.Kafka;

namespace EShopOnContainer.BackOffice.Infra.Out.Bus.Kafka
{
    public class BackOfficeKafkaBusService : CoreKafkaBusService
    {
        public BackOfficeKafkaBusService(string connectionString, string applicationGroup) : base(connectionString, applicationGroup)
        {
        }
    }
}
