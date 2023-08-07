using Cassiano.EShopOnContainers.Core.Domain.Helpers.Exceptions;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using Confluent.Kafka;
using System.Text.Json;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.Out.Bus.Kafka
{
    public abstract class CoreKafkaBusService : IInfrastructureBusService
    {
        protected readonly string ConnectionString;
        protected readonly string ApplicationGroup;
        protected CoreKafkaBusService(string connectionString, string applicationGroup)
        {

            ApplicationGroup = applicationGroup;
            ConnectionString = connectionString;
        }

        public async Task ConsumerAsync<TData>(Func<TData, Task> onConsume, CancellationToken cancellationToken = default)
        {
            var topic = typeof(TData).Name;
            _ = Task.Factory.StartNew(async () =>
            {
                using var consumer = CreateConsumerSubscription(topic);
                Console.WriteLine($"consuming data from {topic}");

                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumedDataResult = GetConsumedDataResult(consumer);
                    if (consumedDataResult.IsPartitionEOF) continue;
                    try
                    {
                        var message = ConvertStringConsumedDataToTData<TData>(consumedDataResult);
                        await RunDelegate(onConsume, consumedDataResult, message);
                    }
                    catch
                    {
                        continue;
                    }
                  
                    consumer.Commit();
                }
                Console.WriteLine($"Shutting down consumer: {consumer.Name}");
            }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            await Task.CompletedTask;
        }

        private static async Task RunDelegate<TData>(Func<TData, Task> onConsume, ConsumeResult<string, string> consumedDataResult, TData message)
        {
            try
            {
                await onConsume(message);
            }
            catch (Exception onConsumeError)
            {
                Console.WriteLine($"Error to consume data from Apache Kafka on delegate. Error: " + onConsumeError.Message);
                Console.WriteLine(consumedDataResult.Message.Value);
                throw new ApplicationCoreException("Error to consume data from Apache Kafka on delegate", onConsumeError);
            }
        }

        private static TData ConvertStringConsumedDataToTData<TData>(ConsumeResult<string, string> consumedDataResult)
        {
            TData message;
            try
            {
                message = JsonSerializer.Deserialize<TData>(consumedDataResult.Message.Value)!;
            }
            catch (Exception jsonError)
            {
                Console.WriteLine($"Error to deserialize data from Apache Kafka. Error: " + jsonError.Message);
                Console.WriteLine(consumedDataResult.Message.Value);
                throw new ApplicationCoreException("Error to deserialize data from Apache Kafka", jsonError);
            }

            return message;
        }

        private static ConsumeResult<string, string> GetConsumedDataResult(IConsumer<string, string> consumer)
        {
            ConsumeResult<string, string> consumedDataResult;
            try
            {
                consumedDataResult = consumer.Consume();
            }
            catch (Exception subscribeError)
            {
                Console.WriteLine($"Error to Consume on Apache Kafka topic. Error: " + subscribeError.Message);
                throw new ApplicationCoreException("Error to Consume on Apache Kafka topic", subscribeError);
            }

            return consumedDataResult;
        }

        private IConsumer<string, string> CreateConsumerSubscription(string topic)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = ConnectionString,
                GroupId = $"{topic}-{ApplicationGroup}",
                EnableAutoCommit = false,
                EnablePartitionEof = true
            };
            var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(topic);
            return consumer;
        }

        public async Task PublishEvent<TData>(TData data, CancellationToken cancellationToken = default)
        {

            await ProducerAsync(data, cancellationToken);
        }

        public async Task<CommandResult> SendMessage<TData>(TData data, CancellationToken cancellationToken = default)
        {
            await ProducerAsync(data, cancellationToken);
            return CommandResult.CommandFinished();
        }

        public Task<CommandResult<TResponse>> SendMessage<TData, TResponse>(TData data, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException("the request of type Request/Response not is supported with apache kafka");
        }

        protected async Task ProducerAsync<TData>(TData data, CancellationToken cancellationToken = default)
        {
            var kafkaTransferDataDTO = new KafkaTransferDataDTO<TData>(data);
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = ConnectionString
            };
            var producer = new ProducerBuilder<string, string>(producerConfig).Build();
            try
            {
                await producer.ProduceAsync(kafkaTransferDataDTO.Topic, new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = kafkaTransferDataDTO.MessageContent }, cancellationToken);
            }
            catch (Exception kafkaError)
            {
                throw new ApplicationCoreException($"don't possible publish data to Apache Kafka. Topic: '{kafkaTransferDataDTO.Topic}', Data: {kafkaTransferDataDTO.MessageContent}", kafkaError);
            }

        }
    }
}