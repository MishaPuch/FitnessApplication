using FitnessApp.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.Helpers
{
    public class QueueHelper
    {
        public virtual async Task EmailVereficationAsync(User user)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "EmailVarefication",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var userJson = JsonConvert.SerializeObject(user);
                var body = Encoding.UTF8.GetBytes(userJson);

                await Task.Run(() =>
                {
                    channel.BasicPublish(exchange: "",
                                         routingKey: "EmailVarefication",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine($" User with email {user.UserEmail} was sent to verification ");
                });
            }
        }
    }
}
