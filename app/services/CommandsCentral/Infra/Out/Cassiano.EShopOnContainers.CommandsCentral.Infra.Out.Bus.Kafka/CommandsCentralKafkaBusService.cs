using Cassiano.EShopOnContainers.Core.Infrastructure.Out.Bus.Kafka;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.Out.Bus.Kafka
{
    public class CommandsCentralKafkaBusService : CoreKafkaBusService
    {
        public CommandsCentralKafkaBusService(string connectionString, string applicationGroup) : base(connectionString, applicationGroup)
        {
        }
    }
}
