using Microsoft.AspNetCore.Mvc;
using RabbitMq.Common.Services;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMq.Producer.Conrtrollers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMqService;

        public HomeController(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }
        [HttpPost]
        public IActionResult SendMessage()
        {
            using var connection = _rabbitMqService.CreateChannel();
            using var model = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes("Hi");
            model.BasicPublish("UserExchange",
                                 string.Empty,
                                 basicProperties: null,
                                 body: body);

            return Ok();
        }
    }
}
