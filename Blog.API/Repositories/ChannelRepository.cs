using Blog.API.Context;
using Blog.API.Entities;
using Blog.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly AppDbContext _context;
        public async Task  Create(Channel channel)
        {
            _context.Channels.Add(channel);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Channel channel)
        {
           await _context.SaveChangesAsync();
        }

        public async Task<Channel?> GetById(Guid id)
        {
            Channel? channel = await _context.Channels
                .Where(i => i.Id == id)
                .Include(c => c.Posts)
                .Include(u => u.Users)
                .FirstOrDefaultAsync();
            return channel;
            
        }

       public async Task<List<Channel>> GetChannnels(Channel channel)
        {
            return await _context.Channels.ToListAsync();
        }

        public async Task<Channel?> GetUserByUsername(string name)
        {
            Channel? channel = await _context.Channels
                .Where(i => i.Name == name)
                .Include(c => c.Posts)
                .Include(u => u.Users)
                .FirstOrDefaultAsync();
            return channel;

        }

        public async  Task Update(Channel channel)
        {
            _context.Channels.Update(channel);
            await _context.SaveChangesAsync();

        }
    }
}
