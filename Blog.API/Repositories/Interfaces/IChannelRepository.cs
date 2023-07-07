using Blog.API.Entities;

namespace Blog.API.Repositories.Interfaces
{
    public interface IChannelRepository
    {
        public Task<List<Channel>> GetChannnels(Channel channel);
        public Task Create(Channel channel);
        public Task Update(Channel channel);
        public Task Delete(Channel channel);
        
        public Task<Channel?> GetById(Guid id);
        public Task<Channel?> GetUserByUsername(string username);
    }
}
