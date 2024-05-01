using BarberShop2024.Server.Data;
using BarberShop2024.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace BarberShop2024.Server.Model
{
    public class UserModel : IUserModel
    {
        private readonly DataContext _context;

        public UserModel(DataContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteUser(int userId)
        {
            var foundUser = _context.Users.FirstOrDefault(e => e.UserId == userId);
            if (foundUser == null) return;

            _context.Users.Remove(foundUser);
            _context.SaveChanges();
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(c => c.UserId == userId);
        }

        public User UpdateUser(int userId, User user)
        {
            var foundUser = _context.Users.FirstOrDefault(e => e.UserId == user.UserId);

            if (foundUser != null)
            {

                foundUser.UserEmail = user.UserEmail;
                foundUser.UserPassword = user.UserPassword;
                foundUser.ShopName = user.ShopName;
                foundUser.UserPhone = user.UserPhone;
                foundUser.UserAdress = user.UserAdress;
                


                _context.SaveChangesAsync();

                return foundUser;
            }

            return null;
        }

    }
}
