using EmailVereficationMicroservice;
using EmailVereficationMicroservice.Model;

public class VereficationUserRepository
{
    private readonly FitnessAppContext _context;
    private readonly Random _random = new Random();

    public VereficationUserRepository(FitnessAppContext context)
    {
        _context = context;
    }

    public async Task<VereficationUser> AddVereficationAsync(string email)
    {
        VereficationUser verefication = new()
        {
            Email = email,
            VereficationCode = _random.Next(10000, 99999)
        };

        await _context.VereficationUsers.AddAsync(verefication);
        await _context.SaveChangesAsync();

        return verefication;
    }
}
