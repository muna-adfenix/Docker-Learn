using DL.RabbitMQ.Core.Infrastructure;
using DL.RabbitMQ.Domain.Command;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace DL.Producer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PublicationController : Controller
    {
        private readonly IRabbitMQPublisher _rabbitMqPublisher;

        public PublicationController(IRabbitMQPublisher rabbitMqPublisher)
        {
            this._rabbitMqPublisher = rabbitMqPublisher;
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            var person = new Student
            {
                Name = "Muna",
                Email = "muna@adfenix.com",
                Age = 28
            };
            this._rabbitMqPublisher.Publish(person, ExchangeType.Direct, "docker.test.exchange", "docker.test.queue");
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]Student student)
        {
          this._rabbitMqPublisher.Publish(student, ExchangeType.Direct, "docker.test.exchange", "docker.test.queue");
        }
  }
}