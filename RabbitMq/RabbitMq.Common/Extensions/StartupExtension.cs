using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMq.Common.Models;
using RabbitMq.Common.Services;

namespace RabbitMq.Common.Extensions
{
    public static class StartupExtension
    {
        public static void AddCommonService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqConfiguration>(a => configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(a));
            services.AddSingleton<IRabbitMqService, RabbitMqService>();
        }
    }
}
