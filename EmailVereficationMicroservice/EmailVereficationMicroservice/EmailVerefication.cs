using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using EmailVereficationMicroservice.Helper;
using EmailVereficationMicroservice;
using EmailVereficationMicroservice.Model;

public class EmailVerefication
{
    private readonly UserRepository _userRepository;
    private readonly VereficationUserRepository _vereficationUserRepository;
    private readonly FitnessAppContext _context;

    public EmailVerefication(UserRepository userRepository, VereficationUserRepository vereficationUserRepository, FitnessAppContext context)
    {
        _userRepository = userRepository;
        _vereficationUserRepository = vereficationUserRepository;
        _context = context;
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
                var gettingUser = JsonConvert.DeserializeObject<User>(message);
                Console.WriteLine("Received user : " + gettingUser.UserEmail);

                var existingUser = await _userRepository.GetUserByEmailAsync(gettingUser.UserEmail);
                if (existingUser != null)
                {
                    var vereficationUser = await _vereficationUserRepository.AddVereficationAsync(gettingUser.UserEmail );

                    await EmailSendingHelper.SendEmailAsync(vereficationUser.Email, vereficationUser.VereficationCode);
                }
                else
                {
                    Console.WriteLine($"User {gettingUser.UserEmail} does not exist.");
                }
            };

            chanel.BasicConsume(queue: "EmailVarefication",
                                autoAck: true,
                                consumer: consumer);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
