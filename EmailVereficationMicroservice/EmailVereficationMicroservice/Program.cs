using EmailVereficationMicroservice;

using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        

        using (var context = new FitnessAppContext())
        {
            // Передайте UserRepository и VereficationUserRepository в конструктор EmailVerefication
            UserRepository userRepository = new UserRepository(context);
            VereficationUserRepository vereficationUserRepository = new VereficationUserRepository(context);

            // Pass the context, userRepository, and vereficationUserRepository to the EmailVerefication constructor
            EmailVerefication emailVerefication = new EmailVerefication(userRepository, vereficationUserRepository, context);

            // Call the RecieveEmail method
            emailVerefication.RecieveEmail();
        }
    }
}
