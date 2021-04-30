using Microsoft.Extensions.Hosting;
using RabbitMq.Consumer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMq.Consumer.HostedServices
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IConsumerService _consumerService;

        public ConsumerHostedService(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumerService.ReadMessgaes();
        }
    }
}
