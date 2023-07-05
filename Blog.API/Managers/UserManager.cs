using Blog.API.Context;
using Blog.API.Entities;
using Blog.API.Models;
using Blog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Managers
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserModel> Create(CreateUserDto model)
        {
            if (await _context.Users.AnyAsync(user => user.Username == model.Username && !user.IsDeleted))
            {
                throw new Exception("Username already exists!");
            }

            var user = new User()
            {
                Username= model.Username,
                Email= model.Email,
                Name= model.Name,
                IsDeleted = false
            };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);


            await _userRepository.Create(user);

            return MapToUserModel(user);

        }

        public async Task<UserModel> Update(UpdateUserDto model) 
        {
            var checkUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (checkUser == null)
            {
                throw new Exception("User not found");
            }
            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Name = model.Name,
                IsDeleted = false
            };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);


            await _userRepository.Update(user);
            return MapToUserModel(user);
        }
        public async Task Deleted(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId && !user.IsDeleted);

            if (user is null)
                throw new Exception("User not found!");

           

            user.IsDeleted = true;
            await _userRepository.Delete(user);
        }

        public async Task<UserModel> Restore(RestoreUserDto model)
        {

            var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == model.UserName && user.IsDeleted);

            if (user is null)
                throw new Exception("User not found!");



            user.IsDeleted = false;
            await _userRepository.Restore(user);
            return MapToUserModel(user);
        }

        public UserModel MapToUserModel(User user)
        {
            var userModel = new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Name = user.Name,
                UpdatedDate = user.UpdatedDate,
                CreatedDate = user.CreatedDate,
                IsDeleted= user.IsDeleted,
             
            };

            return userModel;
        }
    }
}
