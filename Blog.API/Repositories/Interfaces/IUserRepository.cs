using Blog.API.Entities;

namespace Blog.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
        public Task Create(User user);
        public Task Update(User user);
        public Task Delete(User user);
        public Task Restore(User user);
        public Task<User?> GetById(Guid id);
        public Task<User?> GetUserByUsername(string username);
       
        
    }
}
