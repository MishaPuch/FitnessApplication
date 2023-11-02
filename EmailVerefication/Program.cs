using FitnessApp.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        EmailVerefication.EmailVerefication verefication = new EmailVerefication.EmailVerefication();
        verefication.RecieveEmail();
    }
}