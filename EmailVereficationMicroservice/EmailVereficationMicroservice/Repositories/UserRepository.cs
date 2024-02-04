using EmailVereficationMicroservice;
using EmailVereficationMicroservice.Model;
using Microsoft.EntityFrameworkCore;

public class UserRepository
{
    private readonly FitnessAppContext _context;

    public UserRepository(FitnessAppContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
    }
}
