using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using WM.DevFreela.Core.IntegrationEvents;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Consumers
{
    public class PaymentApprovedConsumer : BackgroundService
    {
        private const string PAYMENT_APPROVED_QUEUE = "PaymentsApproved";

        private readonly IModel _channel;
        private readonly IConnection _connection;
        private readonly IServiceProvider _serviceProvider;

        public PaymentApprovedConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // criar a fila no inicio
            _channel.QueueDeclare(queue: PAYMENT_APPROVED_QUEUE, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, eventArgs) =>
            {
                var paymentApprovedBytes = eventArgs.Body.ToArray();
                var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);
                var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

                await FinishProject(paymentApprovedIntegrationEvent.IdProject);

                // reconhecimento da mensagem
                _channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: PAYMENT_APPROVED_QUEUE, autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        private async Task FinishProject(int id)
        {
            using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

                var project = await projectRepository.GetByIdAsync(id);

                project.Finish();

                await projectRepository.SaveChangesAsync();
            }
        }
    }
}
