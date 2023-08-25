using DTI.Core.Domain.Helpers.Exceptions;
using System.Text.Json;

namespace DTI.Core.Infrastructure.Out.Bus.Kafka
{
    internal class KafkaTransferDataDTO<TData>
    {
        public KafkaTransferDataDTO(TData data)
        {
            Topic = typeof(TData).Name;
            try
            {
                MessageContent = JsonSerializer.Serialize(data);
            }
            catch (Exception jsonError)
            {
                throw new ApplicationCoreException($"don't possible convert '{Topic}' to jason data", jsonError);
            }
        }
        public string Topic { get; set; }
        public string MessageContent { get; set; }
    }
}
