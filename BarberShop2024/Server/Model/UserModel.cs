using BarberShop2024.Server.Data;
using BarberShop2024.Shared;
using Microsoft.EntityFrameworkCore;

namespace BarberShop2024.Server.Model
{
    public class UserModel : IUserModel
    {
        private readonly DataContext _context;
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
      
        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
