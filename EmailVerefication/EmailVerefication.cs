using FitnessApp.Models;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FitnessApp.DAL;
using FitnessApp.DAL.DiRepositories;

namespace EmailVerefication
{
    public class EmailVerefication
    {
        private readonly UserRepository _userRepository;
        public EmailVerefication()
        {
        }

        public async Task RecieveEmail()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var chanel = connection.CreateModel())
            {
                chanel.QueueDeclare(queue: "EmailVarefication",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
                var consumer = new EventingBasicConsumer(chanel);

                consumer.Received += async (sender, e) =>
                {
                    var body = e.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    User gettingUser = JsonConvert.DeserializeObject<User>(message);
                    Console.WriteLine("Received user : " + gettingUser.UserEmail);
                    
                    gettingUser.IsEmailConfirmed = true;
                    await _userRepository.UpdateUserAsync(gettingUser);
                };
                chanel.BasicConsume(queue: "EmailVarefication",
                                    autoAck: true,
                                    consumer: consumer);
                Console.ReadKey();

            }
        }
    }
}
