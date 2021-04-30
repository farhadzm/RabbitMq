using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMq.Common.Extensions;
using RabbitMq.Consumer.HostedServices;
using RabbitMq.Consumer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMq.Consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonService(Configuration);
            services.AddSingleton<IConsumerService, ConsumerService>();
            services.AddHostedService<ConsumerHostedService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
