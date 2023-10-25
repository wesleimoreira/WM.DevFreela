using RabbitMQ.Client;
using WM.DevFreela.Core.Services;

namespace WM.DevFreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        public void Publish(string queue, byte[] message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",          
                UserName = "admin",
                Password = "123456",
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // realiza a declaração da fila e seus comportamento
                    channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    // publica a fina para o rabbitmq
                    channel.BasicPublish(exchange: string.Empty, routingKey: queue, basicProperties: null, body: message);
                }
            }
        }
    }
}
