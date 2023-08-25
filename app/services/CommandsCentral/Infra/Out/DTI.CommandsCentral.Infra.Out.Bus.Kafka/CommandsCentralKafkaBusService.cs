using DTI.Core.Infrastructure.Out.Bus.Kafka;

namespace DTI.CommandsCentral.Infra.Out.Bus.Kafka
{
    public class CommandsCentralKafkaBusService : CoreKafkaBusService
    {
        public CommandsCentralKafkaBusService(string connectionString, string applicationGroup) : base(connectionString, applicationGroup)
        {
        }
    }
}
