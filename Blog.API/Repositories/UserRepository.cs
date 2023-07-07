using Blog.API.Context;
using Blog.API.Entities;
using Blog.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            await _context.SaveChangesAsync();
        }

        public async Task Restore(User user)
        {
            await _context.SaveChangesAsync();
        }

        public  async Task<User?> GetById(Guid id)
        {
            User? user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            
            return user;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
       
            return user;
        }

        public  async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

       
    }
}
